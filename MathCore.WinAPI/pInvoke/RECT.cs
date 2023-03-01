using System.Drawing;
using System.Runtime.InteropServices;

namespace MathCore.WinAPI.pInvoke;


/// <summary>Прямоугольник</summary>
[Serializable, StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int Left, Top, Right, Bottom;

    public RECT(int Left, int Top, int Right, int Bottom)
    {
        this.Left = Left;
        this.Top = Top;
        this.Right = Right;
        this.Bottom = Bottom;
    }

    public int Height => Bottom - Top;
    public int Width => Right - Left;
    public Size Size => new Size(Width, Height);

    public POINT Location => new POINT(Left, Top);

    public Point Point => new(Left, Top);

    // Handy method for converting to a System.Drawing.Rectangle
    public Rectangle ToRectangle() => Rectangle.FromLTRB(Left, Top, Right, Bottom);

    public static RECT FromRectangle(Rectangle rectangle)
    {
        return new RECT(rectangle.Left, rectangle.Top,
            rectangle.Left + rectangle.Right, rectangle.Top + rectangle.Bottom);
    }

    public override int GetHashCode() =>
        Left ^ ((Top << 13) | (Top >> 0x13))
        ^ ((Width << 0x1a) | (Width >> 6))
        ^ ((Height << 7) | (Height >> 0x19));

    public override string ToString() => $"{Left},{Top},{Right},{Bottom}({Width}x{Height})";

    public void Deconstruct(out int Left, out int Top, out int Right, out int Bottom) =>
        (Left, Top, Right, Bottom) = (this.Left, this.Top, this.Right, this.Bottom);

    public void Deconstruct(out int Width, out int Height) => (Width, Height) = (this.Width, this.Height);

    #region Operator overloads

    public static implicit operator Rectangle(RECT rect) => rect.ToRectangle();
    public static implicit operator RECT(Rectangle rect) => FromRectangle(rect);

    #endregion
}
