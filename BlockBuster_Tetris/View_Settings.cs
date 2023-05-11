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

            comboBox1.Items.Add("Джаз");
            comboBox1.Items.Add("Кантри");
            comboBox1.Items.Add("Техно");
            comboBox1.Items.Add("Классика");
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

            if (Settings.ThemeMult)
            {
                this.BackgroundImage = Image.FromFile("Fon6.jpg");
                button1.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                button1.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;
                comboBox1.ForeColor = Color.Black;
                comboBox1.BackColor = Color.White;
            }
            else
            {
                this.BackgroundImage = Image.FromFile("FonDark3.jpg");
                button1.BackColor = Color.Black;
                textBox1.BackColor = Color.Black;
                textBox2.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                textBox1.ForeColor = Color.White;
                textBox2.ForeColor = Color.White;
                comboBox1.ForeColor = Color.White;
                comboBox1.BackColor = Color.Black;
            }
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

                this.BackgroundImage = Image.FromFile("Fon6.jpg");
                button1.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                button1.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;
                comboBox1.ForeColor = Color.Black;
                comboBox1.BackColor = Color.White;
            }
            else
            {
                button3.Image = Image.FromFile("cloud.bmp");

                this.BackgroundImage = Image.FromFile("FonDark3.jpg");
                button1.BackColor = Color.Black;
                textBox1.BackColor = Color.Black;
                textBox2.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                textBox1.ForeColor = Color.White;
                textBox2.ForeColor = Color.White;
                comboBox1.ForeColor = Color.White;
                comboBox1.BackColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.SelectedClient = comboBox1.SelectedItem.ToString();
        }
    }
}
