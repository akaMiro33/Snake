using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro
{
    public class Bod
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        public Bod(int paX , int paY)
        {
            X = paX;
            Y = paY;
        }

        public Bod(int paX, int paY, Color paColor)
        {
            X = paX;
            Y = paY;
            Color = paColor;
        }


        public Bod()
        {
            X = 0;
            Y = 0;
        }
    }
}
