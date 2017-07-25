using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDownloader
{
    public partial class Playlist
    {
        protected void ParsePlaylist(string playlistString)
        {
            Videos = new List<VideoSorce>();
            if (playlistString == null)
                return;

            var lines = playlistString.Split('\n');
            var tmpVideo = new VideoSorce();

            foreach (var s in lines)
            {
                if (s.Trim().Length <= 0)
                    continue;

                if (s[0] == '#')
                {
                    if (!s.Contains("#EXT-X-STREAM-INF:"))
                        continue;

                    // get badwidth
                    tmpVideo.Bandwidth = long.Parse(getAttribute(s, "BANDWIDTH"));

                    // get resolution
                    tmpVideo.Resolution = getAttribute(s, "RESOLUTION");

                    // get id
                    tmpVideo.Id = getAttribute(s, "VIDEO");
                }
                else if (s.Trim().IndexOf("http") == 0)
                {
                    // get url
                    tmpVideo.Url = s;
                    if (tmpVideo.Id == "audio_only")
                        tmpVideo.Resolution = "audio";
                    Videos.Add(tmpVideo);
                    tmpVideo = new VideoSorce();
                }
            }
        }

        private static string getAttribute(string info, string key)
        {
            int sIndex = info.IndexOf(key) + key.Length + 1,
                eIndex = info.IndexOf(",", sIndex);

            if (eIndex == -1)
                eIndex = info.Length - 1;
            return info.Substring(sIndex, eIndex - sIndex).Replace("\"", "");
        }
    }
}
