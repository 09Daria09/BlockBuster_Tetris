using System;
using System.Drawing;
using System.Windows.Forms;
using BlockBuster_Tetris.Model;
using BlockBuster_Tetris.Controllers;
using System.Threading;

namespace BlockBuster_Tetris
{
    public partial class View : Form
    {
        AttributesCotroller attributes = null;
        Thread thread = null;
        RecordsController records = null;
        string nameUser = null;
        public View(string name)
        {
            InitializeComponent();


            nameUser = name;
            attributes = new AttributesCotroller(ClientSize.Width, ClientSize.Height);
            thread = new Thread(() =>
            {
                attributes.PlayMusic();
            });
            thread.Start();
            if (!Settings.SoundMult)
            {
                thread.Abort();
            }
            Controls.Add((Control)attributes.PictureVisibleFalse());
            records = new RecordsController();
            KeyUp += new KeyEventHandler(keyFunc);

            if (Settings.ThemeMult)
            {
                this.BackgroundImage = Image.FromFile("Fon6.jpg");
                label1.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.BackColor = Color.White;
                label2.ForeColor = Color.Black;
                label3.BackColor = Color.White;
                label3.ForeColor = Color.Black;
            }
            else
            {
                this.BackgroundImage = Image.FromFile("FonDark3.jpg");
                label1.BackColor = Color.Black;
                label1.ForeColor = Color.White;
                label2.BackColor = Color.Black;
                label2.ForeColor = Color.White;
                label3.BackColor = Color.Black;
                label3.ForeColor = Color.White;
            }

            Init();
        }
        public void Init()
        {
            Controller.size = 35;
            Controller.score = 0;
            Controller.linesRemoved = 0;
            Controller.currentShape = new Block(3, 0);
            Controller.Interval = 1000;
            label1.Text = "Score: " + Controller.score;
            label2.Text = "Lines: " + Controller.linesRemoved;

            WindowState = FormWindowState.Maximized;
            timer1.Interval = Controller.Interval;
            timer1.Tick += new EventHandler(update);
            timer1.Start();

            Invalidate();
        }

        private void keyFunc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    if (!Controller.IsIntersects())
                    {
                        Controller.ResetArea();
                        Controller.currentShape.RotateBlock();
                        Controller.Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Space:
                    timer1.Interval = 10;
                    break;
                case Keys.Right:
                    if (!Controller.CollideHor(1))
                    {
                        Controller.ResetArea();
                        Controller.currentShape.MoveRight();
                        Controller.Merge();
                        Invalidate();
                    }
                    break;
                case Keys.Left:
                    if (!Controller.CollideHor(-1))
                    {
                        Controller.ResetArea();
                        Controller.currentShape.MoveLeft();
                        Controller.Merge();
                        Invalidate();
                    }
                    break;

                case Keys.Escape:
                    if (timer1.Enabled)
                    {
                        attributes.PictureVisibleTrue();
                        timer1.Stop();
                    }
                    else
                    {
                        attributes.PictureVisibleFalse();
                        timer1.Start();
                    }
                    break;
            }
        }


        private void update(object sender, EventArgs e)
        {

            Controller.ResetArea();
            if (!Controller.Collide())
            {
                Controller.currentShape.MoveDown();
            }
            else
            {
                Controller.Merge();
                Controller.SliceMap(label1, label2);
                timer1.Interval = Controller.Interval;
                Controller.currentShape.ResetBlock(3, 0);
                if (Controller.Collide())
                {
                    Controller.ClearMap();
                    timer1.Tick -= new EventHandler(update);
                    timer1.Stop();
                    MessageBox.Show("Ваш результат: " + Controller.score);
                    records.SaveRecords(nameUser);
                    Init();
                }
            }
            Controller.Merge();
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Controller.DrawGrid(e.Graphics);
            Controller.DrawMap(e.Graphics);
            Controller.ShowNextShape(e.Graphics);
        }

        private void OnAgainButtonClick(object sender, EventArgs e)
        {
            timer1.Tick -= new EventHandler(update);
            timer1.Stop();
            Controller.ClearMap();
            Init();
        }

        private void View_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            Controller.ClearMap();
            attributes.StopMusic();
            thread.Abort();
        }
    }
}
