using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMiro.Hra
{
    public class SmerFunkcny
    {
        public static readonly SmerFunkcny HORE = new SmerFunkcny(0, -1);

        public static readonly SmerFunkcny DOLE = new SmerFunkcny(0, 1);

        public static readonly SmerFunkcny VLAVO = new SmerFunkcny(-1, 0);

        public static readonly SmerFunkcny VPRAVO = new SmerFunkcny(1, 0);

        public int X { get; }

        public int Y { get; }

        public static IEnumerable<SmerFunkcny> Values
        {
            get
            {
                yield return HORE;
                yield return DOLE;
                yield return VLAVO;
                yield return VPRAVO;
            }
        }

        private SmerFunkcny(int deltaX, int deltaY)
        {
            this.X = deltaX;
            this.Y = deltaY;
        }

    }
}
