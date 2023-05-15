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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BlockBuster_Tetris
{
    public partial class Menu_Control : Form
    {
        public Menu_Control()
        {
            InitializeComponent();
            Settings.ThemeMult = !Settings.ThemeMult;
            if (Settings.ThemeMult)
            {
                this.BackgroundImage = Image.FromFile("FonDark3.jpg");
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                label1.BackColor = Color.Black;
                label1.ForeColor = Color.White;
                label2.BackColor = Color.Black;
                label2.ForeColor = Color.White;
                label3.BackColor = Color.Black;
                label3.ForeColor = Color.White;
                label4.BackColor = Color.Black;
                label4.ForeColor = Color.White;
                label5.BackColor = Color.Black;
                label5.ForeColor = Color.White;
            }
            else
            {
                this.BackgroundImage = Image.FromFile("LittleFon2.jpg");
                button1.BackColor = Color.White;
                button1.ForeColor = Color.Black;
                label1.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.BackColor = Color.White;
                label2.ForeColor = Color.Black;
                label3.BackColor = Color.White;
                label3.ForeColor = Color.Black;
                label4.BackColor = Color.White;
                label4.ForeColor = Color.Black;
                label5.BackColor = Color.White;
                label5.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
