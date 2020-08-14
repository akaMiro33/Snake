using SnakeMiro.Databaza;
using SnakeMiro.Hra;
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
    /// Interaction logic for PrihlasenieRegistraciaWindow.xaml
    /// </summary>
    public partial class PrihlasenieRegistraciaWindow : Window
    {
        public PrihlasenieRegistraciaWindow()
        {
            InitializeComponent();
        }

        private void ButtonPrihlasenie_Click(object sender, RoutedEventArgs e)
        {
            using (var databaza = new DatabazaSnake())
            {
                var pou = databaza.Pouzivatelia.Where(x => x.Meno == textBoxMeno.Text).First();
                if (SecurePasswordHasher.Verify(textBoxHeslo.Password,pou.Heslo))
                // if (databaza.Pouzivatelia.Where(x => x.Meno == textBoxMeno.Text).Any()) //&&
                    //SecurePasswordHasher.Verify(textBoxHeslo.Password,))
                {
                    GlobalnePremenne.aktualnyPouzivatel = textBoxMeno.Text;
                    MessageBox.Show("Prihlasenie prebehlo uspesne");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Prihlasenie prebehlo neuspesne. Neplatne aktualnyPouzivatel alebo heslo");
                }
            }
        }

        private void ButtonRegistracia_Click(object sender, RoutedEventArgs e)
        {
            // List<PrihlasovacieUdaje> uzivatelia;
            using (var databaza = new DatabazaSnake())
            {
                string hashHeslo = SecurePasswordHasher.Hash(textBoxHeslo.Password);
                

                if (databaza.Pouzivatelia.Where(x => x.Meno == textBoxMeno.Text).Any())
                {
                    MessageBox.Show("Zadané uživatelské aktualnyPouzivatel už existuje");
                }
                else
                {
                    Pouzivatel novyUzivatel = new Pouzivatel(textBoxMeno.Text,
                                                             hashHeslo);
                    databaza.Pouzivatelia.Add(novyUzivatel);
                    databaza.SaveChanges();
                    GlobalnePremenne.aktualnyPouzivatel = textBoxMeno.Text;
                    MessageBox.Show("Registracia prebehla uspesne");
                    this.Close();
                    
                }


            }
        }

        private void ButtonAnonym_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pokracujete ako anonym");
            this.Close();
        }
    }
}
