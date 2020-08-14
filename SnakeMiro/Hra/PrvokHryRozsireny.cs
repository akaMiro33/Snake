using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro.Hra
{
    public class PrvokHryRozsireny : PrvokHry
    {
        public bool Aktivny { get; private set; }
        protected static Color farbaSpomalovac = Colors.Yellow;
        protected static Color farbaNasobic = Colors.Green;
        private Color farba;


        public PrvokHryRozsireny(Color paFarba) : base()
        {
            bod.Color = Colors.Black;
            Aktivny = false;
            farba = paFarba;
        }

        public override void vygenerujSuradnice(Had had, List<Bod> plocha, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
        {
            Aktivny = true;

            base.vygenerujSuradnice(had, plocha, bodInehoPrvku, bodInehoPrvkuTwo);
            bod.Color = farba;
        }

        public void nedostupny(List<Bod> plocha, Bod poslednyBodSpomalovaca)
        {
            Aktivny = false;
            poslednyBodSpomalovaca = bod;
            base.vybielStaryBod(plocha);
        }
    }
}
