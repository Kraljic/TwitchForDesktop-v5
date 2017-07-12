using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitch_for_desktop_v5_1_0.Forms;

namespace Twitch_for_desktop_v5_1_0.Video
{
    public class VLC
    {
        private Process _process;
        private string _startArgs;

        public VLC(string startArgs)
        {
            _startArgs = startArgs;

            _process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    WorkingDirectory = Path.GetDirectoryName(Settings.VLCPath),
                    FileName = Path.GetFileName(Settings.VLCPath),
                    Arguments = startArgs
                }
            };
        }

        public void Play()
        {
            _process.Start();
        }

        public void Stop()
        {
            _process.Close();
        }
    }
}
