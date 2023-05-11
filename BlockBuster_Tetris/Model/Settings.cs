using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster_Tetris.Model
{
    internal static class Settings
    {
        private static bool soundMult = true;
        private static bool themeMult = true;
        public static string SelectedClient;
        public static bool SoundMult
        {
            get { return soundMult; }
            set { soundMult = value; }
        }

        public static bool ThemeMult
        {
            get { return themeMult; }
            set { themeMult = value; }
        }


    }
}
