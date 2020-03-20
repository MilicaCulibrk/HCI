using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Projekat;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Tabela.xaml
    /// </summary>
    public partial class Tabela : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private ICollectionView _View;
        public ICollectionView View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
                OnPropertyChanged("View");
            }
        }

        public static ObservableCollection<Tip> Tipovi
        {
            get;
            set;
        }

        public Tabela()
        {
            InitializeComponent();
            this.DataContext = this;

            List < Tip > lista = DodajTip.l;

            Tipovi = new ObservableCollection<Tip>(lista);

            View = CollectionViewSource.GetDefaultView(Tipovi);
  
        }
        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

         Tip t = Tejbl.SelectedItem as Tip;

          FrejmIzmeni.Content = new IzmenaTipa(t);
           
        }

        
    }
}
