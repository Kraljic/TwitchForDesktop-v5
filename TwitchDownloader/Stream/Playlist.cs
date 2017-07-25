using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDownloader.Stream
{
    public class Playlist : TwitchDownloader.Playlist
    {
        private const string PlaylistLink = "http://usher.twitch.tv/api/channel/hls/{ID}?nauthsig={SIG}&nauth={TOKEN}&allow_source=true&allow_audio_only=true";

        public Playlist(string channelId, string oAuthToken)
        {
            var token = Token.GetToken(channelId, oAuthToken);
            var url = PlaylistLink.Replace("{ID}", channelId)
                .Replace("{SIG}", token.sig)
                .Replace("{TOKEN}", token.token);

            var playlistData = new WebClient().DownloadString(url);
            ParsePlaylist(playlistData);
        }
    }
}
