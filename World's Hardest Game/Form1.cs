using System;
using System.Windows.Forms;

namespace World_s_Hardest_Game
{
    public partial class MainMenu : Form
    {

        // MAIN MENU window, very simple just buttons that activates/deactivates objects

        // GameForm gameForm = new GameForm(1);  -> creates a new gameform (the game window) and the 1 means start from level 1 (if it was 2 then it would start from level 2)
        // gameForm.ShowDialog();  -> opens said gameform and the game can begin

        private readonly AudioManager ad = new AudioManager();

        public MainMenu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;   //unable to change window size
            MaximizeBox = false;    //cannot maximize window
            WindowState = FormWindowState.Normal;   //cannot go fullscreen


            // trying to have background music at the same time as other sounds, but it's way more complicated than I thought so I will scrap it unfortunately
            //sd1.LoadCompleted += SoundPlayer_LoadCompleted;
            //sd1.Play();
        }

        /*
        private void SoundPlayer_LoadCompleted(object sender, EventArgs e)
        {
            sd1.PlayLooping();
        }
        */

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad.button.Play();   // play button sound

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            button4.Visible = true;
            button5.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ad.button.Play();

            label6.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            GameForm gameForm = new GameForm(1);
            gameForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ad.button.Play();

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            GameForm gameForm = new GameForm(1);
            gameForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            GameForm gameForm = new GameForm(2);
            gameForm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            GameForm gameForm = new GameForm(3);
            gameForm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            GameForm gameForm = new GameForm(4);
            gameForm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            GameForm gameForm = new GameForm(5);
            gameForm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            GameForm gameForm = new GameForm(6);
            gameForm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ad.button.Play();

            label6.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }
    }
}
