using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMiro.Hra
{
    class AutomatickeNastavenieSmeru
    {
        public void nastavSmer(Jedlo jedlo, Had had)
        {
                nastavSmerZaJedlu(jedlo, had);
        }

        public void nastavSmerZaJedlu(Jedlo jedlo,Had had)
        {
            if (had.getHlavu().Y < jedlo.getBod.Y)
                ovladajDoleAutomat(had);

            if (had.getHlavu().Y > jedlo.getBod.Y)
                ovladajHoreAutomat(had);

            if (had.getHlavu().X < jedlo.getBod.X)
                ovladajVpravoAutomat(had);

            if (had.getHlavu().X > jedlo.getBod.X)
                ovladajVlavoAutomat(had);
        }

        private void ovladajHoreAutomat(Had had)
        {
            if (had.moznyPohybHore())
            {
                had.smer = Smer.Hore;
                if (had.naburanieDoSeba())
                    had.smer = Smer.Vpravo;
                if (had.naburanieDoSeba())
                    had.smer = Smer.Vlavo;
            }
        }

        private void ovladajVlavoAutomat(Had had)
        {
            if (had.moznyPohybVlavo())
            {
                had.smer = Smer.Vlavo;
                if (had.naburanieDoSeba())
                    had.smer = Smer.Hore;
                if (had.naburanieDoSeba())
                    had.smer = Smer.Dole;
            }
        }

        private void ovladajVpravoAutomat(Had had)
        {
            if (had.moznyPohybVpravo())
            {
                had.smer = Smer.Vpravo;
                if (had.naburanieDoSeba())
                    had.smer = Smer.Dole;
                if (had.naburanieDoSeba())
                    had.smer = Smer.Hore;
            }
        }

        private void ovladajDoleAutomat(Had had)
        {
            if (had.moznyPohybDole())
            {
                had.smer = Smer.Dole;
                if (had.naburanieDoSeba())
                    had.smer = Smer.Vlavo;
                if (had.naburanieDoSeba())
                    had.smer = Smer.Vpravo;
            }
        }

    }
    }

