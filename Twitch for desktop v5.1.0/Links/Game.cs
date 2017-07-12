using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Links
{
    class Game
    {
        public static string top { get; } = "https://api.twitch.tv/kraken/games/top?oauth_token={T}&api_version=5&limit={L}&offset={O}";

        public static string Top(int limit, long offset)
        {
            return top.Replace("{T}", Settings.oauthToken)
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString());
        }
    }
}
