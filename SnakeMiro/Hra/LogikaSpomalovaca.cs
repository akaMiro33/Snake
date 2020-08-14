using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro.Hra
{
    public class LogikaSpomalovaca
    {
        public PrvokHryRozsireny spomalovac;
        public Bod poslednyBod;
        public static int DlzkaDostupnosti { get; set; }
        public static int Perioda { get; set; }
        Random random = new Random();
        private SpravaHudby hudba;

        private static Color farbaSpomalovac = Colors.Yellow;

        public LogikaSpomalovaca(SpravaHudby paHudba)
        {
            spomalovac = new PrvokHryRozsireny(farbaSpomalovac);
            vygenerujPeriodu();
            hudba = paHudba;
        }

        public void vygenerujDlzkuDostupnosti()
        {
            DlzkaDostupnosti = random.Next(15, 45);
        }

        public void vygenerujPeriodu()
        {
            Perioda = random.Next(700, 1000);
        }

        public void sprava(Had had, VykreslovaciePole pole, Bod bodInehoPrvkuOne, Bod bodInehoPrvkuTwo)
        {
            generovanie(had, pole, bodInehoPrvkuOne, bodInehoPrvkuTwo);           
            kontrolaCiHadZjedol(had, pole);       
        }

        private void kontrolaCiHadZjedol(Had had, VykreslovaciePole pole)
        {
            if (had.zjedolPrvokHryRozsireny(spomalovac))

            {
                hudba.prehrajSpapanieSpomalenia();
                spomalovac.nedostupny(pole.Body, poslednyBod);
                GlobalnePremenne.rychlostHry *= 1.25;
            }
        }


        private void generovanie(Had had, VykreslovaciePole pole, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
        {
            if (Perioda == 0)
            {
                poslednyBod = spomalovac.getBod;
                spomalovac.vygenerujSuradnice(had, pole.Body, bodInehoPrvku, bodInehoPrvkuTwo);
                vygenerujDlzkuDostupnosti();
                vygenerujPeriodu();
            }

            Perioda--;

            if (DlzkaDostupnosti == 0)
            {
                spomalovac.nedostupny(pole.Body, poslednyBod);
            }

            DlzkaDostupnosti--;
        }
    }

}
