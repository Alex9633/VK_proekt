using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_s_Hardest_Game
{
    public class Player
    {
        // create and draw a player in a specific position

        public Point Center { get; set; }
        
        public Player(Point Center) { 
            this.Center = Center;
        }

        public void Draw (Graphics g)
        {
            Brush b = new SolidBrush (Color.Red);
            Pen p = new Pen (Color.DarkRed, 4);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(b, Center.X - 15, Center.Y - 15, 30, 30);
            g.DrawRectangle(p, Center.X - 15, Center.Y - 15, 30, 30);
            b.Dispose();
            p.Dispose();
        }

        public void Move(int dir)   // gets called from Scene.cs, if it's a legal move it updates the position
        {
            switch (dir) {
                case 1: Center = new Point(Center.X, Center.Y - 3); break;
                case 2: Center = new Point(Center.X, Center.Y + 3); break;
                case 3: Center = new Point(Center.X - 3, Center.Y); break;
                case 4: Center = new Point(Center.X + 3, Center.Y); break;
            }
        }
    }
}
