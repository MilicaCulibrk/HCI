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


///////////////////////////////////////////////////DUGMAD///////////////////////////////////////////////////////
        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

         Tip t = Tejbl.SelectedItem as Tip;

          FrejmIzmeni.Content = new IzmenaTipa(t);
           
        }

        private void Izmena_Click(object sender, RoutedEventArgs e)
        {

            FrejmIzmeni.Content = new Tabela();

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            FrejmIzmeni.Content = new DodajTip();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {

            Tip t = Tejbl.SelectedItem as Tip;

            FrejmIzmeni.Content = new Brisanje(t);
        }



 //////////////////////////////////////////////////PRECICE//////////////////////////////////////////////////////
        private void DodavanjeTipa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            
        }

        private void DodavanjeTipa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FrejmIzmeni.Content = new DodajTip();
        }

        private void IzmeniTip_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void IzmeniTip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
              Tip t = Tejbl.SelectedItem as Tip;

              FrejmIzmeni.Content = new IzmenaTipa(t);
        }

        private void ObrisiTip_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ObrisiTip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Tip t = Tejbl.SelectedItem as Tip;

            FrejmIzmeni.Content = new Brisanje(t);
        }


        /////////////////////////////////////////////////////FILTER/////////////////////////////////////////////////////
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Tip> filter = new ObservableCollection<Tip>();
            if (poljePretrage.Text.Equals(""))
            {
                Tipovi.Clear();
                foreach (Tip t in DodajTip.l)
                {
                    Tipovi.Add(t);
                }
                return;
            }

            foreach (Tip t in DodajTip.l)
            {


                if (OpcijaPretrage == 0)
                {


                    String all = t.Oznaka.ToLower() + t.Ime.ToLower();
                    if (all.Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(t);
                        continue;
                    }
                }

                if (OpcijaPretrage == 1)
                {
                    if (t.Oznaka.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(t);
                        continue;
                    }

                }

                if (OpcijaPretrage == 2)
                {
                    if (t.Ime.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(t);
                        continue;
                    }

                }

            }

            Tipovi.Clear();

            foreach (Tip t in filter)
            {
                Tipovi.Add(t);
            }

        }



////////////////////////////////////////////////PRETRAGA/////////////////////////////////////////////////////////
            private void Pretrazi_Click(object sender, RoutedEventArgs e)
            {
                 Tipovi.Clear();

                if (oznaka.Text.Equals("") && naziv.Text.Equals(""))
                {
                    foreach (Tip t in DodajTip.l)
                    {
                        Tipovi.Add(t);
                    }
                    return;
                }

            foreach (Tip t in DodajTip.l)
            {
                if ((oznaka.Text.Equals(t.Oznaka) || oznaka.Text.Equals("")) && (naziv.Text.Equals(t.Ime) || naziv.Text.Equals("")))
                {

                    Tipovi.Add(t);
                }
            }

            
        }

            private void Ponisti_Click(object sender, RoutedEventArgs e)
            {
                 Tipovi.Clear();
                 oznaka.Text = "";
                 naziv.Text = "";


                foreach (Tip t in DodajTip.l)
                {
                    Tipovi.Add(t);
                }
            }

        private void clearFilter_Click(object sender, RoutedEventArgs e)
        {
            poljePretrage.Text = "";
            TextBox_KeyUp(null, null);
        }
    }
    }
