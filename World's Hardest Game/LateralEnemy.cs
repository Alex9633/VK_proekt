using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_s_Hardest_Game
{
    public class LateralEnemy
    {
        // create and draw an enemy

        // reason why it's called LateralEnemy because I was initially going to have multiple classes for each type but I found a way to do it all in one class

        public Point Center { get; set; }
        public static int Rad = 10;
        public int type { get; set; }
        public int speed { get; set; }

        bool swap = false, swap2 = false, swap3 = false;    // swapping the dirction once a certain point is reached
        double angle = 0.0;   // for circular enemies
        int moveticks = 0;    // for circular enemies

        public LateralEnemy(Point Center, int type, int speed)
        {
            this.Center = Center;
            this.type = type;
            this.speed = speed;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Blue);
            Pen p = new Pen(Color.DarkBlue, 4);
            g.FillEllipse(b, Center.X - Rad, Center.Y - Rad, Rad*2, Rad*2);
            g.DrawEllipse(p, Center.X - Rad, Center.Y - Rad, Rad*2, Rad*2);
            b.Dispose();
            p.Dispose();
        }


        //move the enemies of each level and according to their type (vertical, lateral, circular, diagonal, plus to what point should they go and change direction)
        public void Move(int lvl)
        {
            switch (lvl)
            {
                case 1:
                    if (Center.X + speed > 780) swap = true;
                    else if (Center.X + speed < 120) swap = false;
                    if (swap) Center = new Point(Center.X - speed, Center.Y);
                    else Center = new Point(Center.X + speed, Center.Y);
                    break;
                case 2:
                    if(type == 1)
                    {
                        if (Center.X + speed > 625 ) swap = true;
                        else if (Center.X + speed < 275) swap = false;
                        if (swap) Center = new Point(Center.X - speed, Center.Y);
                        else Center = new Point(Center.X + speed, Center.Y);
                    }
                    else
                    {
                        if (Center.Y + speed > 475) swap2 = true;
                        else if (Center.Y + speed < 125) swap2 = false;
                        if (swap2) Center = new Point(Center.X, Center.Y - speed);
                        else Center = new Point(Center.X, Center.Y + speed);
                    }
                    break;
                case 3:
                    if(type == 1)
                    {
                        if (Center.Y + speed > 360) swap = true;
                        else if (Center.Y + speed < 240) swap = false;
                        if (swap) Center = new Point(Center.X, Center.Y - speed);
                        else Center = new Point(Center.X, Center.Y + speed);
                    }
                    else if (type == 2)
                    {
                        if (Center.Y + speed > 190) swap2 = true;
                        else if (Center.Y + speed < 40) swap2 = false;
                        if (Center.X + speed > 510) swap3 = true;
                        else if (Center.X + speed < 390) swap3 = false;

                        if (swap2) Center = new Point(Center.X, Center.Y - speed);
                        else Center = new Point(Center.X, Center.Y + speed);
                        if (swap3) Center = new Point(Center.X - speed, Center.Y);
                        else Center = new Point(Center.X + speed, Center.Y);
                    }
                    else
                    {
                        if (Center.Y + speed > 560) swap2 = true;
                        else if (Center.Y + speed < 410) swap2 = false;
                        if (Center.X + speed > 510) swap3 = true;
                        else if (Center.X + speed < 390) swap3 = false;

                        if (swap2) Center = new Point(Center.X, Center.Y - speed);
                        else Center = new Point(Center.X, Center.Y + speed);
                        if (swap3) Center = new Point(Center.X - speed, Center.Y);
                        else Center = new Point(Center.X + speed, Center.Y);
                    }
                    break;
                case 4:
                    if (moveticks == 100)
                    {
                        if (type == 1) angle += 0.25;
                        else angle -= 0.25;
                        int x = Center.X + (int)(Rad * Math.Cos(angle));
                        int y = Center.Y + (int)(Rad * Math.Sin(angle));
                        Center = new Point(x, y);
                        moveticks = 0;
                    }
                    moveticks += 25;
                    break;
                case 5:
                    if (type == 1)
                    {
                        if (moveticks == 100)
                        {
                            angle += 0.25;
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(Center.X, y);

                            if (Center.X + speed > 730) swap = true;
                            else if (Center.X + speed < 300) swap = false;
                            if (swap) Center = new Point(Center.X - speed, Center.Y);
                            else Center = new Point(Center.X + speed, Center.Y);

                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else if (type == 2)
                    {
                        if (moveticks == 100)
                        {
                            angle += 0.3;
                            int x = Center.X + (int)(Rad * Math.Cos(angle));
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(x, y);
                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else
                    {
                        if (Center.Y + speed > 540) swap2 = true;
                        else if (Center.Y + speed < 370) swap2 = false;
                        if (Center.X + speed > 740) swap3 = true;
                        else if (Center.X + speed < 270) swap3 = false;

                        if (swap2) Center = new Point(Center.X, Center.Y - speed);
                        else Center = new Point(Center.X, Center.Y + speed);
                        if (swap3) Center = new Point(Center.X - speed, Center.Y);
                        else Center = new Point(Center.X + speed, Center.Y);
                    }
                    break;

                case 6:
                    if (type == 1)
                    {
                        if (moveticks == 75)
                        {
                            angle += 0.1;
                            int x = Center.X + (int)(Rad * Math.Cos(angle));
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(x, y);
                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else if (type == 2)
                    {
                        if (moveticks == 50)
                        {
                            angle += 0.07;
                            int x = Center.X - (int)(Rad * Math.Cos(angle));
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(x, y);
                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else if (type == 3)
                    {
                        if (moveticks == 50)
                        {
                            angle += 0.055;
                            int x = Center.X + (int)(Rad * Math.Cos(angle));
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(x, y);
                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else if (type == 4)
                    {
                        if (moveticks == 25)
                        {
                            angle += 0.045;
                            int x = Center.X - (int)(Rad * Math.Cos(angle));
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(x, y);
                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else if (type == 5)
                    {
                        if (moveticks == 25)
                        {
                            angle += 0.0375;
                            int x = Center.X + (int)(Rad * Math.Cos(angle));
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(x, y);
                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else if (type == 6)
                    {
                        if (moveticks == 25)
                        {
                            angle += 0.0325;
                            int x = Center.X - (int)(Rad * Math.Cos(angle));
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(x, y);
                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else if (type == 7)
                    {
                        if (moveticks == 50)
                        {
                            angle += 0.1;
                            int x = Center.X - (int)(Rad * Math.Cos(angle));
                            int y = Center.Y + (int)(Rad * Math.Sin(angle));
                            Center = new Point(x, y);
                            moveticks = 0;
                        }
                        moveticks += 25;
                    }

                    else if (type == 8)
                    {
                        if (Center.Y + speed > 615) swap = true;
                        else if (Center.Y - speed < 35) swap = false;
                        if (swap) Center = new Point(Center.X, Center.Y - speed);
                        else Center = new Point(Center.X, Center.Y + speed);
                    }

                    else if (type == 9)
                    {
                        if (Center.X + speed > 740) swap = true;
                        else if (Center.X - speed < 160) swap = false;
                        if (swap) Center = new Point(Center.X - speed, Center.Y);
                        else Center = new Point(Center.X + speed, Center.Y);
                    }

                    break;
            }
        }
    }
}
