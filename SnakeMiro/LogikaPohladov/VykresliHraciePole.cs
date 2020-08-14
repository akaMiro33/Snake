using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeMiro.LogikaPohladov
{
    public class VykresliHraciePole
    {
        public void vykresli(Grid hlavnyGrid)
        {
            for (int i = 0; i < Had.RozmerPola; i++)
            {
                hlavnyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            ColumnDefinition columnDefinition = new ColumnDefinition();
            for (int i = 0; i < Had.RozmerPola; i++)
            {
                hlavnyGrid.RowDefinitions.Add(new RowDefinition());
            }          
        }
    

        public void nastavStvorce(List<List<Rectangle>> zoznamStvorcov, Grid hlavnyGrid)
        {
            for (int j = 0; j < Had.RozmerPola; j++)
            {
            zoznamStvorcov.Add(new List<Rectangle>());
            for (int i = 0; i < Had.RozmerPola; i++)
            {
                Rectangle obdlznik = new Rectangle();
                obdlznik.Stretch = Stretch.Fill;
                Thickness ts = new Thickness(2);
                obdlznik.Margin = ts;
                Grid.SetColumn(obdlznik, j);
                Grid.SetRow(obdlznik, i);
                hlavnyGrid.Children.Add(obdlznik);
                zoznamStvorcov[j].Add(obdlznik);
                }
            }
        }
    }
}
