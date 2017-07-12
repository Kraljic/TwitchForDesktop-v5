using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitch_for_desktop_v5_1_0.Forms
{
    public partial class User : Form
    {
        private long _ID;

        public User(long id)
        {
            InitializeComponent();

            this._ID = id;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void User_Load(object sender, EventArgs e)
        {
            Show();

            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            Kraken.Users.Show user = new Kraken.Users.Show(_ID, panelContent);
            user.Init();
            this.Text = "User: " + user.Channel.display_name;
        }
    }
}
