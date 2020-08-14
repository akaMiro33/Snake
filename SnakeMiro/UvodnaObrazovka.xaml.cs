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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeMiro
{
    /// <summary>
    /// Interaction logic for Hra.xaml
    /// </summary>
    public partial class UvodnaObrazovka : Page
    {
       
        public DispatcherTimer timer = new DispatcherTimer();
        double num = 15000;

        public UvodnaObrazovka()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += posunUvodnejObrazovky;
            timer.Start();
        }

        void posunUvodnejObrazovky(object sender, EventArgs e)
        {

            try
            {
                Scroll_Content.ScrollToHorizontalOffset(num);
                num--;
            }
            catch { }
        }




    }
}
