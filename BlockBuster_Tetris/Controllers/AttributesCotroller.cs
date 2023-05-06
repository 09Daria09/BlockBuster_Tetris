using BlockBuster_Tetris.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster_Tetris.Controllers
{
    internal class AttributesCotroller
    {
        Attributes music = null;
        public AttributesCotroller()
        {
            music = new Attributes();
        }
        public void PlayMusic()
        {
            music.Play();
        }
        public void StopMusic() 
        {
            music.Stop();
        }   
    }
}

