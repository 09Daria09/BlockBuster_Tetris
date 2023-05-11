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
        private System.Media.SoundPlayer djaz;
        private System.Media.SoundPlayer cantri;
        private System.Media.SoundPlayer texno;
        private System.Media.SoundPlayer classic;
        private PictureBox pauseImage;
        private Image backgroundImage;
        public Attributes(int width, int height)
        {

            djaz = new System.Media.SoundPlayer();
            djaz.SoundLocation = "music3.wav";

            cantri = new System.Media.SoundPlayer();
            cantri.SoundLocation = "cantri.wav";

            texno = new System.Media.SoundPlayer();
            texno.SoundLocation = "texno.wav";

            classic = new System.Media.SoundPlayer();
            classic.SoundLocation = "music2.wav";

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
            if (Settings.SelectedClient == "Джаз")
            {
                djaz.Play();
            }
            if (Settings.SelectedClient == "Кантри")
            {
                cantri.Play();
            }
            if (Settings.SelectedClient == "Техно")
            {
                texno.Play();
            }
            if (Settings.SelectedClient == "Классика")
            {
                classic.Play();
            }
        }
        public void Stop()
        {
            if (Settings.SelectedClient == "Джаз")
            {
                djaz.Stop();
            }
            if (Settings.SelectedClient == "Кантри")
            {
                cantri.Stop();
            }
            if (Settings.SelectedClient == "Техно")
            {
                texno.Stop();
            }
            if (Settings.SelectedClient == "Классика")
            {
                classic.Stop();
            }
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
