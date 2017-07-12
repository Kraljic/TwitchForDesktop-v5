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
    public partial class Login : Form
    {
        private string _oauthToken;
        public string OauthToken { get { return _oauthToken; } }

        public Login()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Links.Token.GetNewToken);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Uri url = e.Url;

            if (url.GetLeftPart(UriPartial.Path) == Links.Token.TokenRedirectPage)
            {
                string hash = url.ToString().Split('#')[1];
                foreach (string variable in hash.Split('&'))
                {
                    string key = variable.Split('=')[0];
                    string value = variable.Split('=')[1];

                    if (key == "access_token")
                    {
                        _oauthToken = value;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }

                // Token not found -> Error
                Close();
            }
        }
    }
}
