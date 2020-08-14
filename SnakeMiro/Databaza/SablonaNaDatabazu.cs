using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMiro.Databaza
{
    public class SablonaNaDatabazu 
    {
        public string Slovo { get; set; }
        public double Cislo { get; set; }

        public SablonaNaDatabazu(string paSlovo, double paCislo)
        {
            Slovo = paSlovo;
            Cislo = paCislo;
        }
    }
}
