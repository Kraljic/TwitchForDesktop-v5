using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twitch_for_desktop_v5_1_0.Video;

namespace Twitch_for_desktop_v5_1_0.Forms
{
    public partial class Options : Form
    {
        private bool _isSaved = true;

        public Options()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isSaved && MessageBox.Show("Are you sure you want dismiss all changes?", "Warning", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void Options_Load(object sender, EventArgs e)
        {
            txtVlcPath.Text = Settings.VLCPath;
            txtOauthToken.Text = Settings.oauthToken;
        }

        private void btnSelectVlcPath_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "VLC media player|vlc.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtVlcPath.Text = ofd.FileName;
                _isSaved = false;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.VLCPath = txtVlcPath.Text;
            _isSaved = true;
            Close();
        }

    }
}
