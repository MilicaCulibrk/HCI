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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for TipForm.xaml
    /// </summary>
    public partial class TipForm : Page
    {
        public TipForm()
        {
            InitializeComponent();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            TipFormFrame.Content = new DodajTip();
        }


        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Tip t = Tejbl.SelectedItem as Tip;


            TipFormFrame.Content = new IzmenaTipa(t);
        }
    }
}
