using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Kraken.Stream
{

    public class JSON
    {
        public List<Stream> streams { get; set; }
        public Stream stream { get; set; }

        public class Stream
        {
            public Kraken.Channel channel { get; set; }
            public Preview preview { get; set; }

            public long _id { get; set; }
            public float average_fps { get; set; }
            public string game { get; set; }
            public int video_height { get; set; }
            public int viewers { get; set; }
            public bool is_playlist { get; set; }

            public class Preview
            {
                public string large { get; set; }
                public string medium { get; set; }
                public string small { get; set; }
                public string template { get; set; }

                public string Template(int width, int height)
                {
                    return template.Replace("{width}", width.ToString())
                        .Replace("{height}", height.ToString());
                }
            }
        }
    }
}
