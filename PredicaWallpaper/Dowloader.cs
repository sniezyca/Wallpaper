using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;

namespace PredicaWallpaper
{
    public class Dowloader
    {
        public Dowloader(string path)
        {
            string name = "wallpaper.jpg";
            FilePath = Path.Combine(path,name);
           
        }
        
        public string FilePath { get; set;}

        
        public void SaveWallpaper()
        {
            try
            {
                string url = string.Format(@"http://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=1&mkt=en-WW");

                var webclient = new WebClient();

                // downloads data from adress and returns byte array
                byte[] buffer = webclient.DownloadData(url);

                // load into xml file
                var xml = new XmlDocument();
                xml.Load(new MemoryStream(buffer));

                string snode = xml.SelectSingleNode(@"/images/image/urlBase/text()").Value;
                
                string imuri = string.Format(@"http://www.bing.com{0}_1920x1080.jpg", snode);

                //string saveSpot = Path.Combine(FolderPath, Path.GetFileName(new Uri(imuri).LocalPath));

                DownloadImage(FilePath, imuri);

            }
            catch (Exception)
            {
                Environment.Exit(0);
            }


        }

        public void DownloadImage(string saveSpot, string downloadSpot)
        {
            try
            {
                var client = new WebClient();

                client.DownloadFile(downloadSpot, saveSpot);

            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
        }


        
    }
    
}
