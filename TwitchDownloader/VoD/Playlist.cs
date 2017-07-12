using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDownloader.VoD
{
    public class Playlist : TwitchDownloader.Playlist
    {
        private const string PlaylistLink = "http://usher.twitch.tv/vod/{ID}?nauthsig={SIG}&nauth={TOKEN}&allow_source=true";

        public Playlist(string vodId, string oAuthToken)
        {
            var token = Token.GetToken(vodId, oAuthToken);
            var url = PlaylistLink.Replace("{ID}", vodId)
                .Replace("{SIG}", token.sig)
                .Replace("{TOKEN}", token.token);

            var playlistData = new WebClient().DownloadString(url);
            ParsePlaylist(playlistData);
        }
    }
}
