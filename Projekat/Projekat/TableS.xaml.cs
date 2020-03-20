using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
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
        public static List<string> stariId = new List<string>();
        public static List<int> index = new List<int>();
        public static ObservableCollection<Tip> Tipovi2 { get; set; }
        public static ObservableCollection<Etiketa> Etikete2 { get; set; }


        System.Windows.Forms.OpenFileDialog DG = new System.Windows.Forms.OpenFileDialog();


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

        private ObservableCollection<Spomenik> spomenici;
        public ObservableCollection<Spomenik> Spomenici
        {
            get
            {
                return spomenici;
            }
            set
            {
                if (value != spomenici)
                {
                    spomenici = value;
                    OnPropertyChanged("Sppmenici");
                }
            }
        }

        public TableS()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Spomenik> lista = DodajSpomenik.ls;

            Spomenici = new ObservableCollection<Spomenik>(lista);

            View = CollectionViewSource.GetDefaultView(Spomenici);

            Tipovi2 =  new ObservableCollection<Tip>(DodajTip.l);

            Etikete2 = new ObservableCollection<Etiketa>(DodajEtiketu.le);


           // Spomenici4 = new ObservableCollection<Spomenik>(DodajSpomenik.ls);

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

        private int _opcijaPretrage2;
        public int OpcijaPretrage2
        {
            get
            {
                return _opcijaPretrage2;
            }
            set
            {
                if (value != _opcijaPretrage2)
                {
                    _opcijaPretrage2 = value;
                    //OnPropertyChanged("OpcijaPretrage");
                    //Console.WriteLine("Opcija pretrage: " + OpcijaPretrage);
                }
            }
        }

        private int _opcijaPretrage3;
        public int OpcijaPretrage3
        {
            get
            {
                return _opcijaPretrage3;
            }
            set
            {
                if (value != _opcijaPretrage3)
                {
                    _opcijaPretrage3 = value;
                    //OnPropertyChanged("OpcijaPretrage");
                    //Console.WriteLine("Opcija pretrage: " + OpcijaPretrage);
                }
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

            Spomenik s = TejblS.SelectedItem as Spomenik;
            stariId.Add(s.Id);

            for(int i = 0; i < DodajSpomenik.ls.Count; i++)
            {
                foreach (string ss in stariId)
                {
                    if (ss.Equals(DodajSpomenik.ls[i].Id))
                    {
                        index.Add(i);
                    }
                }
            }
            

            FrejmIzmeni.Content = new IzmenaSpomenika(s);
           
        }

        private void Izmena_Click(object sender, RoutedEventArgs e)
        {

            FrejmIzmeni.Content = new TableS();
        }
    

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {


            FrejmIzmeni.Content = new DodajSpomenik();
        }


        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {

            Spomenik sp = TejblS.SelectedItem as Spomenik;

            Spomenici.Remove(sp);
            DodajSpomenik.ls.Remove(sp);

            Ikonica icon = null;
            foreach (Ikonica ic in MapaIkonice.mapaIk)
            {
                if (ic.Sp.Equals(sp))
                {
                   icon = ic;
                }
            }

            if (icon != null)
            {
                MapaIkonice.mapaIk.Remove(icon);
            }
        
        }

        private void TejblS_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Spomenik> filter = new ObservableCollection<Spomenik>();
            if (poljePretrage.Text.Equals(""))
            {
                Spomenici.Clear();
                foreach (Spomenik sp in DodajSpomenik.ls)
                {
                    Spomenici.Add(sp);
                }
                return;
            }

            foreach (Spomenik sp in DodajSpomenik.ls)
            {
             

                if (OpcijaPretrage == 0)
                {

                    int flag19 = 0;
                    foreach (Etiketa et in sp.Etikete)
                    {
                        if (et.Oznaka.ToLower().Contains(poljePretrage.Text.ToLower()))
                        {
                            flag19 = 1;
                            continue;
                        }
                    }

                    String all = sp.Id.ToLower() + sp.Naziv.ToLower() + sp.Tip.Ime.ToLower() + sp.Opis.ToLower() + sp.GPrihod.ToString() + sp.EraPorekla.ToLower() + sp.TuristickiStatus.ToLower();
                    if (all.Contains(poljePretrage.Text.ToLower()) || flag19 == 1)
                    {
                        filter.Add(sp);
                        continue;
                    }
                }

                if (OpcijaPretrage == 1)
                {
                    if (sp.Id.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(sp);
                        continue;
                    }

                }

                if (OpcijaPretrage == 2)
                {
                    if (sp.Naziv.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(sp);
                        continue;
                    }

                }


                if (OpcijaPretrage == 3)
                {
                    if (sp.Tip.Ime.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(sp);
                        continue;
                    }

                }


                if (OpcijaPretrage == 4)
                {
                    int flag17 = 0;
                    foreach (Etiketa et in sp.Etikete)
                    {
                        if (et.Oznaka.ToLower().Contains(poljePretrage.Text.ToLower()))
                        {
                            flag17 = 1;
                            continue;
                        }
                    }

                    if (flag17 == 1)
                    {
                        filter.Add(sp);
                    }
                  


                }


                if (OpcijaPretrage == 5)
                {
                    if (sp.GPrihod.ToString().ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(sp);
                        continue;
                    }

                }

            }

           Spomenici.Clear();

           foreach (Spomenik f in filter)
            {
                Spomenici.Add(f);
            }
           
        }


        private void Pretrazi_Click(object sender, RoutedEventArgs e)
        {
           /* List<Spomenik> spomL = new List<Spomenik>();
            foreach (Spomenik spom in this.Spomenici)
            {
                if (spom.Ikonica.Equals(ikonica))
                {
                    spomL.Add(spom);
                }
            }*/
            Spomenici.Clear();
         
            if (oznaka.Text.Equals("") && naziv.Text.Equals("") && etiketeList.SelectedItem == null && izaberiTip.SelectedValue == null && OpcijaPretrage2 == 0 && OpcijaPretrage3 == 0 && arh_obradjenSVEJEDNO.IsChecked == true && unescoSVEJEDNO.IsChecked == true && regionSVEJEDNO.IsChecked == true && prihod.Text.Equals(""))
            {
                foreach (Spomenik sp in DodajSpomenik.ls)
                {
                    Spomenici.Add(sp);
                }
                return;
            }

            //trazimo etikete
            foreach (Spomenik sp in DodajSpomenik.ls)
            {
                int flag = 0;
                string era = "";
                string ts = "";
                foreach (Etiketa et in sp.Etikete)
                {
                    foreach (var item in etiketeList.SelectedItems)
                    {
                        if (et.Equals((Etiketa)item) && sp.Etikete.Count() == etiketeList.SelectedItems.Count)
                        {
                            flag = 1;
                        }
                    }
                }

                //era porekla
                int flag2 = 0;
                if (OpcijaPretrage2 == 0)
                {
                    era = "";
                }
                if (OpcijaPretrage2 == 1)
                {
                    era = "Paleolit";
                }
                if (OpcijaPretrage2 == 2)
                {
                    era = "Neolit";
                }
                if (OpcijaPretrage2 == 3)
                {
                    era = "Stari vek";
                }
                if (OpcijaPretrage2 == 4)
                {
                    era = "Srednji vek";
                }
                if (OpcijaPretrage2 == 5)
                {
                    era = "Renesansa";
                }
                if (OpcijaPretrage2 == 6)
                {
                    era = "Moderno doba";
                }

                if (sp.EraPorekla.Equals(era))
                {
                    flag2 = 1;
                }

                //turisticki status
                int flag3 = 0;
                if (OpcijaPretrage3 == 0)
                {
                    ts = "";
                }

                if (OpcijaPretrage3 == 1)
                {
                    ts = "Eksploatisan";
                }
                if (OpcijaPretrage3 == 2)
                {
                    ts = "Dostupan";
                }
                if (OpcijaPretrage3 == 3)
                {
                    ts = "Nedostupan";
                }
               

                if (sp.TuristickiStatus.Equals(ts))
                {
                    flag3 = 1;
                }

                //arheoloski obradjen
                int flag4 = 0;
                if((arh_obradjenDA.IsChecked == true && sp.Arheoloski_obradjen == true) || (arh_obradjenNE.IsChecked == true && sp.Arheoloski_obradjen == false))
                {
                    flag4 = 1;
                }

                //unesco
                int flag5 = 0;
                if ((unescoDA.IsChecked == true && sp.Na_listi_UNESCO == true) || (unescoNE.IsChecked == true && sp.Na_listi_UNESCO == false))
                {
                    flag5 = 1;
                }

                //region
                int flag6 = 0;
                if ((regionDA.IsChecked == true && sp.U_naseljenom_regionu == true) || (regionNE.IsChecked == true && sp.U_naseljenom_regionu == false))
                {
                    flag6 = 1;
                }            


                if ( (oznaka.Text.Equals(sp.Id) || oznaka.Text.Equals("")) && (naziv.Text.Equals(sp.Naziv) || naziv.Text.Equals("")) && (flag == 1 || etiketeList.SelectedItem == null) && (sp.Tip.Equals((Tip)izaberiTip.SelectedValue) || izaberiTip.SelectedValue == null)  && ((flag2 == 1) || OpcijaPretrage2 == 0) && ((flag3 == 1) || OpcijaPretrage3 == 0) && (flag4 == 1 || arh_obradjenSVEJEDNO.IsChecked == true) && (flag5 == 1 || unescoSVEJEDNO.IsChecked == true) && (flag6 == 1 || regionSVEJEDNO.IsChecked == true) && (prihod.Text.Equals(sp.GPrihod.ToString()) || prihod.Text.Equals("")) )
                {
                   
                    Spomenici.Add(sp);
                }
            }
        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            Spomenici.Clear();
            oznaka.Text = "";
            naziv.Text = "";
            etiketeList.SelectedItems.Clear();
            izaberiTip.SelectedItem = null;
            era_porekla.SelectedItem = null;
            turisticki.SelectedItem = null;
            OpcijaPretrage2 = 0;
            OpcijaPretrage3 = 0;
            arh_obradjenSVEJEDNO.IsChecked = true;
            unescoSVEJEDNO.IsChecked = true;
            regionSVEJEDNO.IsChecked = true;
            prihod.Text = "";

            foreach (Spomenik sp in DodajSpomenik.ls)
            {
                Spomenici.Add(sp);
            }
        }


            private void Turisticki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void clearFilter_Click(object sender, RoutedEventArgs e)
        {
            poljePretrage.Text = "";
            TextBox_KeyUp(null, null);
        }


    }
}
