using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_s_Hardest_Game
{
    // create and draw a coin
    public class Coin
    {
        public Point Center { get; set; }
        public static int Rad = 10;

        public Coin(Point Center)
        {
            this.Center = Center;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Gold);
            Pen p = new Pen(Color.DarkGoldenrod, 4);
            g.FillEllipse(b, Center.X - Rad, Center.Y - Rad, Rad * 2, Rad * 2);
            g.DrawEllipse(p, Center.X - Rad, Center.Y - Rad, Rad * 2, Rad * 2);
            b.Dispose();
            p.Dispose();
        }
    }
}
