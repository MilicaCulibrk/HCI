﻿using System;
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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for TableS.xaml
    /// </summary>
    public partial class TableS : Page, INotifyPropertyChanged
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

        public static ObservableCollection<Spomenik> Spomenici
        {
            get;
            set;
        }

        public TableS()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Spomenik> lista = DodajSpomenik.ls;

            Spomenici = new ObservableCollection<Spomenik>(lista);

            View = CollectionViewSource.GetDefaultView(Spomenici);

        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

            Spomenik s = TejblS.SelectedItem as Spomenik;

            FrejmIzmeni.Content = new IzmenaSpomenika(s);

        }

    }
}
