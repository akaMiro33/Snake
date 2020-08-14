using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro.Hra
{
    public abstract class PrvokHry
    {
        protected Bod bod;
        protected Random random = new Random();

        public virtual Bod getBod { get { return bod; } }

        public PrvokHry()
        {
            bod = new Bod();
        }

        public virtual void vygenerujSuradnice(Had had, List<Bod> plocha, Bod bodInehoPrvkuOne, Bod bodInehoPrvkuTwo)
        {
            vybielStaryBod(plocha);
            List<Bod> pomocneBody = plocha.ToList();

            pomocneBody.RemoveAll(plo => had.BodyHada.ToList().Exists(h => h.X == plo.X
                                                                        && h.Y == plo.Y));
            pomocneBody.Remove(bodInehoPrvkuOne);
            pomocneBody.Remove(bodInehoPrvkuTwo);
            bod = pomocneBody.Skip(random.Next(pomocneBody.Count)).Take(1).ToList().First();
        }

        protected void vybielStaryBod(List<Bod> plocha)
        {
            plocha.Where(plo => plo.X == bod.X
                             && plo.Y == bod.Y).First().Color = Colors.Black;    
        }
    }
}
