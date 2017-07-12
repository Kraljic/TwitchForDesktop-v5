using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Twitch_for_desktop_v5_1_0.Forms;

namespace Twitch_for_desktop_v5_1_0.Kraken.Following
{
    public class Show
    {
        public static int GetTotal(long id)
        {
            string URL = Links.Users.Follows(id, 1, 0);
            string jsonString = Links.Web.DownloadString(URL);

            if (jsonString != null)
            {
                JSON json = new JavaScriptSerializer().Deserialize<JSON>(jsonString);
                return json._total;
            }

            return 0;
        }

        private const int IMAGE_WIDTH = 300;
        private const int IMAGE_HEIGHT = (int)(IMAGE_WIDTH / (16.0 / 9.0));   // Aspect ratio 16:9
        
        private const int CANVAS_WIDTH = IMAGE_WIDTH;
        private const int CANVAS_HEIGHT = IMAGE_HEIGHT + 50;
        private const int CANVAS_MARGIN = 3;

        public const int Limit = 30;
        public int Offset { get; private set; }

        private bool _initDone = false;
        private Panel _canvas;
        private Button loadMoreButton;

        private long _id;

        public Show(long id, Panel canvasPanel)
        {
            this._canvas = canvasPanel;
            this._id = id;

            loadMoreButton = new Button();
            loadMoreButton.Click += LoadMoreButton_Click;
            loadMoreButton.Text = "Load More..";
            loadMoreButton.Size = new Size(200, 80);
            loadMoreButton.Location = new Point(_canvas.Width / 2 - loadMoreButton.Width / 2, 20);
            loadMoreButton.Show();
        }

        public void Init()
        {
            if(_initDone)
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

            string URL = Links.Users.Follows(_id, Limit, Offset);
            string jsonString = Links.Web.DownloadString(URL);

            if (jsonString != null)
            {
                JSON json = new JavaScriptSerializer().Deserialize<JSON>(jsonString);
                DrawFollows(json);
                Offset += Limit;
            }
        }

        public void DrawFollows(JSON json)
        {

            int i = Offset;
            int panelWidth = CANVAS_WIDTH + 2 * CANVAS_MARGIN;
            int panelHeight = CANVAS_HEIGHT + 2 * CANVAS_MARGIN;
            int maxInRow = _canvas.Width / panelWidth;

            ToolTip tt1 = new ToolTip();

            foreach (JSON.Follows user in json.follows)
            {
                Forms.PanelInfo p = new Forms.PanelInfo();
                PictureBox pbPrev = new PictureBox();
                LinkLabel lbName = new LinkLabel();

                //
                // Main Panel
                //
                p.Channel = user.channel;
                p.Name = "panel_" + user.channel.name;
                p.Location = new System.Drawing.Point(
                    i % maxInRow * panelWidth + CANVAS_MARGIN,
                    i / maxInRow * panelHeight + CANVAS_MARGIN - _canvas.VerticalScroll.Value);
                p.Size = new System.Drawing.Size(CANVAS_WIDTH, CANVAS_HEIGHT);
                p.BackColor = System.Drawing.Color.Gray;
                p.Margin = new Padding(CANVAS_MARGIN);
                //
                // PicturBox Preview Stream
                //
                pbPrev.Name = "pbLogo";
                pbPrev.Location = new System.Drawing.Point(0, 0);
                pbPrev.Size = new System.Drawing.Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                pbPrev.BackColor = System.Drawing.Color.Black;
                pbPrev.ImageLocation = user.channel.logo;
                pbPrev.SizeMode = PictureBoxSizeMode.Zoom;            
                //
                // LinkLabel Name
                //
                lbName.Text = user.channel.display_name;
                lbName.Location = new System.Drawing.Point(0, pbPrev.Height + 5);
                lbName.Width = CANVAS_WIDTH;
                lbName.Margin = new Padding(0);
                lbName.LinkColor = System.Drawing.Color.Black;
                lbName.ActiveLinkColor = System.Drawing.Color.Magenta;
                lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lbName.Font = new System.Drawing.Font(lbName.Font.FontFamily, 16);
                lbName.Click += LbName_Click;


                p.Controls.Add(pbPrev);
                p.Controls.Add(lbName);
                
                _canvas.Controls.Add(p);

                i++;
            }

            if (json.follows.Count > 0)
            {
                loadMoreButton.Location = new Point(
                        loadMoreButton.Location.X,
                        (i + maxInRow - 1) / maxInRow * panelHeight + CANVAS_MARGIN - _canvas.VerticalScroll.Value)
                    ;
            }
            else
            {
                loadMoreButton.Hide();
            }
        }

        private void LbName_Click(object sender, EventArgs e)
        {
            Forms.PanelInfo p = (sender as LinkLabel).Parent as Forms.PanelInfo;
            new User(p.Channel._id).ShowDialog();
        }

        private void LoadMoreButton_Click(object sender, EventArgs e)
        {
            Next();
        }
    }
}
