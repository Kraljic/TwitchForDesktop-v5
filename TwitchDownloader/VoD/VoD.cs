using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDownloader.VoD
{
    public class VoD
    {
        public TwitchDownloader.Playlist Playlist;

        public event EventHandler<DownloadVideoArgs> DownloadProgressChanged;
        public event EventHandler<DownloadVideoArgs> DownloadDone;
        public event EventHandler<DownloadVideoArgs> DownloadError;

        protected readonly string VodId;
        protected readonly string OAuthToken;

        private bool _cancleDownload;

        public VoD(string vodId, string oAuthToken)
        {
            // Remove v from ID
            VodId = vodId.Replace("v", string.Empty);
            OAuthToken = oAuthToken;
            Playlist = new Playlist(VodId, OAuthToken);
        }

        public void Download(TwitchDownloader.Playlist.VideoSorce video, string path)
        {
            try
            {
                _cancleDownload = false;

                File.Delete(path);
                var fs = new FileStream(path, FileMode.Append);

                var videoParts = GetVideoParts(video.Url);


                for (var i = 0; i < videoParts.Count; i++)
                {
                    if (_cancleDownload)
                    {
                        OnDownloadError(new DownloadVideoArgs(0, false, true));
                        return;
                    }

                    var url = videoParts[i];
                    var downloadedBytes = new System.Net.WebClient().DownloadData(url);
                    fs.Write(downloadedBytes, 0, downloadedBytes.Length);

                    OnDownloadProgressChanged(new DownloadVideoArgs(i / (double)videoParts.Count * 100.0d));
                }

                OnDownloadDone(new DownloadVideoArgs(100, true));
            }
            catch (Exception e)
            {
                OnDownloadError(new DownloadVideoArgs(0, false, true));
            }
        }

        private static List<string> GetVideoParts(string url)
        {
            var videoPartsData = DownloadVideoPartsList(url);
            var videoPartsList = new List<string>();
            var pData = videoPartsData.Split('\n');
            var rootUrl = GetRootUrl(url);

            foreach (var s in pData)
            {
                if (string.IsNullOrWhiteSpace(s))
                    continue;
                if (s.Trim()[0] == '#')
                    continue;
                videoPartsList.Add(rootUrl + s.Trim());
            }

            return videoPartsList;
        }

        private static string DownloadVideoPartsList(string url)
        {
            var playlist = new WebClient().DownloadString(url);
            return playlist;
        }

        private static string GetRootUrl(string url)
        {
            var rmIndex = url.LastIndexOf('/') + 1;
            url = url.Remove(rmIndex, url.Length - rmIndex);

            return url;
        }

        protected virtual void OnDownloadProgressChanged(DownloadVideoArgs e)
        {
            DownloadProgressChanged?.Invoke(this, e);
        }
        protected virtual void OnDownloadDone(DownloadVideoArgs e)
        {
            DownloadDone?.Invoke(this, e);
        }
        protected virtual void OnDownloadError(DownloadVideoArgs e)
        {
            DownloadError?.Invoke(this, e);
        }
    }
}
