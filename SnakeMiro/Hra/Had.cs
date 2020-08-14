using SnakeMiro.Hra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro
{
    public abstract class Had
    {
        protected List<Bod> bodyHada = new List<Bod>(4);
        public static Color farbaHlavyNepriechodny = Colors.Blue ;
        public static Color farbaHlavyPriechodny = Colors.Blue;
        protected static Color farbaTela = Colors.White;

        public static int RozmerPola { get { return 30; } }

        public Smer smer  { get; set;}
       

        public List<Bod> BodyHada { get { return bodyHada; } set { bodyHada = value; } }

        public Had()
        {
            bodyHada.Add(new Bod(2, 5, farbaTela));  // chvost
            bodyHada.Add(new Bod(3, 5, farbaTela));
            bodyHada.Add(new Bod(4, 5, farbaTela));
            smer = Smer.Vpravo;
        }

        public abstract bool pohyb();
         

    //    private void pohybVseobecne(int paPosunX , int paPosunY)
     //   {
     //       bodyHada.Add(new Bod(getHlavu().X + paPosunX,
     //                           getHlavu().Y +  paPosunY));
     //       nastavFarby();
     //   }

        protected void pohybVseobecneFunkcny(SmerFunkcny smer)
        {
            
            bodyHada.Add(new Bod(getHlavu().X + smer.X,
                                getHlavu().Y + smer.Y));
            nastavFarby();
        }

     
        public Bod getHlavu()
        {
            return bodyHada.Last();
        }
  
        protected Bod getKrk()
        {
            return bodyHada.ElementAt(bodyHada.Count - 2);
        }

        public void vymazChvost()
        {
            bodyHada.RemoveAt(0);
        }

        public Bod getChvost()
        {
            return bodyHada.ElementAt(0);
        }
     
        public bool zjedolJedlo(Jedlo jedlo)
        {
            return (bodyHada.Last().X == jedlo.getBod.X) 
                && (bodyHada.Last().Y == jedlo.getBod.Y);
        }

        public bool zjedolPrvokHryRozsireny(PrvokHryRozsireny nasobic)
        {
            return (bodyHada.Last().X == nasobic.getBod.X)
                && (bodyHada.Last().Y == nasobic.getBod.Y)
                && nasobic.Aktivny;
        }

        private bool naburanieDoSebaVseobecne(int paPosunX, int paPosunY)
        {
            return bodyHada.Exists(had => had.X == (getHlavu().X + paPosunX)
                                    && had.Y == getHlavu().Y + paPosunY);                                                
        }

        public bool naburanieDoSeba()
        {
            if (naburanieDoSebaVseobecne(-1,0) && smer == Smer.Vlavo)
                return true;
            else if (naburanieDoSebaVseobecne(0, -1) && smer == Smer.Hore)
                return true;
            else if (naburanieDoSebaVseobecne(1, 0) && smer == Smer.Vpravo)
                return true;
            else if (naburanieDoSebaVseobecne(0, 1) && smer == Smer.Dole)
                return true;
            return false;
        }

        protected virtual void nastavFarby()
        {
            bodyHada.ElementAt(bodyHada.Count - 2).Color = farbaTela;
            zmenFarbuHlavy(farbaHlavyNepriechodny);
        }

        public void zmenFarbuHlavy(Color farbaHlavy)
        {
            bodyHada.Last().Color = farbaHlavy;
        }

        public bool moznyPohybVseobecne(int paPosunX, int paPosunY)
        {
            return (!(getHlavu().X + paPosunX == getKrk().X
               && getHlavu().Y + paPosunY == getKrk().Y));
        }

        public abstract bool moznyPohybHore();
       
        public abstract bool moznyPohybDole();
      
        public abstract bool moznyPohybVpravo();
       
        public abstract bool moznyPohybVlavo();
     
        public bool stretZoStenouHore()
        {
            return getHlavu().Y == 0 && smer == Smer.Hore;
        }

        public bool stretZoStenouDole()
        {
            return getHlavu().Y == (RozmerPola - 1) && smer == Smer.Dole;
        }

        public bool stretZoStenouVpravo()
        {
            return getHlavu().X == (RozmerPola - 1) && smer == Smer.Vpravo;
        }

        public bool stretZoStenouVlavo()
        {
            return getHlavu().X == 0 && smer == Smer.Vlavo;
        }
     
    }
}
