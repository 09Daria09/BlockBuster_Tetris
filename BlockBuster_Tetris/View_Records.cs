using BlockBuster_Tetris.Controllers;
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
    public partial class View_Records : Form
    {
        RecordsController records;
        public View_Records()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
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
