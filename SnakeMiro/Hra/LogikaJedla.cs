using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro.Hra
{
    public class LogikaJedla
    {
        public Jedlo jedlo;
        public static int ZjedeneOdZrychlenia { get; set; }
        public Bod poslednyBodHada;

        public const int PeriodaZrychlenia = 20;
        public const int ZvysenieSkore = 100;

        public bool DalsiPohybJeDvojnasobny = false;

        private SpravaHudby hudba;

        public LogikaJedla(SpravaHudby paHudba)
        {
            jedlo = new Jedlo();
            ZjedeneOdZrychlenia = 0;

            hudba = paHudba;
        }

        public void generuj(Had had, VykreslovaciePole pole, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
        {
            jedlo.vygenerujSuradnice(had, pole.Body, bodInehoPrvku, bodInehoPrvkuTwo);
        }

        public void sprava(Had had, VykreslovaciePole pole, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo, bool aktivnyNasobic)
        {
            if (!aktivnyNasobic)
            {
                spravaNeaktNasobic(had, pole, bodInehoPrvku, bodInehoPrvkuTwo);
            }
            else
            {
                spravaAktNasobic(had, pole, bodInehoPrvku, bodInehoPrvkuTwo);
            }
        }

        private void spravaNeaktNasobic(Had had, VykreslovaciePole pole, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
        {
            if (had.zjedolJedlo(jedlo))
            {
                if (ZjedeneOdZrychlenia + 1 != PeriodaZrychlenia)
                {
                  // SpravaHudby hudba = new SpravaHudby();
                   hudba.prehrajSpapaniejedla();
                }
                jedlo.vygenerujSuradnice(had, pole.Body, bodInehoPrvku, bodInehoPrvkuTwo);

                ZjedeneOdZrychlenia++;
                GlobalnePremenne.skore += ZvysenieSkore;
            }
            else
            {
                poslednyBodHada = new Bod(had.getChvost().X, had.getChvost().Y, Colors.Black);
                had.vymazChvost();
            }
        }

        private void spravaAktNasobic(Had had, VykreslovaciePole pole, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
        {
            if (had.zjedolJedlo(jedlo))
            {
                if (ZjedeneOdZrychlenia + 1  != PeriodaZrychlenia)
                { 
                 //   SpravaHudby hudba = new SpravaHudby();
                    hudba.prehrajSpapaniejedla();
                }       
                jedlo.vygenerujSuradnice(had, pole.Body, bodInehoPrvku, bodInehoPrvkuTwo);
                DalsiPohybJeDvojnasobny = true;
                ZjedeneOdZrychlenia++;
                GlobalnePremenne.skore += ZvysenieSkore;
            }
            else
            {
                kontrolaDvojnasobnosti(had);
            }           
        }
        private void kontrolaDvojnasobnosti(Had had)
        {
            if (DalsiPohybJeDvojnasobny)
            {
                DalsiPohybJeDvojnasobny = false;
                GlobalnePremenne.skore += ZvysenieSkore;
            }
            else
            {
                poslednyBodHada = new Bod(had.getChvost().X, had.getChvost().Y, Colors.Black);
                had.vymazChvost();
            }
        }

        public void logikaZvysovaniaRychlosti()
        {
            if (ZjedeneOdZrychlenia == PeriodaZrychlenia)
            {
              //  SpravaHudby hudba = new SpravaHudby();
                hudba.prehrajZrychlenieHry();
               
                ZjedeneOdZrychlenia = 0;
                GlobalnePremenne.rychlostHry *= 0.8;
            }
        }   
    }
}
