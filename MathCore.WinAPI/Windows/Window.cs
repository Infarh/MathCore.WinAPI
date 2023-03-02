using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

using MathCore.WinAPI.pInvoke;

namespace MathCore.WinAPI.Windows;

public class Window
{
    private static void ThrowLastWin32Error() => Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

    public static IntPtr SendMessage(IntPtr Handle, WM Message, IntPtr wParam, IntPtr lParam) =>
        User32.SendMessage(Handle, Message, wParam, lParam);

    public static Window[] Find(Func<Window, bool> Selector)
    {
        var result = new List<Window>();

        bool WindowSelector(IntPtr hWnd, IntPtr lParam)
        {
            var window = new Window(hWnd);
            if (Selector(window))
                result.Add(window);
            return true;
        }

        User32.EnumWindows(WindowSelector, IntPtr.Zero);

        return result.ToArray();
    }

    /// <summary>Идентификатор окна</summary>
    public IntPtr Handle { get; }

    /// <summary>Текст (заголовок) окна</summary>
    public string Text
    {
        get => GetWindowText();
        set
        {
            if (!SetWindowTest(value))
                ThrowLastWin32Error();
        }
    }

    public static RECT GetRect(nint Handle)
    {
        var rect = new RECT();
        if (!User32.GetWindowRect(Handle, ref rect))
            ThrowLastWin32Error();
        return rect;
    }

    public Rectangle Rectangle
    {
        get => GetRect(Handle);
        set
        {
            if (!User32.MoveWindow(Handle, value.Left, value.Top, value.Width, value.Height, bRepaint: true))
                ThrowLastWin32Error();
        }
    }

    /// <summary>Положение левого верхнего угла окна</summary>
    public Point Location { get => Rectangle.Location; set => Rectangle = new Rectangle(value, Rectangle.Size); }

    /// <summary>Положение левого верхнего угла окна по горизонтали</summary>
    public int X { get => Location.X; set => Location = new Point(value, Location.Y); }

    /// <summary>Положение левого верхнего угла окна по вертикали</summary>
    public int Y { get => Location.Y; set => Location = new Point(Location.X, value); }

    /// <summary>Размеры окна</summary>
    public Size Size { get => Rectangle.Size; set => Rectangle = new Rectangle(Location, value); }

    /// <summary>ШИрина окна</summary>
    public int Width { get => Rectangle.Width; set => Size = new Size(value, Height); }

    /// <summary>Высота окна</summary>
    public int Height { get => Rectangle.Height; set => Size = new Size(Width, value); }

    public Window(IntPtr Handle) => this.Handle = Handle;

    public IntPtr SendMessage(WM Message, IntPtr wParam, IntPtr lParam) => SendMessage(Handle, Message, wParam, lParam);
    public IntPtr SendMessage(WM Message) => SendMessage(Message, IntPtr.Zero, IntPtr.Zero);

    public IntPtr PostMessage(WM Message, IntPtr wParams, IntPtr lParams) => User32.PostMessage(Handle, Message, wParams, lParams);

    private string GetWindowText()
    {
        var buffer = new StringBuilder(User32.GetWindowTextLength(Handle) + 1);
        if (buffer.Capacity > 0)
            User32.GetWindowText(Handle, buffer, (uint)buffer.Capacity);
        return buffer.ToString();
    }

    private bool SetWindowTest(string text) => User32.SetWindowText(Handle, text);

    public void Click()
    {
        PostMessage(WM.LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
        PostMessage(WM.LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
    }

    public void Click(Point Point)
    {
        var pPoint = GCHandle.Alloc(Point);
        try
        {
            var lParam = GCHandle.ToIntPtr(pPoint);
            PostMessage(WM.LBUTTONDOWN, IntPtr.Zero, lParam);
            PostMessage(WM.LBUTTONUP, IntPtr.Zero, lParam);
        }
        finally
        {
            pPoint.Free();
        }
    }

    /// <summary>Имитация нажатия кнопки мышки в окне</summary>
    /// <param name="X">Положение указателя мыши по горизонтали</param>
    /// <param name="Y">Положение указателя мыши по вертикали</param>
    public void Click(int X, int Y) => Click(new Point(X, Y));

    public bool SetTopMost() =>
        User32.SetWindowPos(Handle, 
            InsertAfterEnumHWND.TopMost,
            0, 0, 0, 0,
            SetWindowPosFlags.IgnoreMove | SetWindowPosFlags.IgnoreResize);

    public static Bitmap GetImage(nint handle)
    {
        var hdc_src = User32.GetWindowDC(handle);

        var (width, height) = GetRect(handle);

        var hdc_dest = Gdi32.CreateCompatibleDC(hdc_src);

        var h_bitmap = Gdi32.CreateCompatibleBitmap(hdc_src, width, height);

        var hOld = Gdi32.SelectObject(hdc_dest, h_bitmap);

        Gdi32.BitBlt(hdc_dest, 0, 0, width, height, hdc_src, 0, 0, Gdi32.SRCCOPY);

        Gdi32.SelectObject(hdc_dest, hOld);

        Gdi32.DeleteDC(hdc_dest);
        User32.ReleaseDC(handle, hdc_src);

        var img = Image.FromHbitmap(h_bitmap);

        Gdi32.DeleteObject(h_bitmap);

        return img;
    }

    public static Bitmap GetImage(nint handle, Rectangle ImageRect)
    {
        var hdc_src = User32.GetWindowDC(handle);

        var (width, height) = (ImageRect.Width, ImageRect.Height);

        var hdc_dest = Gdi32.CreateCompatibleDC(hdc_src);

        var h_bitmap = Gdi32.CreateCompatibleBitmap(hdc_src, width, height);

        var h_old = Gdi32.SelectObject(hdc_dest, h_bitmap);

        Gdi32.BitBlt(hdc_dest, 0, 0, width, height, hdc_src, ImageRect.Left, ImageRect.Top, Gdi32.SRCCOPY);

        Gdi32.SelectObject(hdc_dest, h_old);

        Gdi32.DeleteDC(hdc_dest);
        User32.ReleaseDC(handle, hdc_src);

        var img = Image.FromHbitmap(h_bitmap);

        Gdi32.DeleteObject(h_bitmap);

        return img;
    }

    public Bitmap GetImage() => GetImage(Handle);

    public Bitmap GetImage(Rectangle ImageRect) => GetImage(Handle, ImageRect);

    public static IntPtr GetScreenPtr(nint Handle) => User32.MonitorFromWindow(Handle);

    /// <summary>Получить рабочий стол, которому принадлежит окно c указанным идентификатором</summary>
    /// <param name="Handle">Идентификатор проверяемого окна</param>
    /// <returns>Рабочий стол с указанным окном</returns>
    public static Screen? GetScreen(nint Handle)
    {
        var screen_handle = GetScreenPtr(Handle);
        return screen_handle == IntPtr.Zero 
            ? null 
            : new(screen_handle);
    }

    /// <summary>Закрыть окно</summary>
    /// <returns>Истина, если окно закрыто успешно</returns>
    public bool Close() => SendMessage(WM.CLOSE) == IntPtr.Zero;

    public override string ToString() => $"{Text}[hwnd:{Handle}]";
}
