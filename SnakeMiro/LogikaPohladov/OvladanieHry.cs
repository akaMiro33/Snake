using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace SnakeMiro.LogikaPohladov
{
    public class OvladanieHry
    {
        public bool Automat { get; set; }

        public OvladanieHry (bool paAutomat)
        {
            Automat = paAutomat;
        }

        public void Ovladaj(Key key, Had had , DispatcherTimer timer)
        {
            if (key == Key.P)
                OvladaniePauzyHry(timer);
            else if(!Automat)
                OvladajHada(key, had);
                 else { }
        }
        private void OvladaniePauzyHry(DispatcherTimer timer)
        {
            if (timer.IsEnabled)
                timer.Stop();
            else
                timer.Start();
        }

        private void OvladajHada(Key key , Had had) 
        { 
            switch (key)
            {
                case Key.Left:
                {
                    ovladajVlavo(had);
                    break;
                }
                case Key.Right:
                {
                    ovladajVpravo(had);
                    break;
                }
                case Key.Down:
                {
                    ovladajDole(had);
                    break;
                }
                case Key.Up:
                {
                    ovladajHore(had);
                    break;
                }
            }
        }

       private void ovladajHore(Had had)
        {
            if (had.moznyPohybHore())
                had.smer = Smer.Hore;
            
        }

        private void ovladajVlavo(Had had)
        {
            if (had.moznyPohybVlavo())
                had.smer = Smer.Vlavo;
            
        }
        
        private void ovladajVpravo(Had had)
        {
            if (had.moznyPohybVpravo())
                had.smer = Smer.Vpravo;

        }

        private void ovladajDole(Had had)
        {
            if (had.moznyPohybDole())
                had.smer = Smer.Dole;
        }

    }
}
