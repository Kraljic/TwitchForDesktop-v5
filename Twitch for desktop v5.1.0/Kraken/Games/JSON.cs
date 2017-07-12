using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Kraken.Games
{
    public class JSON
    {
        public int _total { get; set; }
        public List<Top> top { get; set; }

        public class Top
        {
            public int channels { get; set; }
            public int viewers { get; set; }

            public Game game { get; set; }

            public class Game
            {
                public int _id { get; set; }
                public string name { get; set; }
                public int popularity { get; set; }
                public int giantbomb_id { get; set; }

                public Preview box { get; set; }
                public Preview logo { get; set; }

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
}
