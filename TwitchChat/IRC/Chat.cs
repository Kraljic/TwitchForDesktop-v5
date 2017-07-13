using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitchChat.IRC
{
    public class Chat
    {
        public static IRC.Message ReadMessage(string msg)
        {
            var message = new Message();
            var mainParts = msg.Replace(" :", "\n").Split('\n');
            
            getTags(message, mainParts[0].Trim());
            getRoomInfo(message, mainParts[1].Trim());
            message.message = mainParts[2].Trim();

            return message;
        }

        private static void getRoomInfo(Message message, string tags)
        {
            try
            {
                message.name = tags.Substring(0, tags.IndexOf('!') - 1);
                message.room = tags.Substring(tags.IndexOf('#')).Trim();
            }
            catch (Exception)
            {
                MessageBox.Show("getRoomInfo() --> " + tags);
            }
        }

        private static void getTags(Message message, string tags)
        {
            tags = tags.Remove(0, 1); // remove @
            var tagList = tags.Split(';');
            foreach (var s in tagList)
            {
                var key = s.Split('=')[0];
                var value = s.Split('=')[1];

                switch (key)
                {
                    case "color":
                        message.color = value != "" ? System.Drawing.ColorTranslator.FromHtml(value) : Color.Black;
                        break;
                    case "display-name":
                        message.displayName = value;
                        break;
                    case "id":
                        message.id = value;
                        break;
                    case "mod":
                        message.mod = Convert.ToBoolean(int.Parse(value));
                        break;
                    case "subscriber":
                        message.subscriber = Convert.ToBoolean(int.Parse(value));
                        break;
                    case "turbo":
                        message.turbo = Convert.ToBoolean(int.Parse(value));
                        break;
                    case "user-id":
                        message.userId = long.Parse(value);
                        break;
                    case "user-type":
                        message.userType = value;
                        break;
                    case "emotes":
                        message.emotes = value;
                        break;
                }
            }
        }
    }
}
