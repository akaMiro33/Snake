using SnakeMiro.Databaza;
using SnakeMiro.Hra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SnakeMiro.LogikaPohladov
{
    public class PracaSDatabazou
    {
        DatabazaSnake databaza = new DatabazaSnake();

        public void zapisanieSkore(MenuItem pevneSteny)
        {
            using (databaza)
            {
                 var aktualnyPou = databaza.Pouzivatelia.Where(x => x.Meno == GlobalnePremenne.aktualnyPouzivatel).First();
                 if (pevneSteny.IsChecked)
                     databaza.Hry.Add(new Databaza.Hra(true, GlobalnePremenne.skore, aktualnyPou));
                 else
                     databaza.Hry.Add(new Databaza.Hra(false, GlobalnePremenne.skore, aktualnyPou));
                 databaza.SaveChanges();
            }
        }
    }
}
