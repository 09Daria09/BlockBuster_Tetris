using BlockBuster_Tetris.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster_Tetris
{
    public partial class Result : Form
    {
        public Result(string score, string line)
        {
            InitializeComponent();
            label1.Text = score; 
            label2.Text = line;

            if (Settings.ThemeMult)
            {
                this.BackgroundImage = Image.FromFile("LittleFon.jpg");
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;

                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }
            else
            {
                this.BackgroundImage = Image.FromFile("FonDark3.jpg");
                button1.BackColor = Color.Black;
                button2.BackColor = Color.Black;
                textBox1.BackColor = Color.Black;
                textBox2.BackColor = Color.Black;
                label1.BackColor = Color.Black;
                label2.BackColor = Color.Black;

                button1.ForeColor = Color.White;
                button2.ForeColor = Color.White;
                textBox1.ForeColor = Color.White;
                textBox2.ForeColor= Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;

            }
        }
    }
}
