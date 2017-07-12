using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TwitchChat.Kraken
{

    public class Token
    {
        public static bool IsValid(string oauthToken)
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