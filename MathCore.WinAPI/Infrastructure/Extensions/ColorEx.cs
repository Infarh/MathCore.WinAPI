using System.Drawing;

namespace MathCore.WinAPI.Infrastructure.Extensions;

internal static class ColorEx
{
    public static void Deconstruct(this Color color, out byte R, out byte G, out byte B) => (R, G, B) = (color.R, color.G, color.B);
    public static void Deconstruct(this Color color, out byte A, out byte R, out byte G, out byte B) => (A, R, G, B) = (color.A, color.R, color.G, color.B);
}
