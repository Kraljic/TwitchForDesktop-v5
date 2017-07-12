using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_for_desktop_v5_1_0.Kraken.Users
{
    public class JSON
    {
        public long _id { get; set; }
        public string display_name { get; set; }
        public string name { get; set; }

        public string bio { get; set; }
        public string logo { get; set; }
        public string type { get; set; }
    }
}
