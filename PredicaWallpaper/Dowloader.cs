using System;
using System.Net;
using System.Xml;
using System.IO;


namespace PredicaWallpaper
{
    public class Dowloader
    {
        public Dowloader(string path)
        {
            // specify where image should be saved
            string name = "BingWallpaper_" + DateTime.Now.ToString("dd_MM_yyyy")+".jpg" ;
            FilePath = Path.Combine(path,name);                     
        }
        
        public string FilePath { get; set;}

        
        public void SaveWallpaper()
        {
            try
            {
                string url = string.Format(@"http://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=1&mkt=en-WW");

                var webclient = new WebClient();

                // download data from adress and return byte array
                byte[] buffer = webclient.DownloadData(url);

                // load into xml file
                var xml = new XmlDocument();
                xml.Load(new MemoryStream(buffer));

                // get the url of image
                string snode = xml.SelectSingleNode(@"/images/image/urlBase/text()").Value;                
                string imuri = string.Format(@"http://www.bing.com{0}_1920x1080.jpg", snode);
                
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
