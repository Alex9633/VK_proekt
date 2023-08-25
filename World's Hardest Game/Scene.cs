using System.Collections.Generic;
using System.Drawing;

namespace World_s_Hardest_Game
{
    public class Scene
    {
        // each of the variables has a self explanatory name
        public Player player { get; set; }
        public Point respawnPos { get; set; }

        public List<Borders> borders { get; set; } = new List<Borders>();
        public List<LayoutBox> layoutBoxes { get; set; } = new List<LayoutBox>();
        public List<LateralEnemy> LateralEnemies { get; set; } = new List<LateralEnemy>();

        public List<Coin> coins { get; set; }
        public List<Coin> stashedCoins { get; set; }

        public Goal goal { get; set; }
        public Goal StartArea { get; set; }

        public int deaths = 0;

        private readonly AudioManager ad = new AudioManager();


        // creates a new scene with the info from the appropriate level
        public Scene(Point playerPos, List<LateralEnemy> latEnemyPos, List<Borders> borders, List<LayoutBox> lb, Goal goal, Goal startArea, List<Coin> coins, int deaths)
        {
            player = new Player(playerPos);
            respawnPos = playerPos;
            LateralEnemies = latEnemyPos;
            this.borders = borders;
            layoutBoxes = lb;
            this.goal = goal;
            StartArea = startArea;
            this.coins = coins;
            stashedCoins = new List<Coin>();
            this.deaths = deaths;
        }

        public void Draw(Graphics g)
        {
            foreach (LayoutBox lb in layoutBoxes)
            {
                lb.Draw(g);
            }

            StartArea.Draw(g);
            goal.Draw(g);

            foreach(Coin coin in coins)
            {
                coin.Draw(g);
            }

            player.Draw(g);

            foreach(LateralEnemy e in LateralEnemies)
            {
                e.Draw(g);
            }

            foreach(Borders border in borders)
            {
                border.Draw(g);
            }
        }


        // logic for collision detection was takes from online forums, link is listed for each one 

        public void PlayerMove(int dir)   // int direction from 'GameForm' depending on what arrow key is the player pressing
        {
            bool wallColl = false;   
            int newx = player.Center.X, newy = player.Center.Y;

            switch (dir)
            {
                case 1: newy -= 3; break;   // the new position of the player
                case 2: newy += 3; break;
                case 3: newx -= 3; break;
                case 4: newx += 3; break;
            }

            foreach (Borders b in borders)  // is the player colliding with a border (wall)
            {

                // IDEA TAKEN FROM  https://developer.mozilla.org/en-US/docs/Games/Techniques/2D_collision_detection

                if (b.Center.X - b.Width/2 < newx + 15 && b.Center.X + b.Width/2 > newx - 15 &&
                    b.Center.Y - b.Height/2 < newy + 15 && b.Center.Y + b.Height/2 > newy - 15)
                {
                    wallColl = true;
                    break;
                }

            }

            if(!wallColl) player.Move(dir);  // if a collision was detected the player will not move in the given direction
        }

        public bool CheckGoal()   // checks if the player has collected all coins and is touching the goal
        {
                
            // IDEA TAKEN FROM  https://developer.mozilla.org/en-US/docs/Games/Techniques/2D_collision_detection

            if (coins.Count == 0 && goal.Center.X - goal.Width / 2 < player.Center.X + 15 && goal.Center.X + goal.Width / 2 > player.Center.X - 15 &&
            goal.Center.Y - goal.Height / 2 < player.Center.Y + 15 && goal.Center.Y + goal.Height / 2 > player.Center.Y - 15)
            {
                ad.level.Play();
                return true;
            }

            return false;
        }

        public void EnemyCollCheck()   // checks if the player is colliding with an enemy
        {
            // TAKEN FROM  https://stackoverflow.com/questions/401847/circle-rectangle-collision-detection-intersection

            foreach (LateralEnemy enemy in LateralEnemies)
            {
                float left = player.Center.X - 15;
                float right = player.Center.X + 15;
                float top = player.Center.Y - 15;
                float bottom = player.Center.Y + 15;

                float closestX = (enemy.Center.X < left ? left : (enemy.Center.X > right ? right : enemy.Center.X));
                float closestY = (enemy.Center.Y < top ? top : (enemy.Center.Y > bottom ? bottom : enemy.Center.Y));
                float dx = closestX - enemy.Center.X;
                float dy = closestY - enemy.Center.Y;

                if ((dx * dx + dy * dy) <= 100)   //if he is, reset the position and collected coins, add a death to the counter
                {
                    ad.death.Play();
                    foreach(Coin c in stashedCoins)
                    {
                        coins.Add(c);
                    }
                    stashedCoins.Clear();
                    deaths++;
                    player.Center = respawnPos;
                    break;
                }
            }
        }

        public void CoinCollCheck()    // checks if the player is colliding with a coin
        {
            // TAKEN FROM  https://stackoverflow.com/questions/401847/circle-rectangle-collision-detection-intersection

            foreach (Coin coin in coins)
            {
                float left = player.Center.X - 15;
                float right = player.Center.X + 15;
                float top = player.Center.Y - 15;
                float bottom = player.Center.Y + 15;

                float closestX = (coin.Center.X < left ? left : (coin.Center.X > right ? right : coin.Center.X));
                float closestY = (coin.Center.Y < top ? top : (coin.Center.Y > bottom ? bottom : coin.Center.Y));
                float dx = closestX - coin.Center.X;
                float dy = closestY - coin.Center.Y;

                if ((dx * dx + dy * dy) <= 100)   //if he is, add it to a seperate list for safekeeping and remove from main list
                {
                    ad.coin.Play();
                    stashedCoins.Add(coin);
                    coins.Remove(coin);
                    break;
                }
            }
        }

        public void latEnemyMove(int lvl)   //move each enemy
        {
            foreach(LateralEnemy enemy in LateralEnemies)
            {
                enemy.Move(lvl);
            }
        }
    }
}
