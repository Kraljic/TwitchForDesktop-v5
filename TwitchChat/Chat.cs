using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchChat.IRC;
using TwitchChat.Kraken;

namespace TwitchChat
{
    public partial class Chat : Form
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        private string _oauthToken = null;
        private string _room = null;
        public Kraken.Channel Channel;

        public Connection Connection { get; private set; }

        public Chat(string[] args)
        {
            InitializeComponent();
            GetArguments(args);
        }
        public void GetArguments(string[] args)
        {
            try
            {
                foreach (var s in args)
                {
                    if (s.IndexOf("oauth_token") == 0)
                    {
                        _oauthToken = s.Split('=')[1].Trim();
                    }
                    else if (s.IndexOf("room") == 0)
                    {
                        _room = s.Split('=')[1].Trim();
                    }
                }

                if (_oauthToken == null)
                {
                    MessageBox.Show("Missing OAuthToken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                if (_room == null)
                {
                    MessageBox.Show("Missing room id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                Environment.SetEnvironmentVariable("oauthToken", _oauthToken);
                if (!Kraken.Token.IsValid(_oauthToken))
                {
                    MessageBox.Show("Invalid OAuthToken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                Channel = Channel.Init();
                labelTitleTab.Text = Channel.display_name;
            }
            catch (Exception)
            {
                MessageBox.Show("An error ocured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Chat_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }
        private void Chat_MouseUp(object sender, MouseEventArgs e)
        {

            _dragging = false;
        }
        private void Chat_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging)
                return;
            var p = PointToScreen(e.Location);
            Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
        }


        private void Chat_Load(object sender, EventArgs e)
        {
            Show();
            Connection = new Connection();
            Connection.Connect();
            Connection.WriteLine("PASS oauth:" + _oauthToken);
            Connection.WriteLine("NICK " + Channel.name);
            Connection.WriteLine("CAP REQ :twitch.tv/tags");

            Thread.Sleep(500);
            chatRefresh.Enabled = true;

            if ((new Regex("^([a-z]|_)*$")).Match(_room).Success)
            {
                SendCommand("JOIN #" + _room);
            }
        }

        private void chatRefresh_Tick(object sender, EventArgs e)
        {
            while (Connection.Connected() && Connection.Available())
            {
                var line = Connection.ReadLine();
                if (line == "PING :tmi.twitch.tv")
                {
                    SendCommand("PONG :tmi.twitch.tv");
                }
                else if (line.Contains("PRIVMSG"))
                {
                    var msg = IRC.Chat.ReadMessage(line);
                    AddTextColor(msg.displayName, msg.color, true);
                    AddTextColor(": " + msg.message + "\n", Color.Black);
                    if (rtbChat.Lines.Length > 200)
                    {
                        RemoveChatLines(rtbChat.Lines.Length - 200);
                    }
                }
                else
                {
                    rtbChat.AppendText(line);
                }
                Application.DoEvents();
                Thread.Sleep(5);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(txtMessage.Text);
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            SendCommand(txtMessage.Text.Trim());
        }

        private void SendCommand(string cmd)
        {
            if (cmd.Trim() == "")
                return;

            if (Connection.Connected())
                Connection.WriteLine(cmd);
        }

        private void SendMessage(string msg)
        {
            if (msg.Trim() == "")
                return;

            msg = msg.Replace("\n", " ").Trim();
            SendCommand("PRIVMSG #" + _room + " :" + msg);

        }

        public void AddTextColor(string text, Color c, bool bold = false)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;

            rtbChat.SelectionColor = c;
            if (bold)
                rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Bold);
            rtbChat.AppendText(text);

            rtbChat.SelectionColor = rtbChat.ForeColor;
            rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Regular);
        }

        public void RemoveChatLines(int count)
        {
            rtbChat.ReadOnly = false;
            for (int i = 0; i < count; i++)
            {
                int index = rtbChat.Text.IndexOf('\n');
                rtbChat.SelectionStart = 0;
                rtbChat.SelectionLength = index + 1;
                rtbChat.SelectedText = "";
            }
            rtbChat.ReadOnly = true;

            // Go to end
            rtbChat.SelectionStart = rtbChat.TextLength - 1;
            rtbChat.SelectionLength = 0;
            rtbChat.ScrollToCaret();
        }
    }
}
