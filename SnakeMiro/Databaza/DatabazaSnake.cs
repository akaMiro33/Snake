namespace SnakeMiro.Databaza
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class DatabazaSnake : DbContext
    {
        public DatabazaSnake()
            : base("name=DatabazaSnake")
        {
        }

        public DbSet<Pouzivatel> Pouzivatelia { get; set; }
        public DbSet<Hra> Hry { get; set; }

        private  IEnumerable<SablonaNaDatabazu> dajNajlepsieSkoreVseobecne(bool paTypHry)
        {          
            return Hry.Where(hra=> hra.TypHry == paTypHry)
                .OrderByDescending(x => x.Skore).Take(10)
            .ToList().Select(hra => new SablonaNaDatabazu(hra.Pouzivatel.Meno, hra.Skore ))
            .ToList(); 
        }

        public IEnumerable<SablonaNaDatabazu> dajNajlepsieSkorePriechodny()
        {
            return dajNajlepsieSkoreVseobecne(false);
        }

        public IEnumerable<SablonaNaDatabazu> dajNajlepsieSkoreNepriechodny()
        {
            return dajNajlepsieSkoreVseobecne(true);
        }

        public IEnumerable<SablonaNaDatabazu> dajNajviacOdohranychHier()
        {            
            return  Hry.GroupBy(hra => hra.Pouzivatel)
                .ToList()
                .Select(skupina => new SablonaNaDatabazu(skupina.Key.Meno, skupina.Count()))
                .OrderByDescending(x => x.Cislo).Take(10)
                .ToList();
        }

        private IEnumerable<SablonaNaDatabazu> dajNajviacOdohranychHierVseobecne(Boolean paTypHry)
        {
            return  Hry.Where(hra => hra.TypHry == paTypHry)
                .GroupBy(hra => hra.Pouzivatel)
                .ToList()
                .Select(skupina => new SablonaNaDatabazu( skupina.Key.Meno, skupina.Count() ))
                .OrderByDescending(x => x.Cislo).Take(10)
                .ToList(); 
        }

        public IEnumerable<SablonaNaDatabazu> dajNajviacOdohranychHierPriechodny()
        {
            return dajNajviacOdohranychHierVseobecne(false);
        }

        public IEnumerable<SablonaNaDatabazu> dajNajviacOdohranychHierNepriechodny()
        {           
            return dajNajviacOdohranychHierVseobecne(true);
        }

        private IEnumerable<SablonaNaDatabazu> dajNajlepsiePriemerneSkoreVseobecne(Boolean paTypHry)
        {

            return  Hry.Where(hra => hra.TypHry == paTypHry)
                .GroupBy(hra => hra.Pouzivatel)
                .ToList()
                .Select(skupina => new SablonaNaDatabazu
                                       (skupina.Key.Meno, skupina.Average(x => x.Skore) ))
                .OrderByDescending(x => x.Cislo).Take(10) 
                .ToList(); ;
        }

        public IEnumerable<SablonaNaDatabazu> dajNajlepsiePriemerneSkorePriechodny()
        {
            return dajNajlepsiePriemerneSkoreVseobecne(false);
        }

        public IEnumerable<SablonaNaDatabazu> dajNajlepsiePriemerneSkoreNepriechodny()
        {
            return dajNajlepsiePriemerneSkoreVseobecne(true);
        }

        private IEnumerable<SablonaNaDatabazu> dajNajhorsiePriemerneSkoreVseobecne(Boolean paTypHry)
        {
            return Hry.Where(hra => hra.TypHry == paTypHry)
                .GroupBy(hra => hra.Pouzivatel)
                .ToList()
                .Select(skupina => new SablonaNaDatabazu( skupina.Key.Meno, skupina.Average(x => x.Skore) ))
                .OrderBy(x => x.Cislo).Take(10) 
                .ToList(); ;
        }

        public IEnumerable<SablonaNaDatabazu> dajNajhorsiePriemerneSkorePriechodny()
        {
            return dajNajhorsiePriemerneSkoreVseobecne(false);
        }

        public IEnumerable<SablonaNaDatabazu> dajNajhorsiePriemerneSkoreNepriechodny()
        {
            return dajNajhorsiePriemerneSkoreVseobecne(true);
        }
    }
}