using BlockBuster_Tetris.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster_Tetris.Model
{
    internal class Records
    {
        private string recordPath = "Records.txt";

        public void SaveRecords(string playerName)
        {
            List<string> recordsArray = new List<string>(LoadRecords())
            {
                playerName + "|" + Controller.score + "|" + Controller.linesRemoved
            };
            recordsArray.Sort(new RecordsComparer());
            File.WriteAllLines(recordPath, recordsArray);
        }

        public IEnumerable<string> LoadRecords()
        {
            string[] recordsArray = File.ReadAllLines(recordPath);
            return recordsArray;
        }
        public class RecordsComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                string[] xFields = x.Split('|');
                string[] yFields = y.Split('|');

                int xScore = int.Parse(xFields[1]);
                int yScore = int.Parse(yFields[1]);

                if (xScore > yScore)
                {
                    return -1; 
                }
                else if (xScore < yScore)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public List<Record> LoadRecord()
        {
            List<Record> recordsList = new List<Record>();
            string[] recordsArray = File.ReadAllLines(recordPath);

            foreach (string record in recordsArray)
            {
                string[] fields = record.Split('|');
                if (fields.Length >= 3)
                {
                    int score = 0;
                    int lines = 0;
                    int.TryParse(fields[1], out score);
                    int.TryParse(fields[2], out lines);
                    Record rec = new Record(fields[0], score, lines);
                    recordsList.Add(rec);
                }
            }
            return recordsList;
        }

        public void ShowRecords(ListView listView)
        {
            listView.Items.Clear();

            List<Record> records = LoadRecord();

            for (int i = 0; i < records.Count; i++)
            {
                string[] fields = { (i + 1).ToString(), records[i].Name, records[i].Score.ToString(), records[i].Lines.ToString() };
                ListViewItem item = new ListViewItem(fields);
                listView.Items.Add(item);
            }
        }

        public class Record
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public int Lines { get; set; }

            public Record(string name, int score, int lines)
            {
                Name = name;
                Score = score;
                Lines = lines;
            }
        }
    }

}
