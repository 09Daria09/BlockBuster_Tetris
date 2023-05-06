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
        public Attributes() {
            player = new System.Media.SoundPlayer();
            player.SoundLocation = "music.wav";
            player1 = new System.Media.SoundPlayer();
            player1.SoundLocation = "music2.wav";
        }
        public void Play()
        {
            player.Play();
            player1.Play();
        }
        public void Stop()
        {
            player.Stop();
            player1.Stop();
        }
    }
}
