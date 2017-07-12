using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Twitch_for_desktop_v5_1_0.Kraken
{

    public class Token
    {
        private static string _oauthToken;

        public static string OauthToken { get { return _oauthToken; } }


        public static string setToken(string oauthToken)
        {
            if (!isOauthTokenValid(oauthToken))
            {
                _oauthToken = getNewOauthToken();
            }
            else
            {
                _oauthToken = oauthToken;
            }

            return _oauthToken;
        }
        private static string getNewOauthToken()
        {
            Forms.Login loginForm = new Forms.Login();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                return loginForm.OauthToken;
            }
            else
            {
                throw new Exception("Failed to get a new token.");
            }
        }
        private static bool isOauthTokenValid(string oauthToken)
        {
            return JSON.isValid(oauthToken);
        }

        public class JSON
        {
            public Token token { get; set; }
            public class Token
            {
                public bool valid { get; set; }
            }

            public static bool isValid(string oauthToken)
            {
                string jsonString = Links.Web.DownloadString(
                    Links.Token.ValidToken(oauthToken));

                if (jsonString != null)
                {
                    JavaScriptSerializer se = new JavaScriptSerializer();
                    JSON json = se.Deserialize<JSON>(jsonString);
                    return json.token.valid;
                }

                return false;
            }
        }
    }
}