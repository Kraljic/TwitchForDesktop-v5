using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Kraken.Games
{
    public class Show
    {
        private const int GAME_WIDTH = 220;
        private const int GAME_HEIGHT = (int)(GAME_WIDTH / (23.0 / 32.0));    // Aspect ratio 23:32   (in bottom right corner);

        private const int CANVAS_WIDTH = GAME_WIDTH;
        private const int CANVAS_HEIGHT = GAME_HEIGHT + 50;
        private const int CANVAS_MARGIN = 3;

        public const int Limit = 25;

        private bool _initDone = false;

        public int Offset { get; private set; }

        private Panel _canvas;
        private Button loadMoreButton;

        public Show(Panel panel)
        {
            _canvas = panel;

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

            string jsonString = Links.Web.DownloadString(Links.Game.Top(Limit, Offset));
            
            if (jsonString != null)
            {
                JSON json = new JavaScriptSerializer().Deserialize<JSON>(jsonString);
                DrawStreams(json);
                Offset += Limit;
            }
        }

        private void DrawStreams(JSON json)
        {
            int i = Offset;
            int panelWidth = CANVAS_WIDTH + 2 * CANVAS_MARGIN;
            int panelHeight = CANVAS_HEIGHT + 2 * CANVAS_MARGIN;
            int maxInRow = _canvas.Width / panelWidth;

            ToolTip tt1 = new ToolTip();
            
            foreach (JSON.Top game in json.top)
            {
                Forms.PanelInfo p = new Forms.PanelInfo();
                PictureBox pbGame = new PictureBox();
                Label lbName = new Label();

                //
                // Main Panel
                //
                p.Game = game.game;
                p.Name = "panel_" + game.game._id;
                p.Location = new System.Drawing.Point(
                    i % maxInRow * panelWidth + CANVAS_MARGIN,
                    i / maxInRow * panelHeight + CANVAS_MARGIN - _canvas.VerticalScroll.Value);
                p.Size = new System.Drawing.Size(CANVAS_WIDTH, CANVAS_HEIGHT);
                p.BackColor = System.Drawing.Color.Gray;
                p.Margin = new Padding(CANVAS_MARGIN);
                //
                // PicturBox Game Image
                //
                pbGame.Name = "pbGame";
                pbGame.Location = new System.Drawing.Point(0, 0);
                pbGame.Size = new System.Drawing.Size(GAME_WIDTH, GAME_HEIGHT);
                pbGame.BackColor = System.Drawing.Color.Black;
                pbGame.ImageLocation = game.game.box.medium;
                pbGame.SizeMode = PictureBoxSizeMode.Zoom;
                pbGame.Cursor = Cursors.Hand;
                pbGame.Click += PbGame_Click;
                //
                // Label Game Name
                //
                lbName.Text = game.game.name;
                lbName.Location = new System.Drawing.Point(0, GAME_HEIGHT + 4);
                lbName.Width = CANVAS_WIDTH;
                lbName.Font = new System.Drawing.Font(lbName.Font.FontFamily, 16);
                lbName.Height = TextRenderer.MeasureText(lbName.Text, lbName.Font).Height;
                tt1.SetToolTip(lbName, lbName.Text);


                p.Controls.Add(pbGame);
                p.Controls.Add(lbName);
                _canvas.Controls.Add(p);

                i++;
            }

            if (json.top.Count > 0)
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

        private void PbGame_Click(object sender, EventArgs e)
        {
            var panel = (sender as PictureBox).Parent as Forms.PanelInfo;
            new Kraken.Stream.Show(
                _canvas, 
                Kraken.Stream.StreamType.GAME,
                new [] {panel.Game.name}
                ).Init();
        }

        private void LoadMoreButton_Click(object sender, EventArgs e)
        {
            Next();
        }
    }
}
