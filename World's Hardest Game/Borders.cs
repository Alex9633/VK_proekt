using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace World_s_Hardest_Game
{

    //create and draw a border

    public class Borders
    {
        public Point Center { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        
        public Borders(Point center, int h, int w)
        {
            Center = center;
            Height = h;
            Width = w;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(b, Center.X - Width/2, Center.Y - Height/2, Width, Height);
            b.Dispose();
        }
    }
}
