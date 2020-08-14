using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMiro.Hra
{
    class HadPriechodny : Had
    {
        public HadPriechodny() : base()
        {
            bodyHada.Add(new Bod(5, 5, farbaHlavyPriechodny)); // hlava
        }

        public override bool pohyb()
        {
            switch (smer)
            {
                case Smer.Hore:
                    pohybHorePreHadaCezStenu();
                    break;
                case Smer.Dole:
                    pohybDolePreHadaCezStenu();
                    break;
                case Smer.Vpravo:
                    pohybVpravoPreHadaCezStenu();
                    break;
                case Smer.Vlavo:
                    pohybVlavoPreHadaCezStenu();
                    break;
                default:
                    pohybVseobecneFunkcny(SmerFunkcny.VPRAVO);
                    //pohybPravo();
                    break;
            }

            return true;
        }

        private void prechodCezStenuHore()
        {
            bodyHada.Add(new Bod(getHlavu().X, RozmerPola - 1));
            nastavFarby();
        }

        private void prechodCezStenuDole()
        {
            bodyHada.Add(new Bod(getHlavu().X, 0));
            nastavFarby();
        }

        private void prechodCezStenuPravo()
        {
            bodyHada.Add(new Bod(0, getHlavu().Y));
            nastavFarby();
        }

        private void prechodCezStenuLavo()
        {
            bodyHada.Add(new Bod(RozmerPola - 1, getHlavu().Y));
            nastavFarby();
        }

        private void pohybHorePreHadaCezStenu()
        {
            if (stretZoStenouHore())
                prechodCezStenuHore();
            else pohybVseobecneFunkcny(SmerFunkcny.HORE); //pohybHore();
        }

        private void pohybDolePreHadaCezStenu()
        {
            if (stretZoStenouDole())
                prechodCezStenuDole();
            else pohybVseobecneFunkcny(SmerFunkcny.DOLE); //pohybDole();
        }

        private void pohybVpravoPreHadaCezStenu()
        {
            if (stretZoStenouVpravo())
                prechodCezStenuPravo();
            else pohybVseobecneFunkcny(SmerFunkcny.VPRAVO); //pohybPravo();
        }

        private void pohybVlavoPreHadaCezStenu()
        {
            if (stretZoStenouVlavo())
                prechodCezStenuLavo();
            else pohybVseobecneFunkcny(SmerFunkcny.VLAVO); //pohybLavo();
        }


        public override  bool moznyPohybHore()
        {
            return moznyPohybVseobecne( 0, -1) && moznyPohybHoreCezSteny(RozmerPola);
        }

        private bool moznyPohybHoreCezSteny(int rozmer)
        {
            return !(getHlavu().X == getKrk().X
               && (getKrk().Y - getHlavu().Y) == RozmerPola - 1);
        }

        public override bool moznyPohybDole()
        {
            return moznyPohybVseobecne( 0, 1) && moznyPohybDoleCezSteny(RozmerPola);
        }

        private bool moznyPohybDoleCezSteny(int rozmer)
        {
            return !(getHlavu().X == getKrk().X
               && (getHlavu().Y - getKrk().Y == RozmerPola - 1));
        }


        public override bool moznyPohybVpravo()
        {
            return moznyPohybVseobecne( 1, 0) && moznyPohybVpravoCezSteny(RozmerPola);
        }

        private bool moznyPohybVpravoCezSteny(int rozmer)
        {
            return !(getHlavu().Y == getKrk().Y
               && (getHlavu().X - getKrk().X == rozmer - 1));
        }

        public override bool moznyPohybVlavo()
        {
            return moznyPohybVseobecne( -1, 0) && moznyPohybVlavoCezSteny(RozmerPola);
        }

        private bool moznyPohybVlavoCezSteny(int rozmer)
        {
            return !(getHlavu().Y == getKrk().Y
               && (getKrk().X - getHlavu().X == rozmer - 1));
        }

        protected override void nastavFarby()
        {
            bodyHada.ElementAt(bodyHada.Count - 2).Color = farbaTela;
            zmenFarbuHlavy(farbaHlavyPriechodny);
        }
    }
}
