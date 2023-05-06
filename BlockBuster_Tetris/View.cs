using System;
using System.Drawing;
using System.Windows.Forms;
using BlockBuster_Tetris.Model;
using BlockBuster_Tetris.Controllers;


namespace BlockBuster_Tetris
{
    public partial class View : Form
    {
        private PictureBox pauseImage;
        AttributesCotroller music = null;

        public View()
        {
            InitializeComponent();

            pauseImage = new PictureBox();
            pauseImage.ImageLocation = "pause.png";
            pauseImage.Anchor = AnchorStyles.None;
            pauseImage.Size = new Size(300, 250); 
            pauseImage.Location = new Point((this.ClientSize.Width - pauseImage.Width) / 2, (this.ClientSize.Height - pauseImage.Height) / 2);
            pauseImage.Visible = false;
            pauseImage.BackColor = Color.Transparent;
            this.Controls.Add(pauseImage);

            music = new AttributesCotroller();
            music.PlayMusic();

            this.KeyUp += new KeyEventHandler(keyFunc);
            Init();
        }
        public void Init()
        {

            //this.Text = "Тетрис: Текущий игрок - " + playerName;
            Controller.size = 35;
            Controller.score = 0;
            Controller.linesRemoved = 0;
            Controller.currentShape = new Block(3, 0);
            Controller.Interval = 1000;
            label1.Text = "Score: " + Controller.score;
            label2.Text = "Lines: " + Controller.linesRemoved;

            WindowState = FormWindowState.Maximized;
            Image backgroundImage = Image.FromFile("Fon.jpg");

            this.BackgroundImage = backgroundImage;

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
                        pauseImage.Visible = true;
                        timer1.Stop();
                    }
                    else
                    {
                        pauseImage.Visible = false;
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

        
    }
}
