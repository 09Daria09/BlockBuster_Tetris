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
        Attributes attributes = null;
        public AttributesCotroller(int width, int hight)
        {
            attributes = new Attributes(width, hight);
        }
        public void PlayMusic()
        {
            attributes.Play();
        }
        public void StopMusic() 
        {
            attributes.Stop();
        }   
        public object PictureVisibleTrue()
        {
           return attributes.PictureVisibleTrue();
        }
        public object PictureVisibleFalse()
        {
            return attributes.PictureVisibleFalse();
        }
        public object SetBackground()
        {
            return attributes.SetBackground();
        }
    }
}

