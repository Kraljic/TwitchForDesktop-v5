using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Links
{
    public class VOD
    {
        public static string all { get; } =
            "https://api.twitch.tv/kraken/channels/{ID}/videos?oauth_token={T}&api_version=5&limit={L}&offset={O}";
        public static string highlight { get; } =
            "https://api.twitch.tv/kraken/channels/{ID}/videos?oauth_token={T}&api_version=5&limit={L}&offset={O}&broadcast_type=highlight";
        public static string archive { get; } =
            "https://api.twitch.tv/kraken/channels/{ID}/videos?oauth_token={T}&api_version=5&limit={L}&offset={O}&broadcast_type=archive";


        public static string All(long id, int limit, long offset)
        {
            return all.Replace("{T}", Settings.oauthToken)
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString())
                .Replace("{ID}", id.ToString());
        }
        public static string Highlight(long id, int limit, long offset)
        {
            return highlight.Replace("{T}", Settings.oauthToken)
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString())
                .Replace("{ID}", id.ToString());
        }
        public static string Archive(long id, int limit, long offset)
        {
            return archive.Replace("{T}", Settings.oauthToken)
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString())
                .Replace("{ID}", id.ToString());
        }
    }
}
