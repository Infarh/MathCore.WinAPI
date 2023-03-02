using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace MathCore.WinAPI;

public class FastBitmap : IDisposable
{
    private readonly Bitmap _bmp;
    private readonly BitmapData _Data;
    private readonly nint _Pointer;
    private readonly ImageLockMode _LockMode;
    private byte[] _Bytes;

    public byte[] Bytes
    {
        get => _Bytes;
        set
        {
            if ((_LockMode & ImageLockMode.WriteOnly) != ImageLockMode.WriteOnly)
                throw new InvalidOperationException("Редактирование изображения не поддерживается");

            _Bytes = value;
        }
    }

    public int Depth { get; }

    public Rectangle Rect { get; }

    public int Width => Rect.Width;

    public int Height => Rect.Height;

    public Color this[int x, int y]
    {
        get
        {

            // Get color components count
            var count = Depth / 8;

            var i = (y * Rect.Width + x) * count;

            var pixels = _Bytes;
            if (i > pixels.Length - count)
                throw new IndexOutOfRangeException();

            switch (Depth)
            {
                default: throw new InvalidOperationException();

                case 32:
                    {
                        byte b = pixels[i];
                        byte g = pixels[i + 1];
                        byte r = pixels[i + 2];
                        byte a = pixels[i + 3]; // a
                        return Color.FromArgb(a, r, g, b);
                    }

                case 24:
                    {
                        byte b = pixels[i];
                        byte g = pixels[i + 1];
                        byte r = pixels[i + 2];
                        return Color.FromArgb(r, g, b);
                    }

                case 8:
                    {
                        byte c = pixels[i];
                        return Color.FromArgb(c, c, c);
                    }
            }
        }
        set
        {
            var count = Depth / 8;
            var i = (y * Rect.Width + x) * count;

            var pixels = _Bytes;
            switch (Depth)
            {
                default: throw new InvalidOperationException();

                case 32:
                    (pixels[i + 3], pixels[i + 2], pixels[i + 1], pixels[i]) = value;
                    break;

                case 24:
                    (pixels[i + 2], pixels[i + 1], pixels[i]) = value;
                    break;

                case 8:
                    pixels[i] = (byte)((double)(value.R + value.G + value.B) / (3 * 256));
                    break;
            }
        }
    }

    public FastBitmap(Bitmap bmp, ImageLockMode LockMode = ImageLockMode.ReadWrite)
        : this(bmp, new(default, bmp.Size), LockMode, bmp.PixelFormat)
    {

    }

    public FastBitmap(Bitmap bmp, Rectangle Rect, ImageLockMode LockMode = ImageLockMode.ReadWrite, PixelFormat PixelFormat = PixelFormat.Gdi)
    {
        _bmp = bmp;
        _LockMode = LockMode;
        this.Rect = Rect;
        Depth = Bitmap.GetPixelFormatSize(PixelFormat);
        _Data = bmp.LockBits(Rect, LockMode, PixelFormat);

        var pixels_count = Math.Abs(_Data.Stride) * Rect.Height;
        //var pixels_count = Rect.Width * Rect.Height;

        var step = Depth / 8;
        _Bytes = new byte[pixels_count];
        _Pointer = _Data.Scan0;

        //Marshal.Copy(_Pointer, Bytes, 0, Bytes.Length);

        using var stream = new MemoryStream();
        bmp.Save(stream, ImageFormat.MemoryBmp);
        var data = stream.ToArray();
    }

    public void Dispose()
    {
        if ((_LockMode & ImageLockMode.WriteOnly) == ImageLockMode.WriteOnly)
            Marshal.Copy(Bytes, 0, _Pointer, Bytes.Length);

        _bmp.UnlockBits(_Data);
    }
}
