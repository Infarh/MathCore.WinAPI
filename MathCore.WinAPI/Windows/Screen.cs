using System.Drawing;
using System.Text;

using MathCore.WinAPI.pInvoke;

using Microsoft.Win32;

namespace MathCore.WinAPI.Windows;

public class Screen
{
    private const int __PrimaryMonitor = unchecked((int)0xBAADF00D);

    /* -------------------------------------------------------------------------------------------------------- */

    private static readonly bool __MultiMonitorSupport = User32.GetSystemMetrics(User32.SystemMetric.SM_CMONITORS) != 0;

    /// <summary>Статический счётчик количества изменений рабочего стола</summary>
    private static int __DesktopChangedCount = -1;

    /// <summary>Объект для блокировки критической секции</summary>
    private static readonly object _SyncRoot = new();

    /// <summary>Текущий список экранов</summary>
    private static Screen[]? _Screens;

    /* -------------------------------------------------------------------------------------------------------- */

    /// <summary>Дескриптор текущего экрана</summary>
    private readonly nint _hMonitor;

    /// <summary>Размеры экрана</summary>
    private readonly Rectangle _Bounds;

    /// <summary>Доступная для окон область экрана. Область исключает панель задач и другие пристыкованные окна.</summary>
    private Rectangle _WorkingArea = Rectangle.Empty;

    /// <summary>Является ли экран основным</summary>
    private readonly bool _Primary;

    /// <summary>Название устройства монитора</summary>
    private readonly string _DeviceName;

    private readonly int _BitDepth;

    /// <summary>Счётчик изменений текущего рабочего стола</summary>
    private int _CurrentDesktopChangedCount = -1;

    internal Screen(nint monitor, Gdi32.HDC hdc = default)
    {
        var screen_dc = hdc;

        if (!__MultiMonitorSupport || monitor == __PrimaryMonitor)
        {
            _Bounds = SystemInformation.VirtualScreen;
            _Primary = true;
            _DeviceName = "DISPLAY";
        }
        else
        {
            // Система с множеством мониторов
            var info = new User32.MonitorInfoExW();

            User32.GetMonitorInfo(monitor, ref info);

            (_Bounds, _Primary, _DeviceName) = info;

            if (hdc.IsNull)
                screen_dc = Gdi32.CreateDC(_DeviceName, null, null, IntPtr.Zero);
        }

        _hMonitor = monitor;

        _BitDepth = Gdi32.GetDeviceCaps(screen_dc, Gdi32.DeviceCapability.BITSPIXEL);
        _BitDepth *= Gdi32.GetDeviceCaps(screen_dc, Gdi32.DeviceCapability.PLANES);

        if (hdc != screen_dc)
            Gdi32.DeleteDC(screen_dc);
    }

    /// <summary>Список текущих экранов в системе</summary>
    public static IReadOnlyList<Screen> AllScreens
    {
        get
        {
            if (_Screens is not null) return _Screens;

            if (!__MultiMonitorSupport)
                _Screens = new[] { PrimaryScreen! };
            else
            {
                List<Screen> screens = new();

                bool EnumScreens(nint monitor, Gdi32.HDC hdc, nint lprcMonitor, nint lparam)
                {
                    screens.Add(new(monitor, hdc));
                    return true;
                }

                User32.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, EnumScreens, IntPtr.Zero);

                _Screens = screens.Count > 0 ? screens.ToArray() : new[] { new Screen(__PrimaryMonitor) };
            }

            // После того как получен список экранов, начинаем отслеживать изменения экранов в системе
            SystemEvents.DisplaySettingsChanging += OnDisplaySettingsChanging;

            return _Screens;
        }
    }

    /// <summary>Глубина цвета экрана (бит на пиксель)</summary>
    public int BitsPerPixel => _BitDepth;

    /// <summary>Размер экрана</summary>
    public Rectangle Bounds => _Bounds;

    /// <summary>Название устройства экрана</summary>
    public string DeviceName => _DeviceName;

    /// <summary>Является ли экран основным</summary>
    public bool Primary => _Primary;

    /// <summary>Главный экран</summary>
    public static Screen? PrimaryScreen => __MultiMonitorSupport
        ? AllScreens.FirstOrDefault(t => t._Primary)
        : new(__PrimaryMonitor);

    /// <summary>Рабочая область экрана</summary>
    public Rectangle WorkingArea
    {
        get
        {
            // Если статический счётчик изменений экрана имеет отличное значение от счётчика изменений
            // текущего экрана, то требуется обновить информацию о размере рабочей области
            if (_CurrentDesktopChangedCount == DesktopChangedCount)
                return _WorkingArea;

            Interlocked.Exchange(ref _CurrentDesktopChangedCount, DesktopChangedCount);

            if (!__MultiMonitorSupport || _hMonitor == __PrimaryMonitor)
                // Система с одним монитором
                _WorkingArea = SystemInformation.WorkingArea;
            else
            {
                // Система с множеством мониторов
                var info = new User32.MonitorInfoExW();
                User32.GetMonitorInfo(_hMonitor, ref info);
                _WorkingArea = info.rcWork;
            }

            return _WorkingArea;
        }
    }

    /// <summary>Экземпляр <see cref="Screen"/> вызывает это свойство для того что бы определить изменения в <see cref="WorkingArea"/></summary>
    private static int DesktopChangedCount
    {
        get
        {
            if (__DesktopChangedCount != -1)
                return __DesktopChangedCount;

            lock (_SyncRoot)
            {
                // Повторная проверка после блокировки
                if (__DesktopChangedCount != -1) return __DesktopChangedCount;

                SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;

                __DesktopChangedCount = 0;
            }

            return __DesktopChangedCount;
        }
    }

    public override bool Equals(object? obj) => obj is Screen { _hMonitor: var hmonitor } && hmonitor == _hMonitor;

    /// <summary>Получить <see cref="Screen"/> для указанной по координатам точки</summary>
    public static Screen FromPoint(Point point) => __MultiMonitorSupport
        ? new(User32.MonitorFromPoint(point, User32.MonitorInfo.DEFAULTTONEAREST))
        : new(__PrimaryMonitor);

    /// <summary>Получить <see cref="Screen"/>, который содержит регион наибольшего размера</summary>
    public static Screen FromRectangle(Rectangle rect)
    {
        if (!__MultiMonitorSupport)
            return new(__PrimaryMonitor);

        RECT rc = rect;
        return new(User32.MonitorFromRect(ref rc, User32.MonitorInfo.DEFAULTTONEAREST));
    }

    /// <summary>Получить <see cref="Screen"/> для указанного окна (по его идентификатору)</summary>
    public static Screen FromHandle(nint hwnd) => __MultiMonitorSupport
        ? new(User32.MonitorFromWindow(hwnd, User32.MonitorInfo.DEFAULTTONEAREST))
        : new(__PrimaryMonitor);

    /// <summary>Получить рабочую область экрана по указанной точке</summary>
    public static Rectangle GetWorkingArea(Point pt) => FromPoint(pt).WorkingArea;

    /// <summary>Получить рабочую область экрана по указанной прямоугольной области</summary>
    public static Rectangle GetWorkingArea(Rectangle rect) => FromRectangle(rect).WorkingArea;

    /// <summary>Получить размер экрана по указанной точке</summary>
    public static Rectangle GetBounds(Point pt) => FromPoint(pt).Bounds;

    /// <summary>Получить размер экрана по указанному размеру прямоугольной области</summary>
    public static Rectangle GetBounds(Rectangle rect) => FromRectangle(rect).Bounds;

    public override int GetHashCode() => ConvertParam.ToInt(_hMonitor);

    /// <summary>Обработчик события изменения состояния экранов в системе. Сбрасывает список текущих экранов</summary>
    private static void OnDisplaySettingsChanging(object? sender, EventArgs e)
    {
        // После вызова обработчика отписываемся от изменений
        SystemEvents.DisplaySettingsChanging -= OnDisplaySettingsChanging;

        // И сбрасываем список текущих экранов
        _Screens = null;
    }

    /// <summary>Обработчик события изменения состояния экрана. Увеличивает счётчик изменений экрана</summary>
    private static void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        if (e.Category == UserPreferenceCategory.Desktop)
            Interlocked.Increment(ref __DesktopChangedCount);
    }

    public override string ToString() =>
        new StringBuilder(128)
           .Append(GetType().Name)
           .Append("[Bounds=")
           .Append(_Bounds)
           .Append(" WorkingArea=")
           .Append(WorkingArea)
           .Append(" Primary=")
           .Append(_Primary)
           .Append(" DeviceName=")
           .Append(_DeviceName)
           .Append(']').ToString();
}
