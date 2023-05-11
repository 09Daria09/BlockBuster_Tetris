using BlockBuster_Tetris.Controllers;
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
    public partial class View_Records : Form
    {
        RecordsController records;
        public View_Records()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            if (Settings.ThemeMult)
            {
                this.BackgroundImage = Image.FromFile("Fon6.jpg");
                listView1.BackgroundImage = Image.FromFile("Fon6.jpg");
                listView1.ForeColor = Color.White;
                listView1.BackColor = Color.White;
            }
            else
            {
                this.BackgroundImage = Image.FromFile("FonDark3.jpg");
                listView1.BackgroundImage = Image.FromFile("FonDark.jpg");
                listView1.ForeColor = Color.White; 
                listView1.BackColor = Color.White;

            }

            records = new RecordsController();

            int columnWidth = 320;
            listView1.Columns.Add("Место", columnWidth);
            listView1.Columns.Add("Игрок", columnWidth);
            listView1.Columns.Add("Очки", columnWidth);
            listView1.Columns.Add("Линии", columnWidth);

            records.ShowRecords(listView1);
        }
    }
}
