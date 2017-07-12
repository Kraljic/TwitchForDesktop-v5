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
    public partial class Home : Form
    {
        private static Kraken.Channel _channel;
        public static Kraken.Stream.Show Streams;
        public static Kraken.Games.Show Games;
        public static Kraken.Following.Show Following;

        public static Kraken.Channel Channel { get { return _channel; } }

        public Home()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            Settings.Load();
            Settings.oauthToken = Kraken.Token.setToken(Settings.oauthToken);
            _channel = Kraken.Channel.Init();

            labelUsername.Text = Channel.display_name;
            pbPanelLeft.ImageLocation = Channel.logo;

            Streams = new Kraken.Stream.Show(panelMainRight, Kraken.Stream.StreamType.FOLLOWED);
            Streams.Init();
            labelTitleTab.Text = "Following - Live";

            this.Show();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
        }        

        private void LeftPanel_btnClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string text = b.Text;

            switch (text)
            {
                case "Live":
                    Streams = new Kraken.Stream.Show(panelMainRight, Kraken.Stream.StreamType.FOLLOWED);
                    Streams.Init();
                    labelTitleTab.Text = "Following - Live";
                    break;
                case "Channels":
                    Streams = new Kraken.Stream.Show(panelMainRight, Kraken.Stream.StreamType.ALL);
                    Streams.Init();
                    labelTitleTab.Text = "Channels";
                    break;
                case "Games":
                    Games = new Kraken.Games.Show(panelMainRight);
                    Games.Init();
                    labelTitleTab.Text = "Games";
                    break;
                case "Following":
                    Following = new Kraken.Following.Show(Channel._id, panelMainRight);
                    Following.Init();
                    labelTitleTab.Text = "Following";
                    break;
                case "Options":
                    (new Options()).ShowDialog();
                    break;
                case "Logout":
                    Links.Web.DownloadString(Links.Token.Logout());
                    Settings.oauthToken = null;
                    Close();
                    break;
                case "Discover":
                    break;
                default:
                    break;
            }
        }
    }
}
