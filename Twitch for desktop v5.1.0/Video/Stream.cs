using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Twitch_for_desktop_v5_1_0.Forms;
using Twitch_for_desktop_v5_1_0.Kraken.Stream;

namespace Twitch_for_desktop_v5_1_0.Video
{
    public class Stream
    {
        public static void OpenStream(JSON.Stream stream, string streamUrl)
        {
            var title = stream.channel.display_name + " is playing " + stream.channel.game;

            var startArgs = streamUrl + " --file-caching=5000 --meta-title=\"" + title + "\"";

            try
            {
                new VLC(startArgs).Play();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid VLC path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
