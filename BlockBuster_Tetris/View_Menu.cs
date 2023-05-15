using BlockBuster_Tetris.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster_Tetris
{
    public partial class View_Menu : Form
    {
        public View_Menu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            if (Settings.ThemeMult)
            {
                this.BackgroundImage = Image.FromFile("Fon6.jpg");
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                textBox1.BackColor = Color.White;

                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                button3.ForeColor = Color.Black;
                button4.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
            }
            else
            {
                this.BackgroundImage = Image.FromFile("FonDark3.jpg");
                button1.BackColor = Color.Black;
                button2.BackColor = Color.Black;
                button3.BackColor = Color.Black;
                button4.BackColor = Color.Black;
                textBox1.BackColor = Color.Black;

                button1.ForeColor = Color.White;
                button2.ForeColor = Color.White;
                button3.ForeColor = Color.White;
                button4.ForeColor = Color.White;
                textBox1.ForeColor = Color.White;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View view = new View(textBox1.Text);
            view.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Records view_Records = new View_Records();
            view_Records.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            View_Settings view_Settings = new View_Settings();
            //DialogResult childForm = view_Settings.Show();

            if (view_Settings.ShowDialog() == DialogResult.OK)
            {
                if (Settings.ThemeMult)
                {
                    this.BackgroundImage = Image.FromFile("Fon6.jpg");
                    button1.BackColor = Color.White;
                    button2.BackColor = Color.White;
                    button3.BackColor = Color.White;
                    button4.BackColor = Color.White;
                    textBox1.BackColor = Color.White;

                    button1.ForeColor = Color.Black;
                    button2.ForeColor = Color.Black;
                    button3.ForeColor = Color.Black;
                    button4.ForeColor = Color.Black;
                    textBox1.ForeColor = Color.Black;
                }
                else
                {
                    this.BackgroundImage = Image.FromFile("FonDark3.jpg");
                    button1.BackColor = Color.Black;
                    button2.BackColor = Color.Black;
                    button3.BackColor = Color.Black;
                    button4.BackColor = Color.Black;
                    textBox1.BackColor = Color.Black;

                    button1.ForeColor = Color.White;
                    button2.ForeColor = Color.White;
                    button3.ForeColor = Color.White;
                    button4.ForeColor = Color.White;
                    textBox1.ForeColor = Color.White;

                }
            }
        }
    }
}
