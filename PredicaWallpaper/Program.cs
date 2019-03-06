using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PredicaWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            // download and save wallpaper
            var dow = new Dowloader(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            dow.SaveWallpaper();

            // set saved image as wallpaper     
            SetImageAsWallpaper(dow.FilePath);

            // wait for a bit before deleting the picture
            System.Threading.Thread.Sleep(500);
            File.Delete(dow.FilePath);

            // shortcut - change wallpaper for tests
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Koala.jpg";
            //SetImageAsWallpaper(path);
        }

        private static void SetImageAsWallpaper (string path)
        {
            try
            {
                var wallpaper = (IDesktopWallpaper)(new DesktopWallpaperClass());

                wallpaper.SetWallpaper(null, path);
            }
            catch
            {
                Environment.Exit(0);
            }

            
        }
    }
}
