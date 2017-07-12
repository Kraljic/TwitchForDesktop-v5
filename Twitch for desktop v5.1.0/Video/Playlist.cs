using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Video
{
    public class Playlist
    {
        public List<Video> Videos { get; private set; }

        public class Video
        {
            public string Id { get; set; }
            public string Resolution { get; set; }
            public long Bandwidth { get; set; }
            public string Url { get; set; }

            public override string ToString()
            {
                return Resolution + " (" + Id + ")";
            }
        }

        public Playlist(string playlist)
        {
            Videos = new List<Video>();
            if (playlist == null)
                return;

            var lines = playlist.Split('\n');
            var tmpVideo = new Video();

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
                    tmpVideo.Url = s;
                    Videos.Add(tmpVideo);
                    tmpVideo = new Video();
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
