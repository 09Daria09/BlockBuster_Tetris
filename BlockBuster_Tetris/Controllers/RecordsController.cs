using BlockBuster_Tetris.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster_Tetris.Controllers
{
    internal class RecordsController
    {
        Records records = new Records();
        public void SaveRecords(string name)
        {
            records.SaveRecords(name);
        }
        public void ShowRecords(ListView list)
        {
            records.ShowRecords(list);
        }
    }
}
