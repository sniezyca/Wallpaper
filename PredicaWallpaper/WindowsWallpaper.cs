using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace PredicaWallpaper
{
   
    class WindowsWallpaper
    {
        
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        
        public void Set(string path)
        {
            
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            
            SystemParametersInfo(SPI_SETDESKWALLPAPER,0,path,SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}
