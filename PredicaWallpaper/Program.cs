﻿using System;
using System.IO;
using Microsoft.Win32;
using System.Reflection;

namespace PredicaWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            // create folder for wallpapers
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Tapety Bing";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            // download and save wallpaper
            var dow = new Dowloader(folder);
            dow.SaveWallpaper();

            // set saved image as wallpaper    
            var wp = new WindowsWallpaper();
            wp.Set(dow.FilePath);

            Autostart();
            
                       
        }

        //private static void SetImageAsWallpaper (string path)
        //{
        //    try
        //    {
        //        var wallpaper = (IDesktopWallpaper)(new DesktopWallpaperClass());
        //
        //        wallpaper.SetWallpaper(null, path);
        //    }
        //    catch
        //    {
        //        Environment.Exit(0);
        //    }
        //                
        // }
        public static void Autostart()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("My app", Assembly.GetExecutingAssembly().Location);

        }
        
    }
}
