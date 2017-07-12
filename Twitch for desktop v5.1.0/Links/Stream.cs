using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Links
{
    class Stream
    {
        public static string followed { get; } = "https://api.twitch.tv/kraken/streams/followed?oauth_token={T}&api_version=5&limit={L}&offset={O}";
        public static string all { get; } = "https://api.twitch.tv/kraken/streams?oauth_token={T}&api_version=5&limit={L}&offset={O}";
        public static string game { get; } = "https://api.twitch.tv/kraken/streams?oauth_token={T}&api_version=5&game={G}&limit={L}&offset={O}";
        public static string featured { get; } = "https://api.twitch.tv/kraken/streams/featured?oauth_token={T}&api_version=5&limit={L}&offset={O}";
        public static string channel { get; } = "https://api.twitch.tv/kraken/streams/{ID}?oauth_token={T}&api_version=5";



        public static string Followed(int limit, long offset)
        {
            return followed.Replace("{T}", Settings.oauthToken)
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString());
        }
        public static string All(int limit, long offset)
        {
            return all.Replace("{T}", Settings.oauthToken)
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString());
        }
        public static string Game(int limit, long offset, string myGame)
        {
            return game.Replace("{T}", Settings.oauthToken)
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString())
                .Replace("{G}", myGame);
        }
        public static string Featured(int limit, long offset)
        {
            return featured.Replace("{T}", Settings.oauthToken)
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString());
        }
        public static string Channel(long channelId)
        {
            return channel.Replace("{T}", Settings.oauthToken)
                .Replace("{ID}", channelId.ToString());
        }
    }
}
