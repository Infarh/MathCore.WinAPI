using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MathCore.WinAPI.pInvoke
{
    /// <summary>Точкa</summary>
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X, Y;
        public POINT(int x, int y) { X = x; Y = y; }
        public static implicit operator Point(POINT p) => new Point(p.X, p.Y);
        public static implicit operator POINT(Point p) => new POINT(p.X, p.Y);

        public override string ToString() => $"({X}:{Y})";
    }

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

        #region Operator overloads

        public static implicit operator Rectangle(RECT rect) => rect.ToRectangle();
        public static implicit operator RECT(Rectangle rect) => FromRectangle(rect);

        #endregion
    }
}
