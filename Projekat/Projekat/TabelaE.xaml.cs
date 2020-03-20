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
using System.Windows.Forms;
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
        private SolidColorBrush Boja;

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

        private int _opcijaPretrage;
        public int OpcijaPretrage
        {
            get
            {
                return _opcijaPretrage;
            }
            set
            {
                if (value != _opcijaPretrage)
                {
                    _opcijaPretrage = value;
                    //OnPropertyChanged("OpcijaPretrage");
                    //Console.WriteLine("Opcija pretrage: " + OpcijaPretrage);
                }
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

            Etiketa et = Table.SelectedItem as Etiketa;

            FrejmIzmeni.Content = new IzmenaEtikete(et);

        }


        private void Izmena_Click(object sender, RoutedEventArgs e)
        {
            FrejmIzmeni.Content = new TabelaE();

        }


        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            FrejmIzmeni.Content = new DodajEtiketu();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            Etiketa et = Table.SelectedItem as Etiketa;

            foreach (Spomenik sp in DodajSpomenik.ls)
            {
                foreach (string id in sp.EtId)
                    if (id.Equals(et.Oznaka))
                    {
                        sp.Etikete.Remove(et);

                    }

            }

            Etikete.Remove(et);
            DodajEtiketu.le.Remove(et);
        }

        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ObservableCollection<Etiketa> filter = new ObservableCollection<Etiketa>();
            if (poljePretrage.Text.Equals(""))
            {
                Etikete.Clear();
                foreach (Etiketa et in DodajEtiketu.le)
                {
                    Etikete.Add(et);
                }
                return;
            }
            else
            {

                foreach (Etiketa et in DodajEtiketu.le)
                {

                    String all = et.Oznaka.ToLower();
                    if (all.Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(et);
                        continue;
                    }
                }
            }

            Etikete.Clear();

            foreach(Etiketa et in filter)
            {
                Etikete.Add(et);
            }
        }

        private void Pretrazi_Click(object sender, RoutedEventArgs e)
        {
            Etikete.Clear();

            if (oznaka.Text.Equals("") && colorRechtangle.Fill == null)
            {
                foreach(Etiketa et in DodajEtiketu.le)
                {
                    Etikete.Add(et);
                }
                return;
            }

            

            foreach (Etiketa et in DodajEtiketu.le)
            {
                int flag = 0;
                if (colorRechtangle.Fill != null)
                    if (Boja.Color != et.Boja.Color)
                        flag = 1;

                if ((oznaka.Text.Equals(et.Oznaka) || oznaka.Text.Equals("")) && (flag == 0 || colorRechtangle.Fill == null))
                {

                    Etikete.Add(et);
                }
            }
        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {

            Etikete.Clear();
            oznaka.Text = "";

            foreach (Etiketa et in DodajEtiketu.le)
            {
                Etikete.Add(et);
            }

        }

        private void IzaberiBoju(object sender, RoutedEventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var wpfcolor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                Boja = new SolidColorBrush(wpfcolor);
                colorRechtangle.Fill = Boja;
            }
        }

        private void clearFilter_Click(object sender, RoutedEventArgs e)
        {
            poljePretrage.Text = "";
            TextBox_KeyUp(null, null);
        }

        private void FrejmIzmeni_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
  }
