using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Twitch_for_desktop_v5_1_0.Forms;

namespace Twitch_for_desktop_v5_1_0.Kraken.Stream
{
    public class DownloadPlaylist
    {
        private const string TokenLink =
            "https://api.twitch.tv/api/channels/{ID}/access_token?oauth_token={O}";
        private const string PlaylistLink = "http://usher.twitch.tv/api/channel/hls/{ID}?nauthsig={SIG}&nauth={TOKEN}&allow_source=true";

        public static string Download(string name)
        {
            try
            {
                var token = getToken(name);
                string url = PlaylistLink.Replace("{ID}", name)
                    .Replace("{SIG}", token.sig)
                    .Replace("{TOKEN}", token.token);
                
                return Links.Web.DownloadString(url);
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        private static JSON getToken(string name)
        {
            string url = TokenLink.Replace("{ID}", name)
                .Replace("{O}", Settings.oauthToken);
            string jsonString = Links.Web.DownloadString(url);
            return new JavaScriptSerializer().Deserialize<JSON>(jsonString);
        }

        public class JSON
        {
            public string token { get; set; }
            public string sig { get; set; }
        }
    }
}
