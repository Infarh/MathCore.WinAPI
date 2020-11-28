using System;
using System.Diagnostics;

using MathCore.WinAPI.Windows;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var notepad_process = Process.Start("notepad");

            Console.WriteLine("Ждём...");
            Console.ReadLine();

            //var notepad = Window.Find(w => w.Text.EndsWith("Notepad++"));
            //foreach (var w in notepad)
            //    w.Text = "QWE";


            var window = new Window(notepad_process.MainWindowHandle);
            Console.WriteLine("Текст окна = {0}", window.Text);
            Console.WriteLine("Координаты окна = {0}", window.Rectangle);

            //window.Text = "Hello World!";

            //for (var x = window.X; x < 1692; x += 10)
            //{
            //    window.X = x;
            //    Thread.Sleep(100);
            //}

            //Console.ReadLine();
            //Console.WriteLine("Закрыть!");
            //window.Close();

            Console.WriteLine("Поверх всех окон.");
            window.SetTopMost();
            Console.ReadLine();
            Console.WriteLine("Не поверх всех окон.");

            Console.WriteLine("Завершено.");
            Console.ReadLine();

            //notepad_process.CloseMainWindow();
        }
    }
}
