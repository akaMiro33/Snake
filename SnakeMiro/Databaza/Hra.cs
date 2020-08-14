using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMiro.Databaza
{
    public class Hra
    {
        [Key]
        public int Id { get; set; }
        public bool TypHry { get; set; }
        public int Skore { get; set; }
        [Required]
        public virtual Pouzivatel Pouzivatel { get; set; }

        public Hra(bool paTypHry, int paSkore)
        {
            TypHry = paTypHry;
            Skore = paSkore;

        }

        public Hra()
        {
        
        }

        public Hra(bool paTypHry, int paSkore, Pouzivatel paPouzivatel)
        {
            TypHry = paTypHry;
            Skore = paSkore;
            Pouzivatel = paPouzivatel;
        }

    }
}
