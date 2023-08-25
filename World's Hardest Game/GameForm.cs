using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace World_s_Hardest_Game
{

    // the window where the game is displayed

    public partial class GameForm : Form
    {
        Scene scene;
        bool left = false, right = false, up = false, down = false;   //for movement
        bool flag = false;   //flag for a 1 time execution (explained below)

        int currLevel = 1, timePassed = 0, totalDeaths = 0;   //stats for the status label
        public GameForm(int currLevel)
        {

            // creates the given level and starts all the timers

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;   //unable to change window size
            MaximizeBox = false;    //cannot maximize window
            WindowState = FormWindowState.Normal;   //cannot go fullscreen
            DoubleBuffered = true;

            switch (currLevel)
            {
                case 1: lvl1(); break;
                case 2: lvl2(); break;
                case 3: lvl3(); break;
                case 4: lvl4(); break;
                case 5: lvl5(); break;
                case 6: lvl6(); break;
            }

            Invalidate();
            collCheck.Start();    //checking for collisions
            moveTimer.Start();    //used for movement by checking key holding
            timer1.Start();       //used for the circular enemy type movement
        }


        // each level is its own method and they are virtually the same code with different numbers, so I will only explain lvl1()

        private void lvl1()
        {
            currLevel = 1;           //whats the current level
            lvlCounter.Text = "Level: 1/6";    //changes status label for level counter stat

            Point p = new Point(200, 150);    //the player starting position in the level
            List<LateralEnemy> points = new List<LateralEnemy>
            {
                new LateralEnemy(new Point(120, 380), 1, 6),   //list of enemy positions, type and speed (each level has unique enemy attributes, explained in LateralEnemy class)
                new LateralEnemy(new Point(120, 440), 1, 6),
                new LateralEnemy(new Point(780, 410), 1, 6),
                new LateralEnemy(new Point(780, 470), 1, 6)
            };

            List<Borders> borders = new List<Borders>          //list of the black border positions and sizes of the level (player boundaries)
            {
                new Borders(new Point(100, 300), 400, 5),
                new Borders(new Point(200, 100), 5, 204),
                new Borders(new Point(300, 225), 250, 5),
                new Borders(new Point(800, 300), 400, 5),
                new Borders(new Point(700, 100), 5, 204),
                new Borders(new Point(600, 225), 250, 5),
                new Borders(new Point(450, 347), 5, 304),
                new Borders(new Point(450, 500), 5, 705)
            };

            List<LayoutBox> layoutBoxes = new List<LayoutBox>    //list of the white background positions and sizes of the level
            {
                new LayoutBox(new Point(200, 300), 400, 200),
                new LayoutBox(new Point(700, 300), 400, 200),
                new LayoutBox(new Point(450, 424), 150, 306)
            };

            Goal goal = new Goal(new Point(700, 150), 100, 200);     //the goal green zone position and size of the level
            Goal start = new Goal(new Point(200, 150), 100, 200);    //the start green zone position and size of the level

            List<Coin> coins = new List<Coin>    //list of coin positions of the level
            {
                new Coin(new Point(425, 480)),
                new Coin(new Point(475, 480))
            };

            //creates the scene with the above info
            scene = new Scene(p, points, borders, layoutBoxes, goal, start, coins, totalDeaths);
        }

        private void lvl2()
        {
            currLevel = 2;
            lvlCounter.Text = "Level: 2/6";

            Point p = new Point(200, 300);
            List<LateralEnemy> points = new List<LateralEnemy>
            {
                new LateralEnemy(new Point(275, 125), 1, 2),
                new LateralEnemy(new Point(275, 205), 1, 2),
                new LateralEnemy(new Point(275, 285), 1, 2),
                new LateralEnemy(new Point(275, 365), 1, 2),
                new LateralEnemy(new Point(275, 440), 1, 2),

                new LateralEnemy(new Point(625, 165), 1, 2),
                new LateralEnemy(new Point(625, 245), 1, 2),
                new LateralEnemy(new Point(625, 325), 1, 2),
                new LateralEnemy(new Point(625, 405), 1, 2),
                new LateralEnemy(new Point(625, 475), 1, 2),

                new LateralEnemy(new Point(275, 125), 2, 2),
                new LateralEnemy(new Point(355, 125), 2, 2),
                new LateralEnemy(new Point(435, 125), 2, 2),
                new LateralEnemy(new Point(515, 125), 2, 2),
                new LateralEnemy(new Point(590, 125), 2, 2),

                new LateralEnemy(new Point(315, 475), 2, 2),
                new LateralEnemy(new Point(395, 475), 2, 2),
                new LateralEnemy(new Point(475, 475), 2, 2),
                new LateralEnemy(new Point(555, 475), 2, 2),
                new LateralEnemy(new Point(625, 475), 2, 2),
            };

            List<Borders> borders = new List<Borders>
            {
                new Borders(new Point(150, 300), 400, 5),
                new Borders(new Point(450, 100), 5, 600),
                new Borders(new Point(750, 300), 400, 5),
                new Borders(new Point(450, 500), 5, 600),
            };

            List<LayoutBox> layoutBoxes = new List<LayoutBox>
            {
                new LayoutBox(new Point(450, 300), 400, 600),
            };

            Goal goal = new Goal(new Point(700, 300), 400, 100);
            Goal start = new Goal(new Point(200, 300), 400, 100);

            List<Coin> coins = new List<Coin>
            {
                new Coin(new Point(435, 125)),
                new Coin(new Point(475, 125)),
                new Coin(new Point(435, 475)),
                new Coin(new Point(475, 475)),
                new Coin(new Point(435, 285)),
                new Coin(new Point(475, 285)),
                new Coin(new Point(435, 325)),
                new Coin(new Point(475, 325)),

            };

            scene = new Scene(p, points, borders, layoutBoxes, goal, start, coins, totalDeaths);
        }

        private void lvl3()
        {
            currLevel = 3;
            lvlCounter.Text = "Level: 3/6";

            Point p = new Point(450, 300);
            List<LateralEnemy> points = new List<LateralEnemy>
            {
                new LateralEnemy(new Point(100, 240), 1, 3),
                new LateralEnemy(new Point(180, 240), 1, 3),
                new LateralEnemy(new Point(260, 240), 1, 3),
                new LateralEnemy(new Point(340, 240), 1, 3),

                new LateralEnemy(new Point(140, 360), 1, 3),
                new LateralEnemy(new Point(220, 360), 1, 3),
                new LateralEnemy(new Point(300, 360), 1, 3),

                new LateralEnemy(new Point(560, 240), 1, 3),
                new LateralEnemy(new Point(640, 240), 1, 3),
                new LateralEnemy(new Point(720, 240), 1, 3),
                new LateralEnemy(new Point(800, 240), 1, 3),

                new LateralEnemy(new Point(600, 360), 1, 3),
                new LateralEnemy(new Point(680, 360), 1, 3),
                new LateralEnemy(new Point(760, 360), 1, 3),

                new LateralEnemy(new Point(400, 190), 2, 2),
                new LateralEnemy(new Point(500, 50), 2, 3),

                new LateralEnemy(new Point(400, 410), 3, 3),
                new LateralEnemy(new Point(480, 550), 3, 2),
            };

            List<Borders> borders = new List<Borders>
            {
                new Borders(new Point(225, 378), 5, 300),
                new Borders(new Point(77, 300), 155, 5),
                new Borders(new Point(225, 222), 5, 300),

                new Borders(new Point(675, 378), 5, 300),
                new Borders(new Point(823, 300), 155, 5),
                new Borders(new Point(675, 222), 5, 300),

                new Borders(new Point(372, 122), 200, 5),
                new Borders(new Point(450, 23), 5, 155),
                new Borders(new Point(527, 122), 200, 5),

                new Borders(new Point(372, 478), 200, 5),
                new Borders(new Point(450, 577), 5, 155),
                new Borders(new Point(527, 478), 200, 5)

            };

            List<LayoutBox> layoutBoxes = new List<LayoutBox>
            {
                new LayoutBox(new Point(450, 300), 150, 750),
                new LayoutBox(new Point(450, 300), 550, 150)
            };

            List<Coin> coins = new List<Coin>
            {
                new Coin(new Point(395, 45)),
                new Coin(new Point(505, 45)),
                new Coin(new Point(395, 555)),
                new Coin(new Point(505, 555)),
                new Coin(new Point(100, 300)),
                new Coin(new Point(800, 300)),
            };

            Goal start = new Goal(new Point(450, 300), 150, 150);
            Goal goal = new Goal(new Point(450, 300), 150, 150);

            scene = new Scene(p, points, borders, layoutBoxes, goal, start, coins, totalDeaths);
        }

        private void lvl4()
        {
            currLevel = 4;
            lvlCounter.Text = "Level: 4/6";

            Point p = new Point(200, 300);
            List<LateralEnemy> points = new List<LateralEnemy>
            {
                new LateralEnemy(new Point(320, 130), 1, 2),
                new LateralEnemy(new Point(500, 130), 1, 2),

                new LateralEnemy(new Point(320, 200), 2, 2),
                new LateralEnemy(new Point(410, 200), 1, 2),
                new LateralEnemy(new Point(500, 200), 2, 2),
                new LateralEnemy(new Point(590, 200), 1, 2),

                new LateralEnemy(new Point(320, 270), 1, 2),
                new LateralEnemy(new Point(410, 270), 2, 2),
                new LateralEnemy(new Point(500, 270), 1, 2),
                new LateralEnemy(new Point(590, 270), 2, 2),

                new LateralEnemy(new Point(320, 340), 2, 2),
                new LateralEnemy(new Point(410, 340), 1, 2),
                new LateralEnemy(new Point(500, 340), 2, 2),
                new LateralEnemy(new Point(590, 340), 1, 2),

                new LateralEnemy(new Point(320, 410), 1, 2),
                new LateralEnemy(new Point(410, 410), 2, 2),
                new LateralEnemy(new Point(500, 410), 1, 2),
                new LateralEnemy(new Point(590, 410), 2, 2),

                new LateralEnemy(new Point(320, 480), 2, 2),
                new LateralEnemy(new Point(500, 480), 2, 2),
            };

            List<Borders> borders = new List<Borders>
            {
                new Borders(new Point(150, 300), 400, 5),
                new Borders(new Point(450, 100), 5, 604),
                new Borders(new Point(750, 300), 400, 5),
                new Borders(new Point(450, 500), 5, 604),
            };

            List<LayoutBox> layoutBoxes = new List<LayoutBox>
            {
                new LayoutBox(new Point(450, 300), 400, 600),
            };

            Goal goal = new Goal(new Point(700, 300), 400, 100);
            Goal start = new Goal(new Point(200, 300), 400, 100);

            List<Coin> coins = new List<Coin>
            {
                new Coin(new Point(435, 300)),
                new Coin(new Point(475, 300)),

                new Coin(new Point(335, 400)),
                new Coin(new Point(575, 400)),

                new Coin(new Point(335, 200)),
                new Coin(new Point(575, 200)),

                new Coin(new Point(435, 150)),
                new Coin(new Point(475, 450)),
            };

            scene = new Scene(p, points, borders, layoutBoxes, goal, start, coins, totalDeaths);
        }

        private void lvl5()
        {
            currLevel = 5;
            lvlCounter.Text = "Level: 5/6";

            Point p = new Point(200, 150);
            List<LateralEnemy> points = new List<LateralEnemy>
            {
                new LateralEnemy(new Point(320, 130), 1, 13),
                new LateralEnemy(new Point(420, 160), 1, 10),
                new LateralEnemy(new Point(720, 100), 1, 15),
                new LateralEnemy(new Point(550, 75), 1, 16),
                new LateralEnemy(new Point(666, 150), 1, 12),
                new LateralEnemy(new Point(400, 70), 1, 8),

                new LateralEnemy(new Point(705, 270), 2, 2),

                new LateralEnemy(new Point(320, 400), 3, 4),
                new LateralEnemy(new Point(420, 420), 3, 3),
                new LateralEnemy(new Point(700, 500), 3, 4),
                new LateralEnemy(new Point(500, 440), 3, 2),
                new LateralEnemy(new Point(666, 515), 3, 3),
                new LateralEnemy(new Point(290, 385), 3, 2),
            };

            List<Borders> borders = new List<Borders>
            {
                new Borders(new Point(150, 150), 200, 5),
                new Borders(new Point(450, 50), 5, 604),
                new Borders(new Point(400, 250), 5, 504),

                new Borders(new Point(750, 300), 505, 5),
                new Borders(new Point(650, 300), 103, 5),

                new Borders(new Point(150, 450), 200, 5),
                new Borders(new Point(450, 550), 5, 604),
                new Borders(new Point(400, 350), 5, 504),
            };

            List<LayoutBox> layoutBoxes = new List<LayoutBox>
            {
                new LayoutBox(new Point(450, 150), 200, 600),
                new LayoutBox(new Point(450, 450), 200, 600),
                new LayoutBox(new Point(700, 300), 110, 100),
            };

            Goal goal = new Goal(new Point(200, 450), 200, 100);
            Goal start = new Goal(new Point(200, 150), 200, 100);

            List<Coin> coins = new List<Coin>
            {
                new Coin(new Point(725, 75)),
                new Coin(new Point(725, 525)),
            };

            scene = new Scene(p, points, borders, layoutBoxes, goal, start, coins, totalDeaths);
        }

        private void lvl6()
        {
            currLevel = 6;
            lvlCounter.Text = "Level: 6/6";

            Point p = new Point(450, 325);
            List<LateralEnemy> points = new List<LateralEnemy>
            {
                new LateralEnemy(new Point(457, 235), 1, 1),
                new LateralEnemy(new Point(457, 195), 2, 1),
                new LateralEnemy(new Point(457, 165), 3, 1),
                new LateralEnemy(new Point(457, 125), 4, 1),
                new LateralEnemy(new Point(457, 85), 5, 1),
                new LateralEnemy(new Point(445, 235), 7, 1),

                new LateralEnemy(new Point(190, 35), 8, 3),
                new LateralEnemy(new Point(270, 35), 8, 3),
                new LateralEnemy(new Point(350, 35), 8, 3),
                new LateralEnemy(new Point(670, 35), 8, 3),
                new LateralEnemy(new Point(590, 35), 8, 3),
                new LateralEnemy(new Point(230, 615), 8, 3),
                new LateralEnemy(new Point(310, 615), 8, 3),
                new LateralEnemy(new Point(710, 615), 8, 3),
                new LateralEnemy(new Point(630, 615), 8, 3),
                new LateralEnemy(new Point(550, 615), 8, 3),

                new LateralEnemy(new Point(160, 105), 9, 3),
                new LateralEnemy(new Point(160, 185), 9, 3),
                new LateralEnemy(new Point(160, 585), 9, 3),
                new LateralEnemy(new Point(160, 505), 9, 3),
                new LateralEnemy(new Point(160, 425), 9, 3),
                new LateralEnemy(new Point(740, 65), 9, 3),
                new LateralEnemy(new Point(740, 145), 9, 3),
                new LateralEnemy(new Point(740, 225), 9, 3),
                new LateralEnemy(new Point(740, 545), 9, 3),
                new LateralEnemy(new Point(740, 465), 9, 3),
            };

            List<Borders> borders = new List<Borders>
            {
                new Borders(new Point(150, 325), 600, 5),
                new Borders(new Point(450, 25), 5, 604),
                new Borders(new Point(750, 325), 600, 5),
                new Borders(new Point(450, 625), 5, 604),
            };

            List<LayoutBox> layoutBoxes = new List<LayoutBox>
            {
                new LayoutBox(new Point(450, 325), 602, 602),
            };

            Goal goal = new Goal(new Point(450, 325), 100, 100);
            Goal start = new Goal(new Point(10000, 10000), 0, 0);

            List<Coin> coins = new List<Coin>
            {
                new Coin(new Point(450, 505)),
                new Coin(new Point(450, 145)),
                new Coin(new Point(270, 325)),
                new Coin(new Point(630, 325)),

                new Coin(new Point(190, 65)),
                new Coin(new Point(710, 65)),
                new Coin(new Point(190, 585)),
                new Coin(new Point(710, 585)),
            };

            scene = new Scene(p, points, borders, layoutBoxes, goal, start, coins, totalDeaths);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        // checks if a movement key is no longer held
        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        //the timer in the status label (the total time passed)
        private void timer1_Tick(object sender, EventArgs e)
        {
            timePassed++;
            timerTotal.Text = $"{timePassed / 3600:D2}:{timePassed / 60:D2}:{timePassed % 60:D2}";
        }

        //checks if a movement key is held
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
        }

        //checks if the player is touching an enemy or a coin (functions explained in class 'Scene')
        private void collCheck_Tick(object sender, EventArgs e)
        {
            scene.EnemyCollCheck();
            scene.CoinCollCheck();
            Invalidate();
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            deathCounter.Text = $"Deaths: {scene.deaths}";  //updates total deaths in the status label

            // move if a movement key is held each tick (the number means what direction)
            if (up)
            {
                scene.PlayerMove(1);
                Invalidate();
            }
            if (down)
            {
                scene.PlayerMove(2);
                Invalidate();
            }
            if (left)
            {
                scene.PlayerMove(3);
                Invalidate();
            }
            if (right)
            {
                scene.PlayerMove(4);
                Invalidate();
            }

            scene.latEnemyMove(currLevel);  //move the enemies each tick

            if(scene.CheckGoal())  //if the player touches the goal with all coins collected
            {
                switch(currLevel)
                {
                    case 1: totalDeaths = scene.deaths; lvl2(); break;  //if its level 1, move to level 2 (create new scene) and save the current death count
                    case 2: totalDeaths = scene.deaths; lvl3(); break;
                    case 3: totalDeaths = scene.deaths; lvl4(); break;
                    case 4: totalDeaths = scene.deaths; lvl5(); break;
                    case 5: totalDeaths = scene.deaths; lvl6(); break;
                    default:   //this means you have completed level 6 and won the game
                        {
                            if (!flag)  //this guarantees it will only run once to avoid bugs/softlocks
                            {
                                //stops all the timers and moves on to the congratulations window with the status labels saved
                                flag = true;
                                timer1.Stop();
                                moveTimer.Stop();
                                collCheck.Stop();
                                totalDeaths = scene.deaths;
                                Form2 form2 = new Form2(timerTotal.Text, totalDeaths);
                                Close();
                                form2.ShowDialog();
                            }
                            break;
                        }
                }
            }
        }
    }
}
