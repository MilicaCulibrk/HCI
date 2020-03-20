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
        public IzmenaEtikete(Etiketa et)
        {
            InitializeComponent();
            this.DataContext = et;
        }

        private void Izm_Click(object sender, RoutedEventArgs e)
        {

            Frejm.Content = new TabelaE();

            textBoxOznaka.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
            pokazivac.GetBindingExpression(Shape.FillProperty).UpdateSource();
            TextBoxOpis.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();

        }

        private void Boje_Click(object sender, RoutedEventArgs e)
        {

            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            pokazivac.Fill = new SolidColorBrush(Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B));

        }


    }
}
