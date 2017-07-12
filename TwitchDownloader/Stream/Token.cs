using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TwitchDownloader.Stream
{
    internal class Token : TwitchDownloader.Token
    {
        private const string TokenLink = "https://api.twitch.tv/api/channels/{ID}/access_token?oauth_token={O}";
        
        public static Json GetToken(string channelName, string oAuthToken)
        {
            var url = TokenLink
                .Replace("{ID}", channelName)
                .Replace("{O}", oAuthToken);
            var jsonString = new WebClient().DownloadString(url);
            return new JavaScriptSerializer().Deserialize<Json>(jsonString);
        }
    }
}
