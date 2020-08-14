using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro.Hra
{
    public class HadNepriechodny : Had
    {

        public HadNepriechodny() : base()
        {
            bodyHada.Add(new Bod(5, 5, farbaHlavyNepriechodny)); // hlava
        }

        public override bool pohyb()
        {
            switch (smer)
            {
                case Smer.Hore:
             
                    pohybVseobecneFunkcny(SmerFunkcny.HORE);
                    break;
                case Smer.Dole:
                    
                    pohybVseobecneFunkcny(SmerFunkcny.DOLE);
                    break;
                case Smer.Vpravo:
                   
                    pohybVseobecneFunkcny(SmerFunkcny.VPRAVO);
                    break;
                case Smer.Vlavo:
                   
                    pohybVseobecneFunkcny(SmerFunkcny.VLAVO);
                    break;
                default:
                    
                    pohybVseobecneFunkcny(SmerFunkcny.VPRAVO);
                    break;
            }

            return true;
        }


        public override bool moznyPohybHore()
        {
            return moznyPohybVseobecne( 0, -1);
        }

        public override bool moznyPohybDole()
        {
            return moznyPohybVseobecne( 0, 1);
        }

        public override bool moznyPohybVpravo()
        {
            return moznyPohybVseobecne( 1, 0);
        }

        public override bool moznyPohybVlavo()
        {
            return moznyPohybVseobecne( -1, 0);
        }

    }
}
