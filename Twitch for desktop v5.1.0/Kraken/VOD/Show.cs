using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Twitch_for_desktop_v5_1_0.Kraken.Stream;

namespace Twitch_for_desktop_v5_1_0.Kraken.VOD
{
    public class Show
    {
        public enum VODType
        {
            ALL,
            HIGHLIGHT,
            ARCHIVE
        }


        public const int Limit = 30;
        public int Offset { get; private set; }
        public VODType Type { get; private set; }
        private long _id;


        private static int IMAGE_WIDTH = 300;
        private static int IMAGE_HEIGHT = (int)(IMAGE_WIDTH / (16.0 / 9.0));   // Aspect ratio 16:9
        
        private static int CANVAS_WIDTH = IMAGE_WIDTH;
        private static int CANVAS_HEIGHT = IMAGE_HEIGHT + 50;
        private static int CANVAS_MARGIN_LR = 3;
        private static int CANVAS_MARGIN_UD = 5;

        private bool _initDone = false;

        private Panel _canvas;
        private Button loadMoreButton;


        public Show(long id, Panel panel, VODType type = VODType.ALL)
        {
            _canvas = panel;
            Type = type;
            _id = id;

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
                case VODType.ALL:
                    return Links.VOD.All(_id, Limit, Offset);
                case VODType.HIGHLIGHT:
                    return Links.VOD.Highlight(_id, Limit, Offset);
                case VODType.ARCHIVE:
                    return Links.VOD.Archive(_id, Limit, Offset);
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

            foreach (JSON.Video video in json.videos)
            {
                var p = new Forms.PanelInfo();
                var pbPrev = new PictureBox();
                var lbStatus = new Label();
                var lbViews = new Label();
                var lbLenght = new Label();
                var lbName = new LinkLabel();

                //
                // Main Panel
                //
                p.Video = video;
                p.Name = "panel_" + video._id;
                p.Location = new System.Drawing.Point(
                    i % maxInRow * panelWidth + CANVAS_MARGIN_LR,
                    i / maxInRow * panelHeight + CANVAS_MARGIN_UD - _canvas.VerticalScroll.Value);
                p.Size = new System.Drawing.Size(CANVAS_WIDTH, CANVAS_HEIGHT);
                p.BackColor = System.Drawing.Color.Gray;
                p.Margin = new Padding(CANVAS_MARGIN_LR, CANVAS_MARGIN_UD, CANVAS_MARGIN_LR, CANVAS_MARGIN_UD);
                //
                // PicturBox Preview Video
                //
                pbPrev.Name = "pbVideo";
                pbPrev.Location = new System.Drawing.Point(0, 0);
                pbPrev.Size = new System.Drawing.Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                pbPrev.BackColor = System.Drawing.Color.Black;
                pbPrev.ImageLocation = video.preview.medium;
                pbPrev.SizeMode = PictureBoxSizeMode.Zoom;
                pbPrev.Cursor = Cursors.Hand;
                pbPrev.Click += OpenVideo_onPicturBoxClick;
                //
                // Label Show Stream Title (Status)
                //
                lbStatus.Text = video.title;
                lbStatus.Location = new System.Drawing.Point(0, IMAGE_HEIGHT + 4);
                lbStatus.Font = new System.Drawing.Font("Helvetica Neue,Helvetica,sans-serif", 12);
                lbStatus.Width = CANVAS_WIDTH;
                lbStatus.Height = TextRenderer.MeasureText(lbStatus.Text, lbStatus.Font).Height;
                tt1.SetToolTip(lbStatus, lbStatus.Text);
                //
                // Label Viewers
                //
                DateTime d = DateTime.Parse(video.created_at);
                lbViews.Text = video.views.ToString("N0") + " views\n" +
                    LenghtToString(video.length) + "\n" +
                    d.ToShortDateString();
                lbViews.Location = new System.Drawing.Point(0, 0);
                lbViews.Size = TextRenderer.MeasureText(lbViews.Text, lbViews.Font);
                lbViews.Margin = new Padding(0);
                lbViews.BackColor = Color.Cornsilk;
                //
                // LinkLabel Name
                //
                lbName.Text = video.channel.display_name;
                lbName.Name = video.channel.name;
                lbName.Size = TextRenderer.MeasureText(lbName.Text, lbName.Font);
                lbName.Location = new System.Drawing.Point(p.Width - lbName.Width, p.Height - lbName.Height - 4);
                lbName.Margin = new Padding(0);
                lbName.LinkColor = System.Drawing.Color.Black;
                lbName.ActiveLinkColor = System.Drawing.Color.Magenta;


                p.Controls.Add(pbPrev);
                p.Controls.Add(lbStatus);
                p.Controls.Add(lbViews);
                p.Controls.Add(lbName);
                lbViews.BringToFront();

                _canvas.Controls.Add(p);
                i++;
            }

            if (json.videos.Count > 0)
            {
                loadMoreButton.Location = new Point(
                        loadMoreButton.Location.X,
                        (i + maxInRow - 1) / maxInRow * panelHeight + CANVAS_MARGIN_UD - _canvas.VerticalScroll.Value);
            }
            else
            {
                loadMoreButton.Hide();
            }
        }
        
        private void LoadMoreButton_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void OpenVideo_onPicturBoxClick(object sender, EventArgs e)
        {
            var p = (sender as PictureBox).Parent as Forms.PanelInfo;
            new Forms.Dialogs.OpenVod(p.Video).ShowDialog();
        }

        private string LenghtToString(int length)
        {
            int hh = length / 3600, mm = length / 60 % 60, ss = length % 60;
            string len = "";
            if (hh < 10)
                len += "0";
            len += hh + ":";
            if (mm < 10)
                len += "0";
            len += mm + ":";
            if (ss < 10)
                len += "0";
            len += ss;

            return len;
        }
    }
}
