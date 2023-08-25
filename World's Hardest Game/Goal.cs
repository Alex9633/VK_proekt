﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_s_Hardest_Game
{
    // create and draw the goal/start
    public class Goal
    {
        public Point Center { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Goal(Point center, int h, int w)
        {
            Center = center;
            Height = h;
            Width = w;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.PaleGreen);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(b, Center.X - Width / 2, Center.Y - Height / 2, Width, Height);
            b.Dispose();
        }
    }
}
