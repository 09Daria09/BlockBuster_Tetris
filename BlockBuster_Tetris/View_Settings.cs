using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockBuster_Tetris.Model;

namespace BlockBuster_Tetris
{
    public partial class View_Settings : Form
    {
        public View_Settings()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            if (Settings.SoundMult)
            {
                button2.Image = Image.FromFile("Check.jpg");
            }
            else
            {
                button2.Image = Image.FromFile("OnCheck.jpg");
            }
            if (Settings.ThemeMult)
            {
                button3.Image = Image.FromFile("sun.bmp");
            }
            else
            {
                button3.Image = Image.FromFile("cloud.bmp");
            }
            this.BackgroundImage = Image.FromFile("Fon6.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.SoundMult = !Settings.SoundMult;
            if (Settings.SoundMult)
            {
                button2.Image = Image.FromFile("Check.jpg");
            }
            else
            {
                button2.Image = Image.FromFile("OnCheck.jpg");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.ThemeMult = !Settings.ThemeMult;
            if (Settings.ThemeMult)
            {
                button3.Image = Image.FromFile("sun.bmp");
            }
            else
            {
                button3.Image = Image.FromFile("cloud.bmp");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();  
        }
    }
}
