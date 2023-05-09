using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster_Tetris.Model
{
    internal class Attributes
    {
        private System.Media.SoundPlayer player;
        private System.Media.SoundPlayer player1;
        private System.Media.SoundPlayer player2;
        private PictureBox pauseImage;
        private Image backgroundImage;
        public Attributes(int width, int height) {

            player = new System.Media.SoundPlayer();
            player.SoundLocation = "music.wav";
            player1 = new System.Media.SoundPlayer();
            player1.SoundLocation = "music2.wav";
            player2 = new System.Media.SoundPlayer();
            player2.SoundLocation = "music3.wav";

            pauseImage = new PictureBox();
            pauseImage.ImageLocation = "pause.png";
            pauseImage.Anchor = AnchorStyles.None;
            pauseImage.Size = new Size(300, 250);
            pauseImage.Location = new Point((width - pauseImage.Width) / 2, (height - pauseImage.Height) / 2);
            pauseImage.BackColor = Color.Transparent;

            backgroundImage = Image.FromFile("Fon6.jpg");            
        }
        public void Play()
        {
            //player.Play();
            //player1.Play();
            player2.Play();
        }
        public void Stop()
        {
            //player.Stop();
            //player1.Stop();
            player2.Stop();
        }
        public PictureBox PictureVisibleTrue() 
        {
            pauseImage.Visible = true;
            return pauseImage;
        }
        public PictureBox PictureVisibleFalse()
        {
            pauseImage.Visible = false;
            return pauseImage;
        }
        public Image SetBackground()
        {
            return backgroundImage;
        }
    }
}
