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
}
