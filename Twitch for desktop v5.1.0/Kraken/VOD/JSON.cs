using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twitch_for_desktop_v5_1_0.Links;

namespace Twitch_for_desktop_v5_1_0.Kraken.VOD
{
    public class JSON
    {
        private static readonly Size AnimatedPreviewSize = new Size(320, 180);

        public List<Video> videos { get; set; }

        public class Video
        {
            public Kraken.Channel channel { get; set; }
            public Preview preview { get; set; }
            

            public string title { get; set; }
            public long broadcast_id { get; set; }
            public string broadcast_type { get; set; }
            public int views { get; set; }
            public string url { get; set; }
            public string created_at { get; set; }
            public string viewable { get; set; }
            public string _id { get; set; }
            public string game { get; set; }
            public int length { get; set; }
            public string animated_preview_url { get; set; }

            public class Preview
            {
                public string large { get; set; }
                public string medium { get; set; }
                public string small { get; set; }
                public string template { get; set; }

                public string Template(int width, int height)
                {
                    return template.Replace("{width}", width.ToString())
                        .Replace("{height}", height.ToString());
                }

            }

            public List<Bitmap> GetAnimatedPreview()
            {
                var bmp = Web.DownloadImage(animated_preview_url);
                List<Bitmap> bmpList = new List<Bitmap>();
                if (bmp == null)
                    return bmpList;
                for (int i = 0; i < bmp.Height / AnimatedPreviewSize.Height; i++)
                {
                    var section = new Rectangle(new Point(0, i * AnimatedPreviewSize.Height), AnimatedPreviewSize);
                    bmpList.Add(CropImage(bmp, section));
                }
                return bmpList;
            }

            private static Bitmap CropImage(Bitmap source, Rectangle section)
            {
                // An empty bitmap which will hold the cropped image
                Bitmap bmp = new Bitmap(section.Width, section.Height);

                Graphics g = Graphics.FromImage(bmp);

                // Draw the given area (section) of the source image
                // at location 0,0 on the empty bitmap (bmp)
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

                return bmp;
            }

        }
    }
}
