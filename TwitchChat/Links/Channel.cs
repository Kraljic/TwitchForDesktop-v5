using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChat.Links
{
    public class Channel
    {
        public static string getChannel { get; } = "https://api.twitch.tv/kraken/channel?oauth_token={T}&api_version=5";
        public static string getChannelByID { get; } = "https://api.twitch.tv/kraken/channels/{C}?oauth_token={T}&api_version=5";

        public static string GetChannel ()
        {
            return getChannel.Replace("{T}", Environment.GetEnvironmentVariable("oauthToken"));
        }
        public static string GetChannelByID(long id)
        {
            return getChannelByID
                .Replace("{T}", Environment.GetEnvironmentVariable("oauthToken"))
                .Replace("{C}", id.ToString()) ;
        }
    }
}
