using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchChat.Properties;

namespace TwitchChat.Links
{
    class Token
    {
        public static string validToken { get; } = "https://api.twitch.tv/kraken?oauth_token={T}&api_version=5";

        public static string ValidToken(string oauthToken)
        {
            return validToken.Replace("{T}", oauthToken);
        }
    }
}
