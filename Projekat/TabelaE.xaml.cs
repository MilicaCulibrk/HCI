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
    /// Interaction logic for TabelaE.xaml
    /// </summary>
    public partial class TabelaE : Page, INotifyPropertyChanged
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


        public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }



        public TabelaE()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Etiketa> lis = DodajEtiketu.le;

            Etikete = new ObservableCollection<Etiketa>(lis);

            View = CollectionViewSource.GetDefaultView(Etikete);

        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

            Etiketa et = Table.SelectedItem as Etiketa;

            FrejmIzmeni.Content = new IzmenaEtikete(et);

        }
    }
}
