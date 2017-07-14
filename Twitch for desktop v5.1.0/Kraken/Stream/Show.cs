using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Twitch_for_desktop_v5_1_0.Forms;

namespace Twitch_for_desktop_v5_1_0.Kraken.Stream
{
    public enum StreamType
    {
        ALL,
        FOLLOWED,
        GAME,
        FEATURED
    }

    public class Show
    {
        public const int Limit = 30;
        public int Offset { get; private set; }
        public StreamType Type { get; private set; }
        public string[] Args { get; private set; }


        private static int IMAGE_WIDTH = 300;
        private static int IMAGE_HEIGHT =  (int)(IMAGE_WIDTH / (16.0 / 9.0));   // Aspect ratio 16:9

        private static int GAME_WIDTH = 45;
        private static int GAME_HEIGHT = (int)(GAME_WIDTH / (23.0/32.0));    // Aspect ratio 23:32   (in bottom right corner);

        private static int CANVAS_WIDTH = IMAGE_WIDTH;
        private static int CANVAS_HEIGHT = IMAGE_HEIGHT + 50;
        private static int CANVAS_MARGIN_LR = 3;
        private static int CANVAS_MARGIN_UD = 5;

        private bool _initDone = false;

        private Panel _canvas;
        private Button loadMoreButton;
        ContextMenuStrip rightClickContextMenu;


        public Show(Panel panel, StreamType type = StreamType.ALL, string[] args = null)
        {
            _canvas = panel;
            Type = type;
            Args = args;

            int maxCanvases = _canvas.Width / CANVAS_WIDTH;
            int margin = _canvas.Width - maxCanvases * CANVAS_WIDTH;
            CANVAS_MARGIN_LR = margin / (maxCanvases * 2);
            CANVAS_MARGIN_UD = CANVAS_MARGIN_LR / 2;

            loadMoreButton = new Button();
            loadMoreButton.Click += LoadMoreButton_Click;
            loadMoreButton.Text = "Load More..";
            loadMoreButton.Size = new Size(200, 80);
            loadMoreButton.Location = new Point(_canvas.Width / 2 - loadMoreButton.Width / 2, 20);
            loadMoreButton.Show();

            rightClickContextMenu = new ContextMenuStrip();
            rightClickContextMenu.Name = "test";
            ToolStripMenuItem[] items =
            {
                new ToolStripMenuItem() {Text = "Open chat"},
                new ToolStripMenuItem() {Text = "Open stream"},
                new ToolStripMenuItem() {Text = "Show profile"},
                new ToolStripMenuItem() {Text = "View in web"}
            };
            rightClickContextMenu.Items.AddRange(items);
            rightClickContextMenu.ItemClicked += RightClickContextMenu_ItemClicked;
        }

        private void RightClickContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var obj = (sender as ContextMenuStrip).SourceControl.Parent as PanelInfo;

            switch (e.ClickedItem.Text)
            {
                case "Open chat":
                    Process.Start("TwitchChat.exe", "room=" + obj.Stream.channel.name + " oauth_token=" + Settings.oauthToken);
                    break;
                case "Open stream":
                    new Forms.Dialogs.OpenStream(obj.Stream).ShowDialog();
                    break;
                case "Show profile":
                    new User(obj.Stream.channel._id).ShowDialog();
                    break;
                case "View in web":
                    Process.Start(obj.Stream.channel.url);
                    break;
            }
        }

        public void Init()
        {
            if (_initDone)
                throw new Exception("Initialization can be called only once.");
            _initDone = true;
            
            _canvas.Controls.Clear();
            _canvas.Controls.Add(loadMoreButton);
            this.Next();
        }

        public void Next()
        {
            if (!_initDone)
                throw new Exception("Object needs to be initialized with Init function.");

            string URL = getLink();
            string jsonString = Links.Web.DownloadString(URL);

            if (jsonString != null)
            {
                JSON json = new JavaScriptSerializer().Deserialize<JSON>(jsonString);
                DrawStreams(json);
                Offset += Limit;
            }
        }

        private string getLink()
        {
            switch (Type)
            {
                case StreamType.FOLLOWED:
                    return Links.Stream.Followed(Limit, Offset);
                case StreamType.ALL:
                    return Links.Stream.All(Limit, Offset);
                case StreamType.GAME:
                    return Links.Stream.Game(Limit, Offset, Args[0]);
                case StreamType.FEATURED:
                    return Links.Stream.Featured(Limit, Offset);
            }
            return null;
        }
        
        private void DrawStreams(JSON json)
        {
            int i = Offset;
            int panelWidth = CANVAS_WIDTH + 2 * CANVAS_MARGIN_LR;
            int panelHeight = CANVAS_HEIGHT + 2 * CANVAS_MARGIN_UD;
            int maxInRow = _canvas.Width / panelWidth;

            var tt1 = new ToolTip();
            if (json.streams == null)
                return;

            foreach (JSON.Stream stream in json.streams)
            {
                if (stream.is_playlist)
                    continue;

                var p = new Forms.PanelInfo();
                var pbPrev = new PictureBox();
                var pbGame = new PictureBox();
                var lbStatus = new Label();
                var lbViewers = new Label();
                var lbName = new LinkLabel();

                //
                // Main Panel
                //
                p.Stream = stream;
                p.Name = "panel_" + stream.channel.name;
                p.Location = new System.Drawing.Point(
                    i % maxInRow * panelWidth + CANVAS_MARGIN_LR, 
                    i / maxInRow * panelHeight + CANVAS_MARGIN_UD - _canvas.VerticalScroll.Value);
                p.Size = new System.Drawing.Size(CANVAS_WIDTH, CANVAS_HEIGHT);
                p.BackColor = System.Drawing.Color.Gray;
                p.Margin = new Padding(CANVAS_MARGIN_LR, CANVAS_MARGIN_UD, CANVAS_MARGIN_LR, CANVAS_MARGIN_UD);
                //
                // PicturBox Preview Stream
                //
                pbPrev.Name = "pbStream";
                pbPrev.Location = new System.Drawing.Point(0, 0);
                pbPrev.Size = new System.Drawing.Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                pbPrev.BackColor = System.Drawing.Color.Black;
                pbPrev.ImageLocation = stream.preview.medium;
                pbPrev.Cursor = Cursors.Hand;
                pbPrev.Click += OpenStream_onPicturBoxClick;
                pbPrev.ContextMenuStrip = rightClickContextMenu;
                //
                // PicturBox Game
                //
                pbGame.Name = "pbGame";
                pbGame.Location = new System.Drawing.Point(pbPrev.Width - GAME_WIDTH, pbPrev.Height - GAME_HEIGHT);
                pbGame.Size = new System.Drawing.Size(GAME_WIDTH, GAME_HEIGHT);
                pbGame.BackColor = System.Drawing.Color.Transparent;
                pbGame.ImageLocation = "https://static-cdn.jtvnw.net/ttv-boxart/" + stream.game + "-138x190.jpg";
                pbGame.SizeMode = PictureBoxSizeMode.Zoom;
                pbGame.BorderStyle = BorderStyle.FixedSingle;
                tt1.SetToolTip(pbGame, stream.game);
                //
                // Label Show Stream Title (Status)
                //
                lbStatus.Text = stream.channel.status;
                lbStatus.Location = new System.Drawing.Point(0, IMAGE_HEIGHT + 4);
                lbStatus.Width = CANVAS_WIDTH;
                lbStatus.Font = new System.Drawing.Font("Helvetica Neue,Helvetica,sans-serif", 12);
                tt1.SetToolTip(lbStatus, lbStatus.Text);
                //
                // Label Viewers
                //
                lbViewers.Text = stream.viewers.ToString("N0") + " viewers on ";
                lbViewers.Location = new System.Drawing.Point(0, lbStatus.Location.Y + lbStatus.Height + 4);
                lbViewers.Width = TextRenderer.MeasureText(lbViewers.Text, lbViewers.Font).Width - 3;
                lbViewers.Margin = new Padding(0);
                //
                // LinkLabel Name
                //
                lbName.Text = stream.channel.display_name;
                lbName.Location = new System.Drawing.Point(lbViewers.Width, lbViewers.Location.Y);
                lbName.Margin = new Padding(0);
                lbName.LinkColor = System.Drawing.Color.Black;
                lbName.ActiveLinkColor = System.Drawing.Color.Magenta;
                lbName.Click += ShowUser_onLinkLabelClick;


                p.Controls.Add(pbPrev);
                p.Controls.Add(pbGame);
                p.Controls.Add(lbStatus);
                p.Controls.Add(lbViewers);
                p.Controls.Add(lbName);

                pbGame.BringToFront();

                _canvas.Controls.Add(p);
                i++;
            }

            if (json.streams.Count > 0)
            {
                loadMoreButton.Location = new Point(
                        loadMoreButton.Location.X,
                        (i + maxInRow - 1) / maxInRow * panelHeight + CANVAS_MARGIN_UD - _canvas.VerticalScroll.Value)
                    ;
            }
            else
            {
                loadMoreButton.Hide();
            }
        }

        private void ShowUser_onLinkLabelClick(object sender, EventArgs e)
        {
            Forms.PanelInfo p = (sender as LinkLabel).Parent as Forms.PanelInfo;
            long id = p.Stream.channel._id;

            Forms.User userForm = new Forms.User(id);
            userForm.ShowDialog();
        }

        private void OpenStream_onPicturBoxClick(object sender, EventArgs e)
        {
            var mouseEventArgs = (MouseEventArgs) e;
            if (mouseEventArgs.Button != MouseButtons.Left)
                return;
            Forms.PanelInfo p = (sender as PictureBox).Parent as Forms.PanelInfo;
            new Forms.Dialogs.OpenStream(p.Stream).ShowDialog();
        }

        private void LoadMoreButton_Click(object sender, EventArgs e)
        {
            Next();
        }
    }
}
