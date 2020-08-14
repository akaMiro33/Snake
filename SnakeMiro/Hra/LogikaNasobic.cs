using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro.Hra
{
    public class LogikaNasobic
    {
        public PrvokHryRozsireny nasobic;
    
        public Bod poslednyBod;
        public static int DlzkaDostupnosti { get; set; }
        public static int Perioda { get; set; }
        Random random = new Random();
        public bool Posobi { get; set; }

        private static Color farbaNasobic = Colors.Green;

        public static int DlzkaPosobenia { get; set; }

        SpravaHudby hudba;

        public LogikaNasobic(SpravaHudby paHudba)
        {
            nasobic = new PrvokHryRozsireny(farbaNasobic);

            vygenerujPeriodu();
            Posobi = false;

            hudba = paHudba;
        }

        public void vygenerujDlzkuDostupnosti()
        {
            DlzkaDostupnosti = random.Next(15, 55);
        }

        public void vygenerujPeriodu()
        {
            // Perioda = random.Next(350, 500); //stale
            Perioda = random.Next(56, 57); // docasne
        }

        public void sprava(Had had, VykreslovaciePole pole, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
        {
            generovanieSpravania(had, pole, bodInehoPrvku, bodInehoPrvkuTwo);
            kontrolaCiHadZjedol(had, pole);
        }

        private void kontrolaCiHadZjedol(Had had, VykreslovaciePole pole)
        {

            if (had.zjedolPrvokHryRozsireny(nasobic))

            {
                hudba.prehrajHudbaZdvojnasobenia();

                nasobic.nedostupny(pole.Body, poslednyBod);
                DlzkaPosobenia = 150;
                Posobi = true;
            }

        }


        private void generovanieSpravania(Had had, VykreslovaciePole pole, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
        {
            generovanie(had, pole, bodInehoPrvku, bodInehoPrvkuTwo);
            logikaDostupnosti(pole);
            logikaPosobenia();

        }

        private void generovanie(Had had, VykreslovaciePole pole, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
        {
            if (Perioda == 0)
            {
                poslednyBod = nasobic.getBod;
                nasobic.vygenerujSuradnice(had, pole.Body, bodInehoPrvku, bodInehoPrvkuTwo);
                vygenerujDlzkuDostupnosti();
                vygenerujPeriodu();
            }
            Perioda--;
        }

        private void logikaDostupnosti(VykreslovaciePole pole)
        {
            if (DlzkaDostupnosti == 0)
            {
                nasobic.nedostupny(pole.Body, poslednyBod);
            }

            DlzkaDostupnosti--;
        }

        private void logikaPosobenia()
        {
            if (DlzkaPosobenia > 0)
            {
                DlzkaPosobenia--;
            }
            else
            {
                Posobi = false;
                hudba.zastavHudbaZdvojnasobenia();
            }

        }

    }
}
