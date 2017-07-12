using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TwitchChat.IRC
{
    public class Message
    {
        public string id { get; set; }
        public string message { get; set; }
        public string room { get; set; }

        public long userId { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public Color color { get; set; }
        public bool banned { get; set; }
        public string userType { get; set; }
        public bool mod { get; set; }
        public bool subscriber { get; set; }
        public bool turbo { get; set; }
        public string emotes { get; set; }

    }
}
