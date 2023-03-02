using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace MathCore.WinAPI.pInvoke;

public static class User32
{
    public const string FileName = "user32.dll";

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MonitorInfoExW
    {
        public const int CCHDEVICENAME = 32;

        public int Size;

        public RECT rcMonitor;

        public RECT rcWork;

        public MonitorInfoF dwFlags;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        public string DeviceName;

        public MonitorInfoExW() => (Size, DeviceName) = (72, string.Empty);

        public override string ToString() => $"{DeviceName}[{rcMonitor}]({rcWork}){(dwFlags == MonitorInfoF.PRIMARY ? ":primary" : null)}";

        public void Deconstruct(out Rectangle Bounds, out bool IsPrimary, out string Name) => (Bounds, IsPrimary, Name) = (rcMonitor, (dwFlags & MonitorInfoF.PRIMARY) != 0, DeviceName);
    }

    [Flags]
    public enum MonitorInfoF : uint
    {
        PRIMARY = 1,
    }

    public enum MonitorInfo : uint
    {
        /// <summary>IntPtr.Zero в случае неудачи</summary>
        DEFAULTTONULL,
        /// <summary>Дескриптор главного монитора в случае неудачи</summary>
        DEFAULTTOPRIMARY,
        /// <summary>Дескриптор ближайшего монитора в случае неудачи</summary>
        DEFAULTTONEAREST,
    }

    public enum SystemMetric
    {
        SM_CXSCREEN = 0,
        SM_CYSCREEN = 1,
        SM_CXVSCROLL = 2,
        SM_CYHSCROLL = 3,
        SM_CYCAPTION = 4,
        SM_CXBORDER = 5,
        SM_CYBORDER = 6,
        SM_CXFIXEDFRAME = 7,
        SM_CYFIXEDFRAME = 8,
        SM_CYVTHUMB = 9,
        SM_CXHTHUMB = 10, // 0x0000000A
        SM_CXICON = 11, // 0x0000000B
        SM_CYICON = 12, // 0x0000000C
        SM_CXCURSOR = 13, // 0x0000000D
        SM_CYCURSOR = 14, // 0x0000000E
        SM_CYMENU = 15, // 0x0000000F
        SM_CYKANJIWINDOW = 18, // 0x00000012
        SM_MOUSEPRESENT = 19, // 0x00000013
        SM_CYVSCROLL = 20, // 0x00000014
        SM_CXHSCROLL = 21, // 0x00000015
        SM_DEBUG = 22, // 0x00000016
        SM_SWAPBUTTON = 23, // 0x00000017
        SM_CXMIN = 28, // 0x0000001C
        SM_CYMIN = 29, // 0x0000001D
        SM_CXSIZE = 30, // 0x0000001E
        SM_CYSIZE = 31, // 0x0000001F
        SM_CXFRAME = 32, // 0x00000020
        SM_CXSIZEFRAME = 32, // 0x00000020
        SM_CYFRAME = 33, // 0x00000021
        SM_CYSIZEFRAME = 33, // 0x00000021
        SM_CXMINTRACK = 34, // 0x00000022
        SM_CYMINTRACK = 35, // 0x00000023
        SM_CXDOUBLECLK = 36, // 0x00000024
        SM_CYDOUBLECLK = 37, // 0x00000025
        SM_CXICONSPACING = 38, // 0x00000026
        SM_CYICONSPACING = 39, // 0x00000027
        SM_MENUDROPALIGNMENT = 40, // 0x00000028
        SM_PENWINDOWS = 41, // 0x00000029
        SM_DBCSENABLED = 42, // 0x0000002A
        SM_CMOUSEBUTTONS = 43, // 0x0000002B
        SM_SECURE = 44, // 0x0000002C
        SM_CXEDGE = 45, // 0x0000002D
        SM_CYEDGE = 46, // 0x0000002E
        SM_CXMINSPACING = 47, // 0x0000002F
        SM_CYMINSPACING = 48, // 0x00000030
        SM_CXSMICON = 49, // 0x00000031
        SM_CYSMICON = 50, // 0x00000032
        SM_CYSMCAPTION = 51, // 0x00000033
        SM_CXSMSIZE = 52, // 0x00000034
        SM_CYSMSIZE = 53, // 0x00000035
        SM_CXMENUSIZE = 54, // 0x00000036
        SM_CYMENUSIZE = 55, // 0x00000037
        SM_ARRANGE = 56, // 0x00000038
        SM_CXMINIMIZED = 57, // 0x00000039
        SM_CYMINIMIZED = 58, // 0x0000003A
        SM_CXMAXTRACK = 59, // 0x0000003B
        SM_CYMAXTRACK = 60, // 0x0000003C
        SM_CXMAXIMIZED = 61, // 0x0000003D
        SM_CYMAXIMIZED = 62, // 0x0000003E
        SM_NETWORK = 63, // 0x0000003F
        SM_CLEANBOOT = 67, // 0x00000043
        SM_CXDRAG = 68, // 0x00000044
        SM_CYDRAG = 69, // 0x00000045
        SM_SHOWSOUNDS = 70, // 0x00000046
        SM_CXMENUCHECK = 71, // 0x00000047
        SM_CYMENUCHECK = 72, // 0x00000048
        SM_MIDEASTENABLED = 74, // 0x0000004A
        SM_MOUSEWHEELPRESENT = 75, // 0x0000004B
        SM_XVIRTUALSCREEN = 76, // 0x0000004C
        SM_YVIRTUALSCREEN = 77, // 0x0000004D
        SM_CXVIRTUALSCREEN = 78, // 0x0000004E
        SM_CYVIRTUALSCREEN = 79, // 0x0000004F
        SM_CMONITORS = 80, // 0x00000050
        SM_SAMEDISPLAYFORMAT = 81, // 0x00000051
        SM_CXFOCUSBORDER = 83, // 0x00000053
        SM_CYFOCUSBORDER = 84, // 0x00000054
        SM_REMOTESESSION = 4096, // 0x00001000
    }

    public enum SPI : uint
    {
        GETBORDER = 5,
        GETKEYBOARDSPEED = 10, // 0x0000000A
        ICONHORIZONTALSPACING = 13, // 0x0000000D
        SETSCREENSAVEACTIVE = 17, // 0x00000011
        SETDESKWALLPAPER = 20, // 0x00000014
        GETKEYBOARDDELAY = 22, // 0x00000016
        SETKEYBOARDDELAY = 23, // 0x00000017
        ICONVERTICALSPACING = 24, // 0x00000018
        GETICONTITLEWRAP = 25, // 0x00000019
        GETMENUDROPALIGNMENT = 27, // 0x0000001B
        SETMENUDROPALIGNMENT = 28, // 0x0000001C
        SETDOUBLECLICKTIME = 32, // 0x00000020
        GETDRAGFULLWINDOWS = 38, // 0x00000026
        GETNONCLIENTMETRICS = 41, // 0x00000029
        GETICONMETRICS = 45, // 0x0000002D
        GETWORKAREA = 48, // 0x00000030
        GETHIGHCONTRAST = 66, // 0x00000042
        SETHIGHCONTRAST = 67, // 0x00000043
        GETKEYBOARDPREF = 68, // 0x00000044
        GETANIMATION = 72, // 0x00000048
        GETFONTSMOOTHING = 74, // 0x0000004A
        SETLOWPOWERACTIVE = 85, // 0x00000055
        GETDEFAULTINPUTLANG = 89, // 0x00000059
        GETSNAPTODEFBUTTON = 95, // 0x0000005F
        GETMOUSEHOVERWIDTH = 98, // 0x00000062
        GETMOUSEHOVERHEIGHT = 100, // 0x00000064
        GETMOUSEHOVERTIME = 102, // 0x00000066
        GETWHEELSCROLLLINES = 104, // 0x00000068
        GETMENUSHOWDELAY = 106, // 0x0000006A
        GETMOUSESPEED = 112, // 0x00000070
        GETACTIVEWINDOWTRACKING = 4096, // 0x00001000
        GETMENUANIMATION = 4098, // 0x00001002
        GETCOMBOBOXANIMATION = 4100, // 0x00001004
        GETLISTBOXSMOOTHSCROLLING = 4102, // 0x00001006
        GETGRADIENTCAPTIONS = 4104, // 0x00001008
        GETKEYBOARDCUES = 4106, // 0x0000100A
        SETKEYBOARDCUES = 4107, // 0x0000100B
        GETHOTTRACKING = 4110, // 0x0000100E
        GETMENUFADE = 4114, // 0x00001012
        GETSELECTIONFADE = 4116, // 0x00001014
        GETTOOLTIPANIMATION = 4118, // 0x00001016
        GETFLATMENU = 4130, // 0x00001022
        GETDROPSHADOW = 4132, // 0x00001024
        GETUIEFFECTS = 4158, // 0x0000103E
        GETCLIENTAREAANIMATION = 4162, // 0x00001042
        SETCLIENTAREAANIMATION = 4163, // 0x00001043
        GETACTIVEWNDTRKTIMEOUT = 8194, // 0x00002002
        GETCARETWIDTH = 8198, // 0x00002006
        GETFONTSMOOTHINGTYPE = 8202, // 0x0000200A
        GETFONTSMOOTHINGCONTRAST = 8204, // 0x0000200C
    }

    public delegate bool MonitorEnumerator(nint monitor, Gdi32.HDC hdc, nint lprcMonitor, nint lParam);

    #region SendMessage

    /// <summary>Отправка сообщения окну</summary>
    /// <param name="hWnd">Дескриптор окна</param>
    /// <param name="Msg">Сообщение</param>
    /// <param name="wParam">Старший параметр</param>
    /// <param name="lParam">Младший параметр</param>
    /// <returns></returns>
    [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = false)]
    public static extern nint SendMessage(nint hWnd, WM Msg, nint wParam, nint lParam);

    #endregion

    #region PostMessage

    [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern nint PostMessage(nint hWnd, WM Msg, nint wParam, nint lParam);

    #endregion

    /// <summary>Число символов текста окна</summary>
    /// <param name="hWnd">Дескриптор окна</param>
    /// <returns>Число символов текста окна</returns>
    [DllImport(FileName, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetWindowTextLength(nint hWnd);

    /// <summary>Получить текст окна</summary>
    /// <param name="hWnd">Дескриптор окна</param>
    /// <param name="lpString">Текст</param>
    /// <param name="nMaxCount">Число символов</param>
    /// <returns>Текст окна</returns>
    [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(nint hWnd, StringBuilder lpString, uint nMaxCount);

    [DllImport(FileName, SetLastError = true)]
    public static extern int EnumWindows(EnumWindowProc hWnd, nint lParam);

    /// <summary>Установить текст окна</summary>
    /// <param name="hWnd">Дескриптор окна</param>
    /// <param name="lpString">Текст окна</param>
    /// <returns>Истина, если удалось</returns>
    [DllImport(FileName, SetLastError = true)]
    public static extern bool SetWindowText(nint hWnd, string lpString);

    [DllImport(FileName, SetLastError = true)]
    public static extern bool GetWindowRect(nint hWnd, ref RECT lpRect);

    /// <summary>
    /// Функция MoveWindow изменяет позицию и габариты определяемого окна. Для окна верх-него уровня, позиция и 
    /// габариты - относительно левого верхнего угла экрана. Для дочернего окна, они - относительно левого верхнего 
    /// угла рабочей области родительского окна.
    /// </summary>
    /// <param name="hWnd">Идентификатор окна</param>
    /// <param name="X">Положение левого верхнего угла окна по оси X</param>
    /// <param name="Y">Положение левого верхнего угла окна по оси Y</param>
    /// <param name="nWidth">Ширина окна</param>
    /// <param name="nHeight">Высота окна</param>
    /// <param name="bRepaint">Определяет, должно ли окно быть перекрашено. Если этот параметр - ИСТИНА (TRUE), 
    /// окно принимает сообщение WM_PAINT. Если параметр - ЛОЖЬ(FALSE), никакого перекрашивания какого-либо сорта 
    /// не происходит. Это применяется к рабочей области, нерабочей области (включая строку заголовка и линейки 
    /// прокрутки) и любой части родительского окна, раскрытого в результате перемещения дочернего окна. 
    /// Если этот параметр - ЛОЖЬ(FALSE), прикладная программа должна явно аннулировать или перерисовать любые 
    /// части окна и родительского окна, которые нуждаются в перерисовке.</param>
    /// <returns>Если функция завершилась успешно, возвращается значение отличное от нуля. Если функция потерпела 
    /// неудачу, возвращаемое значение - ноль</returns>
    /// <remarks>Если параметр bRepaint - ИСТИНА (TRUE), Windows посылает сообщение WM_PAINT оконной процедуре 
    /// немедленно после перемещения окна (то есть функция MoveWindow вызывает функцию UpdateWindow). 
    /// Если bRepaint - ЛОЖЬ(FALSE), Windows помещает сообщение WM_PAINT в очередь сообщений, связанную с окном. 
    /// Цикл сообщений посылает сообщение WM_PAINT только после диспетчеризации всех других сообщений в очереди. 
    /// Функция MoveWindow посылает в окно сообщения WM_WINDOWPOSCHANGING, WM_WINDOWPOSCHANGED, 
    /// WM_MOVE, WM_SIZE и WM_NCCALCSIZE.</remarks>

    [DllImport(FileName, SetLastError = true)]
    public static extern bool MoveWindow(nint hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport(FileName, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(nint hWnd, nint hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

    [DllImport(FileName, EntryPoint = "ReleaseDC")]
    public static extern nint ReleaseDC(nint hWnd, nint hDc);

    [DllImport(FileName, EntryPoint = "GetWindowDC")]
    public static extern nint GetWindowDC(nint hWnd);

    [DllImport(FileName)]
    public static extern nint GetDesktopWindow();

    [DllImport(FileName)]
    public static extern int GetSystemMetrics(SystemMetric nIndex);

    [DllImport("User32.dll")]
    public static extern bool GetMonitorInfo(nint hMonitor, [In, Out] ref MonitorInfoExW lpmi);

    [DllImport(FileName)]
    public static extern bool EnumDisplayMonitors(nint hdc, nint lprcClip, MonitorEnumerator lpfnEnum, nint dwData);

    [DllImport(FileName)]
    public static extern nint MonitorFromPoint(Point pt, MonitorInfo dwFlags);

    [DllImport(FileName)]
    public static extern nint MonitorFromRect([In] ref RECT lprc, MonitorInfo dwFlags);

    /// <summary>Получить дескриптор монитора для указанного дескриптора окна</summary>
    /// <param name="hwnd">Дескриптор окна</param>
    /// <param name="dwFlags">Варианты результата в случае неудачи</param>
    /// <returns>Дескриптор монитора</returns>
    [DllImport(FileName)]
    public static extern nint MonitorFromWindow(nint hwnd, MonitorInfo dwFlags = MonitorInfo.DEFAULTTONULL);

    [DllImport(FileName, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref RECT pvParam, uint fWinIni);

    [DllImport(FileName)]
    public static extern bool GetClientRect(nint hWnd, out RECT lpRect);

    [DllImport(FileName)]
    public static extern nint MonitorFromWindow(nint hwnd, uint dwFlags);
}
