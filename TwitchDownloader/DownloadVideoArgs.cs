using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDownloader
{
    public class DownloadVideoArgs : EventArgs
    {
        public double Progress { get; }
        public bool Done { get; }
        public bool Error { get; }

        public DownloadVideoArgs(double progress, bool done = false, bool error = false)
        {
            Progress = progress;
            Done = done;
            Error = error;
        }
    }
}
