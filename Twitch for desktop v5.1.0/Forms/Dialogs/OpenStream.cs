using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchDownloader.Stream;

namespace Twitch_for_desktop_v5_1_0.Forms.Dialogs
{
    public partial class OpenStream : Form
    {
        private readonly Kraken.Stream.JSON.Stream _streamJson;
        private Stream _stream;

        public OpenStream(long channelId)
        {
            InitializeComponent();

            _streamJson = Kraken.Stream.ChannelStream.GetStream(channelId);
            if (_streamJson == null)
            {
                MessageBox.Show("Couldn't open stream.", "Info", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
        }

        public OpenStream(Kraken.Stream.JSON.Stream streamJson)
        {
            InitializeComponent();
            _streamJson = streamJson;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenStream_Load(object sender, EventArgs e)
        {
            try
            {
                lblChannelName.Text = _streamJson.channel.display_name;
                lblTitle.Text = _streamJson.channel.status;
                pbPreview.ImageLocation = _streamJson.preview.medium;

                LoadPlaylist();
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't open stream (" + _streamJson.channel.name + ")", "Info", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
        }
        
        private void LoadPlaylist()
        {
            _stream = new Stream(_streamJson.channel.name, Settings.oauthToken);

            foreach (var stream in _stream.Playlist.Videos)
            {
                cbResolutions.Items.Add(stream);
            }

            cbResolutions.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var streamUrl = _stream.Playlist.Videos[cbResolutions.SelectedIndex];
            Video.Stream.OpenStream(_streamJson, streamUrl.Url);
            Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
