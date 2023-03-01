
using MathCore.WinAPI.pInvoke;

var monitor = Screen.PrimaryScreen;

var monitor_handle = monitor.Handle;

var pp = SHCore.GetScalePercentForMonitor(monitor_handle, out var scale);

var paint = Window.Find(w => w.Text.Contains("paint.net")).First();

var img = paint.GetImage();

img.Save("paint.bmp");

var img_file = new FileInfo("paint.bmp");

img_file.Execute();
