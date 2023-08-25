using System;
using System.Windows.Forms;

namespace World_s_Hardest_Game
{
    public partial class Form2 : Form
    {

        // very simple window, nothing to explain

        private readonly AudioManager ad = new AudioManager();

        public Form2(string time, int deaths)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;   //unable to change window size
            MaximizeBox = false;    //cannot maximize window
            WindowState = FormWindowState.Normal;   //cannot go fullscreen
            label1.Text = "Time: " + time;
            label3.Text = $"Deaths: {deaths}";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ad.button.Play();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
