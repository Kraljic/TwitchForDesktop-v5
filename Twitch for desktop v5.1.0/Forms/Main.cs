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

namespace Twitch_for_desktop_v5_1_0.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            checkInstallation();
        }

        private void checkInstallation()
        {
            if (Setup.Install.IsEverythingInstalled())
            {
                this.Hide();
                (new Home()).ShowDialog();
                this.Close();
            }
            else
            {
                if (!Setup.InstallVLC.IsInstalled())
                {
                    btnInstallVLC.Enabled = true;
                }
            }
        }
        
        private void btnInstallVLC_Click(object sender, EventArgs e)
        {
            if (!Setup.InstallVLC.IsInstalled())
            {
                try
                {
                    displayInfo("Downloading VLC media player...");
                    Setup.InstallVLC.Download(prbInfo);
                    displayInfo("Downloading VLC media player done.", 100);
                    Thread.Sleep(1000);
                    displayInfo("Installing VLC media player...", 50);
                    Setup.InstallVLC.Install();
                    displayInfo("VLC media player installation done!", 100);
                    btnInstallVLC.Enabled = false;
                }
                catch
                {
                    displayInfo("Error ocured while trying to install VLC media player.", 0);
                    MessageBox.Show("Somthing went wrong. Please try again..", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                checkInstallation();
            }
        }

        private void displayInfo(string status, int progress = -1)
        {
            lblStatus.Text = "Status: " + status;
            if (progress != -1)
            {
                prbInfo.Value = progress;
            }
        }
    }
}
