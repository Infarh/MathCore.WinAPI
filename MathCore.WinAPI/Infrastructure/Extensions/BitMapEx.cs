using System.Drawing;
using System.Drawing.Imaging;

namespace MathCore.WinAPI.Infrastructure.Extensions;

public static class BitMapEx
{
    public static FastBitmap AsFastBitmap(this Bitmap bmp, ImageLockMode LockMode = ImageLockMode.ReadWrite) => new(bmp, LockMode);
}
