using SnakeMiro.Hra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeMiro
{
    public class Jedlo : PrvokHry
    {
        private static Color farbaJedla = Colors.Red;
        public Jedlo() : base()
        {
            bod.Color = farbaJedla;            
        }

       public override void vygenerujSuradnice(Had had , List<Bod> plocha, Bod bodInehoPrvku, Bod bodInehoPrvkuTwo)
       {
            base.vygenerujSuradnice(had, plocha, bodInehoPrvku, bodInehoPrvkuTwo);
            bod.Color = farbaJedla;
       }       
    }
}
