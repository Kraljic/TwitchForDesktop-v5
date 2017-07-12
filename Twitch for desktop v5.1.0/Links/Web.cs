using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Links
{
    public class Web
    {
        public static string DownloadString(string URL)
        {
            try
            {
                return (new WebClient()).DownloadString(URL);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Bitmap DownloadImage(string URL)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    using (var s = wc.OpenRead(URL))
                    {
                        return new Bitmap(s);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool PushRequest(string URL, byte[] data)
        {
            try
            {
                (new WebClient()).UploadData(URL, "PUSH", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool PutRequest(string URL, byte[] data = null)
        {
            try
            {
                byte[] dt = (new WebClient()).UploadData(URL, "PUT", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteRequest(string URL, byte[] data = null)
        {
            try
            {
                byte[] dt = (new WebClient()).UploadData(URL, "DELETE", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
