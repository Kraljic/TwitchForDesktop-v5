using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace TwitchChat.IRC
{
    public class Connection
    {
        private readonly TcpClient client;

        public Connection()
        {
            client = new TcpClient();
        }

        public void Connect()
        {
            client.Connect(Config.Url, Config.Port);
        }

        public bool Available()
        {
            return client.Available > 0;
        }

        public bool Connected()
        {
            return client.Connected;
        }

        public string ReadLine()
        {
            if (client.Connected)
            {
                string message = "";

                int b;
                char c = '\0';
                do
                {
                    b = client.GetStream().ReadByte();
                    if (b == -1)
                        continue;
                    c = Convert.ToChar(b);
                    message += c;
                } while (c != '\n');

                return message;
            }
            return null;
        }

        public void WriteLine(string line)
        {
            var data = Encoding.UTF8.GetBytes(line + "\n");
            client.GetStream().Write(data, 0, data.Length);
        }
    }
}
