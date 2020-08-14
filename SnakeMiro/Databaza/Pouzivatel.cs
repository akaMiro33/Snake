using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMiro.Databaza
{
    public class Pouzivatel
    {
        [Key]
        public int Id { get; set; }
        public string Meno { get; set; }
        public string Heslo { get; set; }

        public ICollection<Hra> Hry { get; set; }

        public Pouzivatel()
        {            
        }

        public Pouzivatel(string paMeno, string paHeslo)
        {
            Meno = paMeno;
            Heslo = paHeslo;
        }

    }
}
