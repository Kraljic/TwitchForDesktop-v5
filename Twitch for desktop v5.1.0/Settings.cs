namespace Twitch_for_desktop_v5_1_0
{
    public class Settings
    {
        public static string oauthToken;

        public static string VLCPath = @"";

        public static void Save()
        {
            Properties.Settings.Default.oauthToken = oauthToken;
            Properties.Settings.Default.vlcPath = VLCPath;

            Properties.Settings.Default.Save();
        }
        public static void Load()
        {
            oauthToken = Properties.Settings.Default.oauthToken;
            VLCPath = Properties.Settings.Default.vlcPath;
        }
    }
}
