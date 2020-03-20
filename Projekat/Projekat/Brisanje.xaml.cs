using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Brisanje.xaml
    /// </summary>
    public partial class Brisanje : Page
    {
        Tip tip;
        List<Spomenik> pomocniSp;
     

        public Brisanje(Tip t)
        {
            tip = t;
            pomocniSp = DodajSpomenik.ls;
            InitializeComponent();
        }

        private void Nastavi_Click(object sender, RoutedEventArgs e)
        {
            List<Spomenik> spom = new List<Spomenik>();

            foreach (Spomenik sp in DodajSpomenik.ls)
            {
               
                if (this.tip.Equals(sp.Tip))
                {
                    spom.Add(sp);
                   
                }

                Ikonica icon = null;
                foreach (Ikonica ic in MapaIkonice.mapaIk)
                {
                    if (ic.Sp.Equals(sp))
                    {
                        if (ic.Sp.Tip.Equals(tip))
                        {
                            icon = ic;
                        }
                        
                    }
                }

                if (icon != null)
                {
                    MapaIkonice.mapaIk.Remove(icon);
                }
            }

            foreach (Spomenik sp in spom)
            {
          
                DodajSpomenik.ls.Remove(sp);
            }
        

            Tabela.Tipovi.Remove(tip);
            DodajTip.l.Remove(tip);

            MessageBox.Show("Uspesno ste izbrisali tip i njegove spomenike!");

            FrejmBrisanje.Content = new Tabela();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            FrejmBrisanje.Content = new Tabela();
        }
    }
}
