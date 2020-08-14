using SnakeMiro.Databaza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SnakeMiro
{
    /// <summary>
    /// Interaction logic for StatistikyWindow.xaml
    /// </summary>
    public partial class StatistikyWindow : Window
    {

        Label[,] zoznamLabelov = new Label[2, 10];
        public const int POSUN = 1;
        private int mnozstvoPoloziek = 10;
        DatabazaSnake databaza = new DatabazaSnake();
        public StatistikyWindow()
        {
            InitializeComponent();
            urobStrukturuLabelov();
            //vypisNajSkorePevneSteny();
        }

        private void urobStrukturuLabelov()
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Label label = new Label();
                    label.Foreground = Brushes.White;
                    //label.Content = j.ToString() + i.ToString();
                    Grid.SetColumn(label, j + POSUN);
                    Grid.SetRow(label, i + POSUN);
                    grid.Children.Add(label);
                    zoznamLabelov[j,i] = label;
                }
            }
        }

        public void vypisNajSkorePevneSteny()
        {
            LabelNazovStatistiky.Content = "Naj Skore Pevne Steny";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajlepsieSkoreNepriechodny();
                vypisStatistikyVseobecne(data);
            }        
        }

        public void vypisNajSkorePriechodneSteny()
        {
            LabelNazovStatistiky.Content = "Naj Skore Priechodne Steny";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajlepsieSkorePriechodny();
                vypisStatistikyVseobecne(data);
            }

        }

        public void vypisNajviacOdohranychHierCelkovo()
        {
            LabelNazovStatistiky.Content = "Najviac Odohranych Hier Celkovo";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajviacOdohranychHier();
                vypisStatistikyVseobecne(data);
            } 
        }

        public void vypisNajviacOdohranychHierPevneSteny()
        {
            LabelNazovStatistiky.Content = "Najviac Odohranych Hier Pevne Steny";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajviacOdohranychHierNepriechodny();
                vypisStatistikyVseobecne(data);
            }
        }

        public void vypisNajviacOdohranychHierPriechodneSteny()
        {
            LabelNazovStatistiky.Content = "Najviac Odohranych Hier Priechodne Steny";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajviacOdohranychHierPriechodny();
                vypisStatistikyVseobecne(data);
            }
        }

        public void vypisNajlepsiePriemerneSkorePevneSteny()
        {
            LabelNazovStatistiky.Content = "Najlepsie Priemerne Skore Pevne Steny";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajlepsiePriemerneSkoreNepriechodny();
                vypisStatistikyVseobecne(data);
            }
        }

        public void vypisNajlepsiePriemerneSkorePriechodneSteny()
        {
            LabelNazovStatistiky.Content = "Najlepsie Priemerne Skore Priechodne Steny";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajlepsiePriemerneSkorePriechodny();
                vypisStatistikyVseobecne(data);
            }
        }

        public void vypisNajhorsiePriemerneSkorePevneSteny()
        {
            LabelNazovStatistiky.Content = "Najhorsie Priemerne Skore Pevne Steny";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajhorsiePriemerneSkoreNepriechodny();
                vypisStatistikyVseobecne(data);
            }
        }

        public void vypisNajhorsiePriemerneSkorePriechodneSteny()
        {
            LabelNazovStatistiky.Content = "Najhorsie Priemerne Skore Priechodne Steny";
            using (databaza)
            {
                IEnumerable<SablonaNaDatabazu> data = databaza.dajNajhorsiePriemerneSkorePriechodny();
                vypisStatistikyVseobecne(data);
            }
        }

        private void vypisStatistikyVseobecne(IEnumerable<SablonaNaDatabazu> data)
        {
        mnozstvoPoloziek = 10;
            if (data.Count() < 10)
            mnozstvoPoloziek = data.Count();
            for (int i = 0; i < mnozstvoPoloziek; i++)
            {
                zoznamLabelov[0, i].Content = data.ElementAt(i).Slovo;
                zoznamLabelov[1, i].Content = data.ElementAt(i).Cislo;
            }
        }
    }

    
}
