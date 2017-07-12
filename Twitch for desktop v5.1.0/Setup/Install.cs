using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Twitch_for_desktop_v5_1_0.Setup
{
    public class Install
    {
        public static bool IsEverythingInstalled()
        {
            bool yes = InstallVLC.IsInstalled();
            
            return yes;
        }
        

        protected static bool Exists(string parentKey)
        {
            try
            {
                var key = Registry.LocalMachine.OpenSubKey(parentKey);
                var checkExistanc = key.Name;
            
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
