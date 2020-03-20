using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Mapa.xaml
    /// </summary>
    public partial class Mapa : Page, INotifyPropertyChanged
    {
        private List<Tip> tipoviTree;
        private ObservableCollection<Spomenik> spomeniciTree = new ObservableCollection<Spomenik>();
        private ObservableCollection<Spomenik> spomeniciTree2 = new ObservableCollection<Spomenik>();
        private Tip tipp;
        public Point startPoint;
        public Point pomocna;
        private bool promena = false;
        private Spomenik brisiSp = new Spomenik();
        private int flag = 0;
        Image pomocnaIkonica = new Image();
        private Spomenik spomennikk;
        private Tip tiipp = new Tip();
        public static int brojac = 0;

     


        public static Mapa InstanceM { get; private set; }
        private static MapaIkonice mi;

        private static Mapa instance = null;


        public Mapa()
        {

          

            InitializeComponent();

            tipoviTree = DodajTip.l;
      

          
            foreach (Ikonica ik in MapaIkonice.mapaIk)
            {
                Image Pikonica = Informacije(ik.Sp);
             

                canvasMapa.Children.Add(Pikonica);
            
                Canvas.SetLeft(Pikonica, ik.X);
                Canvas.SetTop(Pikonica, ik.Y);

            }

   
             Mi = new MapaIkonice();
           
            InstanceM = this;

            foreach (Tip t in DodajTip.l)
            {
                t.SpomeniciUtipu.Clear();
                Tip tipp = new Tip() { Ime = t.Ime };
                foreach (Spomenik sp in DodajSpomenik.ls)
                {
                    if (t.Equals(sp.Tip))
                    {

                        t.SpomeniciUtipu.Add(sp);
                        foreach (Ikonica mi in MapaIkonice.mapaIk)
                        {
                            if (sp.Equals(mi.Sp))
                            {
                                t.SpomeniciUtipu.Remove(sp);
                            }
                        }
                      

                    }
                }
            }

            this.DataContext = this;
            mapaImg.ImageSource = new BitmapImage(new Uri("pack://siteoforigin:,,,/Images/mapa.jpg"));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public List<Tip> TipoviTree
        {
            get
            {
                return tipoviTree;
            }
            set
            {
                if (value != tipoviTree)
                {
                    tipoviTree = value;
                    OnPropertyChanged("TipoviTree");
                }
            }
        }

        public ObservableCollection<Spomenik> SpomeniciTree
        {
            get
            {
                return spomeniciTree;
            }
            set
            {
                if (value != spomeniciTree)
                {
                    spomeniciTree = value;
                    OnPropertyChanged("SpomeniciTree");
                }
            }
        }

        public Tip Tipp
        {
            get
            {
                return tipp;
            }
            set
            {
                if (value != tipp)
                {
                    tipp = value;
                    OnPropertyChanged("Tipp");
                }
            }
        }



        public static Mapa MapaInstance
        {
            get;
            set;
        }
        internal static MapaIkonice Mi { get => mi; set => mi = value; }




        //drag n drop

        private void spomenici_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);  //na sta smo kliknnuli iz stabla, source
            promena = false;
        }


        private void spomenici_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);  //pozicija misa
            Vector diff = startPoint - mousePos;   //od kad smo kliknuli koliko smo pomerili

            if (e.LeftButton == MouseButtonState.Pressed &&                               //ako je pritisnut klik i 
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||     //ako ga pomeramo vertikalno ili horizontalno
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                TreeView treeview = sender as TreeView;         //source sender
                TreeViewItem treeViewItem = FindAncestor<TreeViewItem>((DependencyObject)e.OriginalSource);   //da nadjemo na kojeg smo iz stabla kliknuli

                if (treeview.SelectedItem is Spomenik)  //samo ako smo kliknuli na spomenik mozemo da ga prevucemo
                {

                    Spomenik s = (Spomenik)treeview.SelectedItem;  //da preuzmemo podatke iz kliknutog treeViewItema

                    if (treeViewItem != null && s != null)        //inicijalizacija drag n dropa
                    {
                        DataObject dragData = new DataObject("myFormat", s);
                        DragDrop.DoDragDrop(treeViewItem, dragData, DragDropEffects.Move);
                    }
                }


            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void canvasMapa_DragEnter(object sender, DragEventArgs e)
        {
              if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
              {
                  e.Effects = DragDropEffects.None;   
              } 
        }

        private void canvasMapa_Drop(object sender, DragEventArgs e)  //drop na mapu
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Spomenik sp = e.Data.GetData("myFormat") as Spomenik;  //uzimamo podatke

                foreach (Tip t in tipoviTree)    //skloni spomenik iz stabla
                {
                    foreach (Spomenik spom in t.SpomeniciUtipu)
                    {
                        if (spom.Equals(sp))
                        {
                            brisiSp = spom;
                            flag = 1;
                        }
                    }

                    if (flag == 1)
                    {
                        t.SpomeniciUtipu.Remove(brisiSp);

                    }

                }

                Image ikonica = Informacije(sp);



                if (!promena)                                   //ako prvi put stavljamo ikonicu na mapu
                {
                    this.canvasMapa.Children.Add(ikonica);      //dodajemo ikonicu u children canvasa

                    Point p = e.GetPosition(this.canvasMapa);   //gde smo spustili drop

                    Ikonica saCanvasa = new Ikonica(e.GetPosition(this.canvasMapa).X, e.GetPosition(this.canvasMapa).Y, sp, sp.Id);

                    if (CanDrop(e.GetPosition(this.canvasMapa).X, e.GetPosition(this.canvasMapa).Y, saCanvasa))
                    {
                        Canvas.SetLeft(ikonica, p.X);               //postavi na mapu
                        Canvas.SetTop(ikonica, p.Y);

                        Ikonica icon = new Ikonica(p.X, p.Y, sp, sp.Id);   //napravimo novi objekat Ikonica sa koordinatama 
                        Mapa.mi.MapaIk.Add(icon);                   //dodamo ga u observable collection ikonica sa mape
                    }
                    else
                    {

                        foreach (Tip t in tipoviTree)  //vrati ga u stablo
                        {

                            if (t.Equals(sp.Tip))
                            {
                                t.SpomeniciUtipu.Add(sp);
                            }
                        }

                        this.canvasMapa.Children.Remove(ikonica);
                        MessageBox.Show("Već postoji spomenik na izabranoj lokaciji!");
                    }

               
                }
                else                                            //ako premestamo ikonicu
                {
                    Point p = e.GetPosition(this.canvasMapa);        //gde smo pokupili ikonicu
                    for (int i = 0; i < Mapa.mi.MapaIk.Count; i++)   //prolazim kroz Ikonice u oc MapaIkonice(vec postavljene na mapu)
                    {
                        if (Mapa.mi.MapaIk[i].Sp.Id.Equals(sp.Id))   //ako nadjem u njoj spomenik koji dropujem
                        {

                            Ikonica saCanvasa = Mapa.mi.MapaIk[i];   //pravim novu ikonicu od te koju sam nasla

                            canvasMapa.Children.RemoveAt(i);
                            canvasMapa.Children.Insert(i, ikonica);


                            Spomenik pomS = razdaljina(p);
                            // if (pomS != null)
                            int flagg = 0;
                           if(!CanDrop(e.GetPosition(this.canvasMapa).X, e.GetPosition(this.canvasMapa).Y, saCanvasa))
                            {
                                p.X = saCanvasa.X;
                                p.Y = saCanvasa.Y;
                                flagg = 1;
                                
                            }

                                Canvas.SetLeft(ikonica, p.X);
                                Canvas.SetTop(ikonica, p.Y);

                                Mapa.mi.MapaIk[i].X = p.X;
                                Mapa.mi.MapaIk[i].Y = p.Y;
                             

                            if (flagg == 1)
                            {
                                MessageBox.Show("Već postoji spomenik na izabranoj lokaciji!");
                            }

                            break;
                        }
                    }
                }
            }

        }

        private void canvasMapa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(this.canvasMapa);
            promena = true;

            int i = 0;

            Spomenik pomS = razdaljina(startPoint);

            if (pomS != null)
            {
                for (i = 0; i < Mapa.mi.MapaIk.Count; i++)
                {
                    Image img = (Image)canvasMapa.Children[i];
                    //img.Opacity = 0.7;
                    canvasMapa.Children.RemoveAt(i);
                    canvasMapa.Children.Insert(i, img);
                    if (pomS.Equals(Mapa.mi.MapaIk[i].Sp))
                    {
                        //img.Opacity = 1;
                        //img.Focus();
                        canvasMapa.Children.RemoveAt(i);
                        canvasMapa.Children.Insert(i, img);
                        break;
                    }
                }
            }
        }

        private void canvasMapa_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(canvasMapa);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Spomenik sp = razdaljina(startPoint);

                if (sp != null)
                {
                    DataObject dragData = new DataObject("myFormat", sp);
                    DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
                }
            }

        }

        public Spomenik razdaljina(Point p)   //da znam da li sam kliknula na ikonicu
        {
            foreach (Ikonica icon in Mapa.mi.MapaIk)
            {
                if ((p.X > icon.X - 1  && p.X < icon.X + 30) && (p.Y > icon.Y - 1 && p.Y < icon.Y + 30))
                { 
                    return icon.Sp;
                }
            }

            return null;
        }


        internal void doThings(string param)
        {
            throw new NotImplementedException();
        }

        private void canvasMapa_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(this.canvasMapa);
            Spomenik sp = razdaljina(startPoint);

            if (System.Windows.Forms.MessageBox.Show("Da li ste sigurni da zelite da uklonite spomenik sa mape?",
                "Potvrda o uklanjanju spomenika", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question,
                System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {



                if (sp != null)
                {
                    for (int i = 0; i < Mapa.mi.MapaIk.Count; i++)
                    {
                        if (Mapa.mi.MapaIk[i].Sp.Id.Equals(sp.Id))
                        {
                            Ikonica tempS = Mapa.mi.MapaIk[i];
                            canvasMapa.Children.RemoveAt(i);

                            foreach (Tip t in tipoviTree)  //vrati ga u stablo
                            {

                                if (t.Equals(sp.Tip))
                                {
                                    t.SpomeniciUtipu.Add(sp);
                                }
                            }

                            Mapa.mi.MapaIk.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }


        private void canvasMapa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = 0;

          startPoint = e.GetPosition(this.canvasMapa);

            Spomenik pomS = razdaljina(startPoint);

            if (pomS != null)
            {
                for (i = 0; i < Mapa.mi.MapaIk.Count; i++)
                {
                    Image img = (Image)canvasMapa.Children[i];
                    canvasMapa.Children.RemoveAt(i);
                    canvasMapa.Children.Insert(i, img);
                    if (pomS.Id.Equals(Mapa.mi.MapaIk[i].Sp))
                    {
                        canvasMapa.Children.RemoveAt(i);
                        canvasMapa.Children.Insert(i, img);
                        break;
                    }
                }
            }
        }

        public void canvasMapa_AddIkonice()
        {

            foreach (Ikonica ikonica in Mapa.mi.MapaIk)
            {
                Image img = new Image();
                img.Height = 30;
                img.Width = 30;
                BitmapImage ikonicaSource = ikonica.Sp.Ikonica;
                img.Name = ikonica.Sp.Id;
                img.Source = ikonicaSource;

                Canvas.SetLeft(img, ikonica.X);
                Canvas.SetTop(img, ikonica.Y);

                canvasMapa.Children.Add(img);
            }



        }

        public void canvasMapa_RemoveIkonice()
        {

            canvasMapa.Children.Clear();

        }

        private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private bool CanDrop(double x, double y, Ikonica ikonica)
        {

          foreach(Ikonica ic in MapaIkonice.mapaIk)
            {
                if (ic != ikonica)
                {
                    if (Math.Abs(ic.X - x) < 25 && Math.Abs(ic.Y - y) < 30)
                    {

                        return false;
                    }
                }
            }

            return true;
        }

        private Image Informacije(Spomenik sp)
        {

            Image ikonica = new Image();     //preuzimamo ikonicu spomenika
            ikonica.Height = 30;
            ikonica.Width = 30;
            //ikonica.Name = sp.Id;
            ikonica.Source = sp.Ikonica;

            ToolTip tt = new ToolTip();         //ubacivanje tooltipa zajedno sa slicicom na canvas

            StackPanel glavniSP = new StackPanel();
            glavniSP.Orientation = Orientation.Horizontal;

            StackPanel stackP = new StackPanel();
            stackP.Orientation = Orientation.Vertical;

            StackPanel stackP2 = new StackPanel();
            stackP2.Orientation = Orientation.Vertical;

            TextBlock tbId = new TextBlock();
            tbId.Text = "Oznaka: " + sp.Id;
            stackP.Children.Add(tbId);

            TextBlock tbNaziv = new TextBlock();
            tbNaziv.Text = "Naziv: " + sp.Naziv;
            stackP.Children.Add(tbNaziv);


            TextBlock tbOpis = new TextBlock();
            tbOpis.Text = "Opis: " + sp.Opis;
            stackP.Children.Add(tbOpis);


            TextBlock tbTip = new TextBlock();
            tbTip.Text = "Tip: " + sp.Tip.Ime;
            stackP.Children.Add(tbTip);


            StackPanel spe = new StackPanel();
            spe.Orientation = Orientation.Horizontal;
            TextBlock tbEtikete = new TextBlock();
            tbEtikete.Text = "Etikete: ";
            spe.Children.Add(tbEtikete);

            foreach (Etiketa et in sp.Etikete)
            {
                tbEtikete = new TextBlock();
                tbEtikete.Margin = new Thickness(0, 0, 5, 0);
                tbEtikete.Width = 15;
                tbEtikete.Background = et.Boja;
                spe.Children.Add(tbEtikete);
            }

            stackP.Children.Add(spe);

            TextBlock tbEra = new TextBlock();
            tbEra.Text = "Era porekla: " + sp.EraPorekla;
            tbEra.Margin = new Thickness(10, 0, 0, 0);
            stackP2.Children.Add(tbEra);

            TextBlock tbTS = new TextBlock();
            tbTS.Text = "Turistički status: " + sp.TuristickiStatus;
            tbTS.Margin = new Thickness(10, 0, 0, 0);
            stackP2.Children.Add(tbTS);

            TextBlock tbPrihod = new TextBlock();
            tbPrihod.Text = "Godišnji prihod: " + sp.GPrihod + "$";
            tbPrihod.Margin = new Thickness(10, 0, 0, 0);
            stackP2.Children.Add(tbPrihod);

            TextBlock tbDatum = new TextBlock();
            tbDatum.Text = "Datum otkrivanja: " + sp.Datum;
            tbDatum.Margin = new Thickness(10, 0, 0, 0);
            stackP2.Children.Add(tbDatum);

            TextBlock tbAO = new TextBlock();
            string arh = "";
            if (sp.Arheoloski_obradjen)
            {
                arh = "da";
            }
            else
            {
                arh = "ne";
            }
            tbAO.Text = "Arheološki obrađen: " + arh;
            tbAO.Margin = new Thickness(10, 0, 0, 0);
            stackP2.Children.Add(tbAO);

            TextBlock tbUnesco = new TextBlock();
            string unesco = "";
            if (sp.Na_listi_UNESCO)
            {
                unesco = "da";
            }
            else
            {
                unesco = "ne";
            }
            tbUnesco.Text = "Na listi Unesco: " + unesco;
            tbUnesco.Margin = new Thickness(10, 0, 0, 0);
            stackP2.Children.Add(tbUnesco);

            TextBlock tbRegion = new TextBlock();
            string region = "";
            if (sp.U_naseljenom_regionu)
            {
                region = "da";
            }
            else
            {
                region = "ne";
            }
            tbRegion.Text = "U naseljenom regionu: " + region;
            tbRegion.Margin = new Thickness(10, 0, 0, 0);
            stackP2.Children.Add(tbRegion);

            glavniSP.Children.Add(stackP);
            glavniSP.Children.Add(stackP2);


            tt.Content = glavniSP;
            ikonica.ToolTip = tt;

            return ikonica;
        }

        private void ObrisiSaMape_Click(object sender, SelectionChangedEventArgs e)
        {

        }

    }

}
