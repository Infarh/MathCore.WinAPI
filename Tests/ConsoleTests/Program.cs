

var paint = Window.Find(w => w.Text.Contains("paint.net")).First();

var img = paint.GetImage();

img.Save("paint.bmp");

var img_file = new FileInfo("paint.bmp");

img_file.Execute();
