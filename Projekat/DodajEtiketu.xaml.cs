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

            Etiketa et = new Etiketa();
            et.Oznaka = textBoxOznaka.Text;
            et.Boja = pokazivac.Fill;
            et.Opis = TextBoxOpis.Text;

            le.Add(et);

            Fr.Content = new TabelaE();

            textBoxOznaka.Text = "";
            pokazivac.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            TextBoxOpis.Text = "";
          

        }

        private void Boje_Click(object sender, RoutedEventArgs e)
        {

            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            pokazivac.Fill = new SolidColorBrush(Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B));
            
        }
    }
}
