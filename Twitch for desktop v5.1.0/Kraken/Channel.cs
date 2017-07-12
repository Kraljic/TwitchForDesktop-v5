using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Twitch_for_desktop_v5_1_0.Kraken
{
    public class Channel
    {
        public long _id { get; set; }
        public string broadcaster_language { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public string email { get; set; }
        public int followers { get; set; }
        public string game { get; set; }
        public string language { get; set; }
        public string logo { get; set; }
        public bool? mature { get; set; }
        public bool? partner { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string video_banner { get; set; }
        public int views { get; set; }


        public static Channel Init()
        {
            string jsonString = Links.Web.DownloadString(
                Links.Channel.GetChannel());

            if (jsonString != null)
            {
                JavaScriptSerializer se = new JavaScriptSerializer();
                return se.Deserialize<Channel>(jsonString);
            }

            return null;
        }
    }
}
