using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro
{
    public class VykreslovaciePole
    {
        private List<Bod> body = new List<Bod>();
        public List<Bod> Body { get  {return body; } set { body = value; } }

        public VykreslovaciePole(int rozmer)
        {
            for (int riadky = 0; riadky < rozmer; riadky++)
            {
                for (int stlpce = 0; stlpce < rozmer; stlpce++)
                {
                    body.Add(new Bod(riadky, stlpce, Colors.Black));
                }
            }
        }
    }
}
