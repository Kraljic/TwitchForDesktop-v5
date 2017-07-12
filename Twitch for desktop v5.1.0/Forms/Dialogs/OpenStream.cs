using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Forms.Dialogs
{
    public partial class OpenStream : Form
    {
        private readonly Kraken.Stream.JSON.Stream _stream;
        private List<Video.Playlist.Video> _playList;

        public OpenStream(long channelId)
        {
            InitializeComponent();

            _stream = Kraken.Stream.ChannelStream.GetStream(channelId);
            if (_stream == null)
            {
                MessageBox.Show("Couldn't open stream.", "Info", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
        }

        public OpenStream(Kraken.Stream.JSON.Stream stream)
        {
            InitializeComponent();
            _stream = stream;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenStream_Load(object sender, EventArgs e)
        {
            lblChannelName.Text = _stream.channel.display_name;
            lblTitle.Text = _stream.channel.status;
            pbPreview.ImageLocation = _stream.preview.medium;

            if (!LoadPlaylistData())
            {
                MessageBox.Show("Couldn't open stream (" + _stream.channel.name + ")", "Info", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
                return;
            }

            foreach (var stream in _playList)
            {
                cbResolutions.Items.Add(stream);
            }

            cbResolutions.SelectedIndex = 0;
        }
        
        private bool LoadPlaylistData()
        {
            var playlistData = Kraken.Stream.DownloadPlaylist.Download(_stream.channel.name);
            _playList = new Video.Playlist(playlistData).Videos;

            return _playList.Count > 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var streamUrl = _playList[cbResolutions.SelectedIndex];
            Video.Stream.OpenStream(_stream, streamUrl.Url);
            Close();
        }
    }
}
