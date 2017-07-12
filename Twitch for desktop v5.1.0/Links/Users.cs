using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Links
{
    public class Users
    {
        public static string getUsetByID { get; } = "https://api.twitch.tv/kraken/users/{ID}?oauth_token={T}&api_version=5";
        public static string isFollowing { get; } = "https://api.twitch.tv/kraken/users/{U}/follows/channels/{ID}?oauth_token={T}&api_version=5";
        public static string isLive { get; } = "https://api.twitch.tv/kraken/streams/{ID}?oauth_token={T}&api_version=5";
        public static string follows { get; } = "https://api.twitch.tv/kraken/users/{U}/follows/channels?oauth_token={T}&api_version=5&limit={L}&offset={O}";

        public static string GetUserByID(long id)
        {
            return getUsetByID
                .Replace("{T}", Settings.oauthToken)
                .Replace("{ID}", id.ToString());
        }
        public static string IsFollowing(long id)
        {
            return isFollowing
                .Replace("{T}", Settings.oauthToken)
                .Replace("{U}", Forms.Home.Channel._id.ToString())
                .Replace("{ID}", id.ToString());
        }

        public static string IsLive(long id)
        {
            return isLive
                .Replace("{T}", Settings.oauthToken)
                .Replace("{ID}", id.ToString());
        }
        public static string Follows(long id, int limit, int offset)
        {
            return follows
                .Replace("{T}", Settings.oauthToken)
                .Replace("{U}", id.ToString())
                .Replace("{L}", limit.ToString())
                .Replace("{O}", offset.ToString());
        }
    }
}
