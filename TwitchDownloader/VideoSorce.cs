using System.Collections.Generic;

namespace TwitchDownloader
{
    public partial class Playlist
    {
        public List<VideoSorce> Videos { get; internal set; }

        public struct VideoSorce
        {
            public string Id { get; internal set; }
            public string Resolution { get; internal set; }
            public long Bandwidth { get; internal set; }
            public string Url { get; internal set; }

            public override string ToString()
            {
                return Resolution + " (" + Id + ")";
            }
        }
    }
}
