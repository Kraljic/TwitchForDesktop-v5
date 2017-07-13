using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using TwitchChat;

namespace Twitch_for_desktop_v5_1_0.Kraken.Users
{
    public class Show
    {
        private Panel _canvas;
        private Forms.UserPanel panel;
        private Kraken.Channel _channel;
        public Kraken.Channel Channel {get { return _channel; }}

        private long _id;
        public long ID { get { return _id; } }

        public Show(long id, Panel contentPanel)
        {
            this._id = id;
            this._canvas = contentPanel;
        }

        public void Init()
        {
            string URL = Links.Channel.GetChannelByID(_id);
            string jsonString = Links.Web.DownloadString(URL);

            if (jsonString == null)
                return;
            // Get user
            Kraken.Channel json = new JavaScriptSerializer().Deserialize<Kraken.Channel>(jsonString);
            _channel = json;

            // Create new user panel
            panel = new Forms.UserPanel();
            _canvas.Controls.Clear();
            _canvas.Controls.Add(panel);

            // Init
            panel.Width = this._canvas.Width;
            panel.Height = this._canvas.Height;
            panel.InitializeComponent();
                
            // Show user info
            panel.labelUsername.Text = json.display_name;
            if (isChannelLive())
            {
                panel.labelUsername.BackColor = Color.GreenYellow;
                panel.labelUsername.ForeColor = Color.Black;
                panel.labelUsername.Cursor = Cursors.Hand;
                panel.labelUsername.Click += LabelUsername_Click;
            }
                    
            panel.pbPanelLeft.ImageLocation = json.logo;
            panel.pbPanelLeft.Click += PbPanelLeft_Click;
            panel.pbPanelLeft.Cursor = Cursors.Hand;
            if (isChannelFollowingUser())
                panel.btnFollow.Text = "Unfollow";
            panel.btnFollowers.Text = "Followers (" + json.followers + ")";
            panel.btnFollowing.Text = "Following (" + Kraken.Following.Show.GetTotal(_id) + ")";

            if (_channel.partner == false)
            {
                panel.btnSubscribe.Visible = false;
                panel.btnOpenChat.Location = new Point(panel.btnOpenChat.Location.X, panel.btnOpenChat.Location.Y - panel.btnSubscribe.Height);
            }

            // Add events on buttons
            panel.btnFollow.Click += LeftPanel_btnClick;
            panel.btnFollowers.Click += LeftPanel_btnClick;
            panel.btnFollowing.Click += LeftPanel_btnClick;
            panel.btnHighlights.Click += LeftPanel_btnClick;
            panel.btnPastBroadcasts.Click += LeftPanel_btnClick;
            panel.btnSubscribe.Click += LeftPanel_btnClick;
            panel.btnOpenChat.Click += LeftPanel_btnClick;
                
            Kraken.VOD.Show vod = new VOD.Show(_id, panel.panelMainRight, VOD.Show.VODType.ARCHIVE);
            vod.Init();
        }

        private void PbPanelLeft_Click(object sender, EventArgs e)
        {
            Process.Start(_channel.url);
        }

        private void LabelUsername_Click(object sender, EventArgs e)
        {
            new Forms.Dialogs.OpenStream(Channel._id).ShowDialog();
        }

        private void LeftPanel_btnClick(object sender, EventArgs e)
        {
            Button b1 = (Button)sender;
            string text = b1.Text;

            if (text == "Follow" && followUser())
            {
                b1.Text = "Unfollow";
            }
            else if (text == "Unfollow" && followUser())
            {
                b1.Text = "Follow";
            }
            else if (text.Contains("Following"))
            {
                Kraken.Following.Show follows = new Following.Show(_id, panel.panelMainRight);
                follows.Init();
            }
            else if (text.Contains("Followers"))
            {

            }
            else if (text.Contains("Subscribe"))
            {

            }
            else if (text.Contains("Highlights"))
            {
                Kraken.VOD.Show vod = new VOD.Show(_id, panel.panelMainRight, VOD.Show.VODType.HIGHLIGHT);
                vod.Init();
            }
            else if (text.Contains("Past Broadcasts"))
            {
                Kraken.VOD.Show vod = new VOD.Show(_id, panel.panelMainRight, VOD.Show.VODType.ARCHIVE);
                vod.Init();
            }
            else if (text.Contains("Chat"))
            {
                Process.Start("TwitchChat.exe", "room=" + _channel.name + " oauth_token=" + Settings.oauthToken);
            }
        }

        private bool isChannelLive()
        {
            string URL = Links.Users.IsLive(_id);
            string jsonString = Links.Web.DownloadString(URL);
            
            if (jsonString.Contains("\"stream\":null"))
                return false;
            return true;
        }

        private bool isChannelFollowingUser()
        {
            string URL = Links.Users.IsFollowing(_id);
            string jsonString = Links.Web.DownloadString(URL);

            if (jsonString != null)
                return true;
            return false;
        }
        private bool followUser()
        {
            string URL = Links.Users.IsFollowing(_id);

            if (!isChannelFollowingUser())
                return Links.Web.PutRequest(URL, new byte[0]);
            else
                return Links.Web.DeleteRequest(URL, new byte[0]);
        }

    }
}
