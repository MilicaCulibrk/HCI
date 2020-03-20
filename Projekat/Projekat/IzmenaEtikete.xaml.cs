using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Projekat
{
    /// <summary>
    /// Interaction logic for IzmenaEtikete.xaml
    /// </summary>
    public partial class IzmenaEtikete : Page
    {
        private Etiketa etk = new Etiketa();

        public IzmenaEtikete(Etiketa et)
        {
            etk = et;
            InitializeComponent();
            this.DataContext = et;
        }

        private void Izm_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                int flag = 0;

                foreach (Etiketa etiketa in TabelaE.Etikete)
                {
                    if (!etiketa.Equals(etk))
                    {
                        if (textBoxOznaka.Text.Equals(etiketa.Oznaka))
                        {
                            textBoxOznaka.BorderBrush = System.Windows.Media.Brushes.Red;
                            System.Windows.MessageBox.Show("Već postoji etiketa sa istom ozankom. Unesite drugačiju oznaku etikete!");
                            flag = 1;
                            break;

                        }
                    }
                }

                pokazivac.GetBindingExpression(Shape.FillProperty).UpdateSource();
                TextBoxOpis.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();

                if (flag == 0)
                {
                    textBoxOznaka.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                    Frejm.Content = new TabelaE();
                }
                else
                {
                    Frejm.Content = new IzmenaEtikete(etk);
                }
            
            }else{

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


            return validation;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
           
                Frejm.Content = new TabelaE();
            
        }


    }
}
