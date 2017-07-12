using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twitch_for_desktop_v5_1_0.Forms;
using Twitch_for_desktop_v5_1_0.Kraken.VOD;

namespace Twitch_for_desktop_v5_1_0.Video
{
    public class VOD
    {
        public static void OpenVOD(Kraken.VOD.JSON.Video video, string vodUrl)
        {
            var title = video.channel.display_name + " - VOD - " + video.title;

            var startArgs = vodUrl + " --file-caching=5000  --meta-title=\"" + title + "\"";
            
            new VLC(startArgs).Play();
        }
    }
}
