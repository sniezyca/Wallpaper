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
            var bd = new Dowloader(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

            bd.SaveWallpaper();


            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Koala.jpg";

            

            


            SetImageAsWallpaper(bd.FilePath);

            //Console.Out.WriteLine(bd.FilePath);

            System.Threading.Thread.Sleep(500);
            File.Delete(bd.FilePath);

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
