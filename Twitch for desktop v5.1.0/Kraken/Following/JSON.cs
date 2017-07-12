using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Kraken.Following
{
    public class JSON
    {
        public int _total { get; set; }
        public List<Follows> follows { get; set; }

        public class Follows
        {
            public Kraken.Channel channel { get; set; }
        }
    }
}
