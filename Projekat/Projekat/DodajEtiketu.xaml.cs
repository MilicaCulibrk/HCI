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
using System.Collections.ObjectModel;
using System.ComponentModel;
using Projekat;
using System.Windows.Forms;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for DodajEtiketu.xaml
    /// </summary>
    public partial class DodajEtiketu : Page
    {

        public static List<Etiketa> le = new List<Etiketa>();

        public DodajEtiketu()
        {
            InitializeComponent();
        }


        private void DodajEtiketu_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {

                Etiketa et = new Etiketa();
                et.Oznaka = textBoxOznaka.Text;
                et.Boja = (System.Windows.Media.SolidColorBrush)pokazivac.Fill;
                et.Opis = TextBoxOpis.Text;

                int flag = 0;
                foreach (Etiketa etiketa in TabelaE.Etikete)
                {
                    if (etiketa.Oznaka.Equals(et.Oznaka))
                    {
                        textBoxOznaka.BorderBrush = System.Windows.Media.Brushes.Red;
                        System.Windows.MessageBox.Show("Već postoji etiketa sa istom ozankom. Unesite drugačiju oznaku etikete!");
                        flag = 1;
                        break;
                    }
                }

               
                if (flag == 0)
                {
                   
                    le.Add(et);

                    Fr.Content = new TabelaE();

                    textBoxOznaka.Text = "";
                    pokazivac.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                    TextBoxOpis.Text = "";
                }

              
            }
            else
            {
                System.Windows.MessageBox.Show("Molimo Vas da popunite prazna polja!");

            }

        }

        private void Boje_Click(object sender, RoutedEventArgs e)
        {

            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            pokazivac.Fill = new SolidColorBrush(Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B));
            
        }

        private bool validate()
        {
            bool validation = true;

            if (textBoxOznaka.Text == "")
            {
                //LabelaID.Content = "*Morate uneti odgovarajuci tekst!";
                textBoxOznaka.BorderBrush = Brushes.Red;

                validation = false;
            }
            else
            {
                //LabelaID.Content = "";
                textBoxOznaka.BorderBrush = Brushes.Black;
            }

            if (TextBoxOpis.Text == "")
            {
                //LabelaIME.Content = "*Morate uneti odgovarajuci text!";
                TextBoxOpis.BorderBrush = Brushes.Red;

                validation = false;
            }
            else
            {
                //LabelaIME.Content = "";
                TextBoxOpis.BorderBrush = Brushes.Black;
            }
            if (pokazivac.Fill == null)
            {
                //LabelaIME.Content = "*Morate uneti odgovarajuci text!";
                pokazivac.Stroke = Brushes.Red;

                validation = false;
            }
            else
            {
                //LabelaIME.Content = "";
                pokazivac.Stroke = Brushes.Black;
            }


            return validation;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Fr.Content = new TabelaE();
        }


    }
}
