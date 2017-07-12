using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Forms
{
    public class PanelInfo : Panel
    {
        public Kraken.Channel Channel;
        public Kraken.Games.JSON.Top.Game Game;
        public Kraken.Users.JSON User;
        public Kraken.Stream.JSON.Stream Stream;
        public Kraken.VOD.JSON.Video Video;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
