using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchDownloader.VoD;
using Twitch_for_desktop_v5_1_0.Links;

namespace Twitch_for_desktop_v5_1_0.Forms.Dialogs
{
    public partial class OpenVod : Form
    {
        private readonly Kraken.VOD.JSON.Video _videoJson;
        private VoD _vod;
        private List<Bitmap> _previewList;
        private int _previewIndex;

        public OpenVod(Kraken.VOD.JSON.Video videoJson)
        {
            InitializeComponent();
            _videoJson = videoJson;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenVod_Load(object sender, EventArgs e)
        {
            lblChannelName.Text = _videoJson.channel.display_name;
            lblTitle.Text = _videoJson.title;
            LoadPreview();
            LoadPlaylist();
        }

        private void LoadPreview()
        {
            _previewIndex = 0;

            var previewImage = Web.DownloadImage(_videoJson.preview.medium);
            pbPreview.Image = previewImage;

            _previewList = _videoJson.GetAnimatedPreview();
            if (_previewList == null)
                _previewList = new List<Bitmap>();
            _previewList.Insert(0, previewImage);

            AnimatedPreviewTimer.Enabled = true;
        }

        private void LoadPlaylist()
        {
            try
            {
                _vod = new VoD(_videoJson._id, Settings.oauthToken);

                if (_vod.Playlist.Videos == null)
                    throw new NullReferenceException();

                foreach (var video in _vod.Playlist.Videos)
                {
                    cbResolutions.Items.Add(video);
                }

                cbResolutions.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't open VOD (" + _videoJson.title + ")", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var vodUrl = _vod.Playlist.Videos[cbResolutions.SelectedIndex];
            Video.VOD.OpenVOD(_videoJson, vodUrl.Url);
            Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // Show progress bar in form
            this.Height = 375;

            var title = _videoJson.channel.name + " - " + DateTime.Now.ToFileTime() + ".ts";
            var vodDownloader = new VoD(_videoJson._id, Settings.oauthToken);
            vodDownloader.DownloadProgressChanged += VodDownloader_DownloadProgressChanged;
            vodDownloader.DownloadDone += VodDownloader_DownloadDone;

            var th = new Thread(() =>
                vodDownloader.Download(vodDownloader.Playlist.Videos[0], @"D:\twitch videos\" + title)
            );
            th.Start();
        }

        private void VodDownloader_DownloadDone(object sender, TwitchDownloader.DownloadVideoArgs e)
        {
            progressBar1.Value = (int)e.Progress;
            lblProgress.Text = e.Progress.ToString("F") + "% / 100% complited.";
        }

        private void VodDownloader_DownloadProgressChanged(object sender, TwitchDownloader.DownloadVideoArgs e)
        {
            progressBar1.Value = (int)e.Progress;
            lblProgress.Text = e.Progress.ToString("F") + "% / 100% complited.";
        }

        private void AnimatedPreviewTimer_Tick(object sender, EventArgs e)
        {
            if (_previewList == null || _previewList.Count <= 0)
                return;
            pbPreview.Image = _previewList[_previewIndex];
            _previewIndex = _previewIndex >= _previewList.Count - 1 ? 0 : _previewIndex + 1;
        }
    }
}
