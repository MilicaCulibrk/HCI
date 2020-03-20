using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Pocetna();

          
        }

       private void Spomenik_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SpomenikForm();
        }

      private void Etiketa_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EtiketaForm();
        }

        private void Tip_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TipForm();
        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pocetna();
        }

        private void Mapa_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Mapa();
        }
    }
}
