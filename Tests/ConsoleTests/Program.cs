
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

var eve_process = Process.GetProcessById(28696);

var window = new Window(eve_process.MainWindowHandle);


var bmp = GetImage(window);



Console.WriteLine("End.");
//Console.ReadLine();

static Bitmap GetImage(Window wnd)
{
    var rect = wnd.Rectangle;

    var image = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppPArgb);
    using var graphic = Graphics.FromImage(image);
    var graphic_handle = graphic.GetHdc();

    User32.PrintWindow(wnd.Handle, graphic_handle, 0);

    graphic.ReleaseHdc(graphic_handle);

    var bmp_file = new FileInfo("test.bmp");
    using (var stream = bmp_file.Create())
        image.Save(stream, ImageFormat.Bmp);



    bmp_file.Execute();

    return image;
}