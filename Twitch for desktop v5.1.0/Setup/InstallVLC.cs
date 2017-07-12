using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Setup
{
    public class InstallVLC : Install
    {
        private const string DOWNLOAD_URL =
            "http://download.videolan.org/pub/videolan/vlc/2.2.6/win32/vlc-2.2.6-win32.exe";
        
        private static string _setupFile;
        private static ProgressBar _progress;
        public static bool Done { get; private set; } = false;

        public static bool IsInstalled()
        {
            return Exists(@"SOFTWARE\Clients\Media\VLC");
        }

        public static void Download(ProgressBar progress = null)
        {   
            _progress = progress;
            _setupFile = Path.Combine(Path.GetTempPath(), "vlc_setup.exe");

            var WC = new WebClient();
            WC.DownloadProgressChanged += WC_DownloadProgressChanged;
            WC.DownloadFileCompleted += WC_DownloadFileCompleted;

            WC.DownloadFileAsync(new Uri(DOWNLOAD_URL), _setupFile);

            while (!Done)
            {
                Application.DoEvents();
                Thread.Sleep(20);
            }
        }

        private static void WC_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Done = true;
        }

        private static void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (_progress != null)
            {
                _progress.Value = e.ProgressPercentage;
                Application.DoEvents();
            }
        }

        public static void Install()
        {
            Process.Start(_setupFile).WaitForExit();
        }
    }
}
