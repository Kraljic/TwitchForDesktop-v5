using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Links
{
    class Token
    {
        public static string validToken { get; } = "https://api.twitch.tv/kraken?oauth_token={T}&api_version=5";
        public static string logout { get; } = "http://kraljic.xyz/twitch/revoke.php?oauth_token={T}";

        public static string GetNewToken { get; } = "http://kraljic.xyz/twitch/desktop/?force_verify=false";
        public static string TokenRedirectPage { get; } = "http://kraljic.xyz/twitch/done.php";

        public static string ValidToken(string oauthToken)
        {
            return validToken.Replace("{T}", oauthToken);
        }

        public static string Logout()
        {
            return logout.Replace("{T}", Settings.oauthToken);
        }
    }
}
