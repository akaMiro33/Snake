using SnakeMiro.Databaza;
using SnakeMiro.Hra;
using SnakeMiro.LogikaPohladov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer player = new SoundPlayer();
        private LogikaHry hra;
        private List<List<Rectangle>> zoznamStvorcov = new List<List<Rectangle>>(Had.RozmerPola);
        DispatcherTimer timer = new DispatcherTimer();
        UvodnaObrazovka uvodO;
        bool AI = false;
        OvladanieHry ovladanieHry;

        public MainWindow()
        {
            InitializeComponent();
        //    player.SoundLocation = System.IO.Directory.GetCurrentDirectory() + "\\sound.wav";
            //player.Play();
           PrihlasenieRegistraciaWindow okno = new PrihlasenieRegistraciaWindow();
            okno.ShowDialog();
            okno.Close();
            uvodO = new UvodnaObrazovka();
            if (GlobalnePremenne.aktualnyPouzivatel == null)
                Close();
            HlavnyFrame.Content = uvodO;
            CreateMainGrid();
            hlavnyGrid.Visibility = Visibility.Hidden;
            AktualneSkoreLabel.Visibility = Visibility.Hidden;   
            timer.Tick += timer_Tick;

        }
       

        void timer_Tick(object sender, EventArgs e)
        {
            if (AI)
                hra.logikaHryNepriechodnyAutomat();
            else
                hra.typHry();
            SkoreLabel.Content = GlobalnePremenne.skore;
            NasobicProgressBar.Value = LogikaNasobic.DlzkaPosobenia;

            if (hra.jeKoniecHry)
           {
                timer.Stop();
                // databaza
                PracaSDatabazou pracaSDatabazou = new PracaSDatabazou();
                pracaSDatabazou.zapisanieSkore(pevneSteny);
                pevneSteny.IsEnabled = true;
                // databaza
                MessageBoxResult odpoved = MessageBox.Show("Chces hrat znova?", "Prehral si", MessageBoxButton.YesNo,MessageBoxImage.Question);
                    if (odpoved == MessageBoxResult.Yes)
                        novaHra();                    
                }
                else
                {
                    hra.nakresliPohybliveObjekty(zoznamStvorcov);
                }
            timer.Interval = TimeSpan.FromMilliseconds(GlobalnePremenne.rychlostHry);
        }

            public void novaHra()
            {
                hra = new LogikaHry(pevneSteny);
                timer.Interval = TimeSpan.FromMilliseconds(GlobalnePremenne.rychlostHry);
                pevneSteny.IsEnabled = false ;                
                timer.Start();
                hra.nakresliHraciePole(zoznamStvorcov);
            }

        public void CreateMainGrid()
            {
            VykresliHraciePole vykresliHraciePole = new VykresliHraciePole();
            vykresliHraciePole.vykresli(hlavnyGrid);
            vykresliHraciePole.nastavStvorce(zoznamStvorcov, hlavnyGrid);
            }
       
        private void Window_Loaded(object sender, RoutedEventArgs e) {}
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
                KeyDownMethod(e.Key);
        }

        private void KeyDownMethod(Key key)
        {         
                ovladanieHry.Ovladaj(key, hra.Had, timer);
        }

        private void Nova_Hra(object sender, RoutedEventArgs e)
        {
            AI = false;
            ovladanieHry = new OvladanieHry(false);
            nastaveniaPredZacatimHry();
        }

        private void Koniec(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NajSkorePevneSteny(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajSkorePevneSteny();
            statistiky.ShowDialog();
        }

        private void NajviacOdohranychHierPevneSteny(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajviacOdohranychHierPevneSteny();
            statistiky.ShowDialog();
        }

        private void NajhorsiePriemerneSkorePevneSteny(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajhorsiePriemerneSkorePevneSteny();
            statistiky.ShowDialog();
        }

        private void NajPriemerneSkorePevneSteny(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajlepsiePriemerneSkorePevneSteny();
            statistiky.ShowDialog();
        }

        private void NajSkorePriechodneSteny(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajSkorePriechodneSteny();
            statistiky.ShowDialog();
        }

        private void NajPriemerneSkorePriechodneSteny(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajlepsiePriemerneSkorePriechodneSteny();
            statistiky.ShowDialog();
        }

        private void NajhorsiePriemerneSkorePriechodneSteny(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajhorsiePriemerneSkorePriechodneSteny();
            statistiky.ShowDialog();
        }

        private void NajviacOdohranychHierPriechodneSteny(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajviacOdohranychHierPriechodneSteny();
            statistiky.ShowDialog();
        }

        private void NajviacOdohranychHier(object sender, RoutedEventArgs e)
        {
            StatistikyWindow statistiky = new StatistikyWindow();
            statistiky.vypisNajviacOdohranychHierCelkovo();
            statistiky.ShowDialog();
        }

        private void Automat(object sender, RoutedEventArgs e)
        {
            ovladanieHry = new OvladanieHry(true);
            AI = true;
            nastaveniaPredZacatimHry();          
        }

        private void nastaveniaPredZacatimHry()
        {
            AktualneSkoreLabel.Visibility = Visibility.Visible;
            uvodO.timer.Stop();
            HlavnyFrame.Visibility = Visibility.Hidden;
            timer.Stop();
            if (!hlavnyGrid.IsVisible)
                hlavnyGrid.Visibility = Visibility.Visible;
            novaHra();
        }

    }
}
