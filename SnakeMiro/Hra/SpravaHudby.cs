using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMiro.Hra
{
    public class SpravaHudby
    {
        private SoundPlayer spapaniejedla;
        private SoundPlayer zrychlenieHry;
        private SoundPlayer spapanieSpomalenia;
        private SoundPlayer naburanie;
        private SoundPlayer hudbaZdvojnasobenia;
        private bool hraZdvojnasobenie;


        public SpravaHudby()
        {
            spapaniejedla = new SoundPlayer();
            spapaniejedla.SoundLocation = System.IO.Directory.GetCurrentDirectory() + "\\jedloZjedenie.wav";

            zrychlenieHry = new SoundPlayer();
            zrychlenieHry.SoundLocation = System.IO.Directory.GetCurrentDirectory() + "\\zrychlenieHry.wav";

            spapanieSpomalenia = new SoundPlayer();
            spapanieSpomalenia.SoundLocation = System.IO.Directory.GetCurrentDirectory() + "\\spapanieSpomalenia.wav";

            naburanie = new SoundPlayer();
            naburanie.SoundLocation = System.IO.Directory.GetCurrentDirectory() + "\\naburanieMelody.wav";

            hudbaZdvojnasobenia = new SoundPlayer();
            hudbaZdvojnasobenia.SoundLocation = System.IO.Directory.GetCurrentDirectory() + "\\zrychlenizo.wav";

            hraZdvojnasobenie = false;
        }

        public void prehrajSpapaniejedla()
        {
            if(!hraZdvojnasobenie)
            spapaniejedla.Play();
        }

        public void prehrajZrychlenieHry()
        {
            if (!hraZdvojnasobenie)
                zrychlenieHry.Play();
        }

        public void prehrajSpapanieSpomalenia()
        {
            if (!hraZdvojnasobenie)
                spapanieSpomalenia.Play();
        }

        public void prehrajNaburanie()
        {
            if (!hraZdvojnasobenie)
                naburanie.Play();
        }

        public void prehrajHudbaZdvojnasobenia()
        {
            hudbaZdvojnasobenia.PlayLooping();
            hraZdvojnasobenie = true;
        }

        public void zastavHudbaZdvojnasobenia()
        {
            if(hraZdvojnasobenie)
            { 
                hudbaZdvojnasobenia.Stop();
                hraZdvojnasobenie = false;
            }
    }
    }
}

