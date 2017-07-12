using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Kraken.Stream
{
    public class ChannelStream
    {
        public static JSON.Stream GetStream(long channelId)
        {
            string URL = Links.Stream.Channel(channelId);
            string jsonString = Links.Web.DownloadString(URL);

            if (jsonString == null)
                return null;

            var json = new JavaScriptSerializer().Deserialize<JSON>(jsonString);
            return json.stream;
        }
    }
}
