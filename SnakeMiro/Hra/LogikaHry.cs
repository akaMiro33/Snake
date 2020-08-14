using SnakeMiro.Hra;
using SnakeMiro.LogikaPohladov;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Shapes;

namespace SnakeMiro
{
    public class LogikaHry 
    {
        
        private VykreslovaciePole pole = new VykreslovaciePole(Had.RozmerPola);
        private Had had;

        private LogikaSpomalovaca logSpomalovaca;
        private LogikaJedla logJedla;
        private LogikaNasobic logNasobic;

        public bool jeKoniecHry = false;        

        public VykreslovaciePole Pole { get { return pole; } set { pole = value; } }
        public Had Had { get {return had; } private set {; } }
 
        public const int UvodnaRychlost = 120;

        private SpravaHudby hudba; 

        public LogikaHry(MenuItem pevneSteny)
        {
            hudba = new SpravaHudby();
            logSpomalovaca = new LogikaSpomalovaca(hudba);
            logJedla = new LogikaJedla(hudba);
            logNasobic = new LogikaNasobic(hudba);

            GlobalnePremenne.skore = 0;
            GlobalnePremenne.rychlostHry = UvodnaRychlost;

            nastavTypHada(pevneSteny);

        }
        
        public void nastavTypHada(MenuItem pevneSteny)
        {
            if (pevneSteny.IsChecked)
                had = new HadNepriechodny();
            else
                had = new HadPriechodny();

            logJedla.generuj(had, pole, logNasobic.nasobic.getBod, logSpomalovaca.spomalovac.getBod);
        }

        public void typHry()
        {
            if (had is HadNepriechodny)
                logikaHryNepriechodny();
            else
                logikaHryPriechodny();
        }

        private void logikaHryPriechodny()
        {
            if (had.naburanieDoSeba())
            { 
                jeKoniecHry = true;
                hudba.prehrajNaburanie();
            }
            else
            {
               chodHry();
            }            
        }

        private void logikaHryNepriechodny()
        {
            if (naburanieDoSteny() || had.naburanieDoSeba())
            { 
                jeKoniecHry = true;
                hudba.prehrajNaburanie();
            }
            else
            {
                chodHry();
            }            
        }

        public void logikaHryNepriechodnyAutomat()
        {
            if (naburanieDoSteny() || had.naburanieDoSeba())
                jeKoniecHry = true;
            else
            {
                AutomatickeNastavenieSmeru ss = new AutomatickeNastavenieSmeru();
                chodHry();
                 ss.nastavSmer(logJedla.jedlo, had);
            }
        }

        private void chodHry()
        {
            had.pohyb();
            logJedla.sprava(had, pole, logNasobic.nasobic.getBod, logSpomalovaca.spomalovac.getBod, logNasobic.Posobi);
            logJedla.logikaZvysovaniaRychlosti();
            logSpomalovaca.sprava(had, pole, logJedla.jedlo.getBod, logNasobic.nasobic.getBod);
            logNasobic.sprava(had, pole, logJedla.jedlo.getBod, logSpomalovaca.spomalovac.getBod);
        }
     
        private bool naburanieDoSteny()
        {
            return had.stretZoStenouVlavo()  ||
                   had.stretZoStenouHore()   ||
                   had.stretZoStenouVpravo() ||
                   had.stretZoStenouDole();          
        }
         
        public void nakresliBod(Bod bod, List<List<Rectangle>> zoznamStvorcov)
        {
            zoznamStvorcov[bod.X][bod.Y].Fill = new SolidColorBrush(bod.Color);
        }

        public void nakresliPohybliveObjekty(List<List<Rectangle>> zoznamStvorcov)
        {
           if (!(logSpomalovaca.poslednyBod == null))
                nakresliBod(logSpomalovaca.poslednyBod, zoznamStvorcov);

            if (!(logNasobic.poslednyBod == null))
                nakresliBod(logNasobic.poslednyBod, zoznamStvorcov);

            nakresliBod(logJedla.jedlo.getBod, zoznamStvorcov);
            nakresliBod(logSpomalovaca.spomalovac.getBod, zoznamStvorcov);


            nakresliBod(logNasobic.nasobic.getBod, zoznamStvorcov);

            Had.BodyHada.ForEach(bod => { nakresliBod(bod, zoznamStvorcov); });
            if (!(logJedla.poslednyBodHada == null))
                nakresliBod(logJedla.poslednyBodHada, zoznamStvorcov);
        }

        public void nakresliHraciePole(List<List<Rectangle>> zoznamStvorcov)
        {
            Pole.Body.ForEach(bod => { nakresliBod(bod, zoznamStvorcov); });
        }
    }    
}
