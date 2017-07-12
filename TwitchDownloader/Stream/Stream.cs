using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDownloader.Stream
{
    public class Stream
    {
        public TwitchDownloader.Playlist Playlist;

        protected readonly string ChannelId;
        protected readonly string OAuthToken;

        public Stream(string channelId, string oAuthToken)
        {
            ChannelId = channelId;
            OAuthToken = oAuthToken;
            Playlist = new Playlist(ChannelId, OAuthToken);
        }
    }
}
