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
            List<string> recordsArray = new List<string>(LoadRecord());
            bool isNameExistsInRecords = false;

            for (int i = 0; i < recordsArray.Count; i++)
            {
                string[] record = recordsArray[i].Split('|');

                if (playerName == record[0])
                {
                    isNameExistsInRecords = true;
                    recordsArray.RemoveAt(i);
                    recordsArray.Add(playerName + "|" + Controller.score + "|" + Controller.linesRemoved);
                }
            }
            if (!isNameExistsInRecords)
            {
                recordsArray.Add(playerName + "|" + Controller.score + "|" + Controller.linesRemoved);
            }
            using (StreamWriter writer = new StreamWriter(recordPath, true))
            {
                foreach (string record in recordsArray)
                {
                    writer.WriteLine(record);
                }
            }

        }

        public IEnumerable<string> LoadRecord()
        {
            string[] recordsArray = File.ReadAllLines(recordPath);
            foreach (string line in recordsArray)
            {
                yield return line;
            }
        }

        public List<Record> LoadRecords()
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

            List<Record> records = LoadRecords();

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
