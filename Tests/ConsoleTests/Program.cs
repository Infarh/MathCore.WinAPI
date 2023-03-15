using System.Drawing;
using System.Drawing.Imaging;

using MathCore.WinAPI.pInvoke;
using MathCore.WinAPI.Infrastructure.Extensions;

using Rectangle = System.Drawing.Rectangle;

var monitor = Screen.PrimaryScreen;

var monitor_handle = monitor.Handle;

var pp = SHCore.GetScalePercentForMonitor(monitor_handle, out var scale);

var paint = Window.Find(w => w.Text.Contains("paint", StringComparison.OrdinalIgnoreCase)).First();

var bmp = (Bitmap)paint.GetImage(/*new(895, 793, 265, 252)*/);

bmp.Save("paint.bmp");

using(var f_bmp = new FBitmap(bmp, ImageLockMode.ReadOnly))
{
    var a = 0;
    var r = 0;
    var g = 0;
    var b = 0;
    var count = 0;
    var (width, height) = (bmp.Width, bmp.Height); 
    for(var i = 0; i < height; i++)
        for(var j = 0; j <  width; j++)
        {
            b += f_bmp[i, j][0];
            g += f_bmp[i, j][1];
            r += f_bmp[i, j][2];
            a += f_bmp[i, j][3];
            count++;
        }

    var fa = (double)a / count / 256;
    var fr = (double)r / count / 256;
    var fg = (double)g / count / 256;
    var fb = (double)b / count / 256;
}

var img_file = new FileInfo("paint.bmp");

img_file.Execute();

Console.ReadLine();

var bmp2 = (Bitmap)paint.GetImage(/*new(895, 793, 265, 252)*/);

bmp2.Save("paint2.bmp");

var img2_file = new FileInfo("paint2.bmp");
img2_file.Execute();


public unsafe class FBitmap : IDisposable
{
    private Bitmap _bmp;
    private ImageLockMode _lockmode;
    private int _PixelLength;

    private Rectangle _rect;
    private BitmapData _Data;
    private byte* _BufferPtr;

    public int Width { get => _bmp.Width; }
    public int Height { get => _bmp.Height; }
    public PixelFormat PixelFormat { get => _bmp.PixelFormat; }

    public FBitmap(Bitmap bmp, ImageLockMode lockMode)
    {
        _bmp = bmp;
        _lockmode = lockMode;

        _PixelLength = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
        _rect = new Rectangle(0, 0, Width, Height);
        _Data = bmp.LockBits(_rect, lockMode, PixelFormat);
        _BufferPtr = (byte*)_Data.Scan0.ToPointer();
    }

    public Span<byte> this[int x, int y]
    {
        get
        {
            var pixel = _BufferPtr + x * _Data.Stride + y * _PixelLength;
            return new Span<byte>(pixel, _PixelLength);
        }
        set
        {
            value.CopyTo(this[x, y]);
        }
    }

    public void Dispose()
    {
        _bmp.UnlockBits(_Data);
    }
}