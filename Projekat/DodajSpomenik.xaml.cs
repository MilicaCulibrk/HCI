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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for DodajSpomenik.xaml
    /// </summary>
    /// 

    public partial class DodajSpomenik : Page
    {

        public Spomenik Spomenik { get; set; }
        public static List<Spomenik> ls = new List<Spomenik>();
        public static List<string> eraPorekla { get; set; }
        public List<string> turistickiSt { get; set; }
        public static ObservableCollection<Tip> Tipovi { get; set; }
        public static ObservableCollection<Etiketa> Etikete { get; set; }
        
        public DodajSpomenik()      //konstruktor bez parametara
        {
            InitializeComponent();
            this.DataContext = this;
            this.Spomenik = new Spomenik();
            Tipovi = Tabela.Tipovi;
            Etikete = TabelaE.Etikete;
           /* funcButton.Content = "Dodaj";
            funcButton.Click += new RoutedEventHandler(DodajSpomenik);*/

            InitLists();
        }

        public DodajSpomenik(Spomenik spomenik)      //konstruktor sa parametrima
        {
            InitializeComponent();
            this.DataContext = this;
            this.Spomenik = spomenik;
            Tipovi = Tabela.Tipovi;
            Etikete = TabelaE.Etikete;
            /* funcButton.Content = "Izmeni";
             funcButton.Click += new RoutedEventHandler(IzmeniSpomenik);*/

            InitLists();
            tipoviCbox.SelectedIndex = Tipovi.IndexOf(Spomenik.Tip);
            eraPoreklaCbox.SelectedIndex = eraPorekla.IndexOf(Spomenik.EraPorekla);
            turistickiStatusCbox.SelectedIndex = turistickiSt.IndexOf(Spomenik.TuristickiStatus);
            foreach (Etiketa etiketa in Spomenik.Etikete)
            {
                etiketeList.SelectedItems.Add(etiketa);
            }

          
        }

        protected void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            AzurirajInformacije();
            ls.Add(Spomenik);
            Sp.Content = new TableS();
        }

        protected void AzurirajInformacije()
        {
            this.Spomenik.Id = idTxT.Text;
            this.Spomenik.Naziv = nazivTxT.Text;
            this.Spomenik.Opis = opisTxt.Text;
            this.Spomenik.Tip = (Tip)tipoviCbox.SelectedValue;
            if (etiketeList.SelectedItem != null)
            {
                this.Spomenik.Etikete.Clear();
                foreach (var item in etiketeList.SelectedItems)
                {
                    this.Spomenik.Etikete.Add((Etiketa)item);
                }
            }
            else
            {
                this.Spomenik.Etikete.Clear();
            }
            this.Spomenik.EraPorekla = (string)eraPoreklaCbox.SelectedValue;
            if (icon.Source == null)
                this.Spomenik.Ikonica = this.Spomenik.Tip.Ikonica;
            else 
                this.Spomenik.Ikonica = (BitmapImage)icon.Source;

            this.Spomenik.TuristickiStatus = (string)turistickiStatusCbox.SelectedValue;
            this.Spomenik.Arheoloski_obradjen = (bool)arheoloskiObradjen.IsChecked;
            this.Spomenik.Na_listi_UNESCO = (bool)naListiUnesco.IsChecked;
            this.Spomenik.U_naseljenom_regionu = (bool)uNaseljenomRegionu.IsChecked;
            this.Spomenik.Datum = (DateTime)datePicker.SelectedDate;
            this.Spomenik.GPrihod = Double.Parse(prihodTxt.Text);
        }

        private void InitLists()
        {
            eraPorekla = new List<string>();
            eraPorekla.Add("Paleolit");
            eraPorekla.Add("Neolit");
            eraPorekla.Add("Stari vek");
            eraPorekla.Add("Srednji vek");
            eraPorekla.Add("Renesansa");
            eraPorekla.Add("Moderno doba");

            turistickiSt = new List<string>();
            turistickiSt.Add("Eksploatisan");
            turistickiSt.Add("Dostupan");
            turistickiSt.Add("Nedostupan");
        }

        private void Ucitaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Ikonice";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                icon.Source = ResizeImage(System.Drawing.Image.FromFile(bitmap.UriSource.LocalPath.ToString()), 25, 25);
            }
        }

        public static BitmapImage ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            using (var memory = new MemoryStream())
            {
                destImage.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }

}

  




    /* public partial class DodajSpomenik : Page, INotifyPropertyChanged
     {
         private Spomenik s = null;
         private Spomenik editS = null;
         public static List<Spomenik> ls = new List<Spomenik>();

         public DodajSpomenik()
         {
             InitializeComponent();
             this.s = new Spomenik();

             s.Types = Tabela.Tipovi;
             s.Eticets = TabelaE.Etikete;
             this.DataContext = s;
         }

         public DodajSpomenik(Spomenik editSpomenik)
         {
             InitializeComponent();
             this.s = new Spomenik();

             this.editS = editSpomenik;


             s.Id = editS.Id;
             s.Naziv = editS.Naziv;
             s.Opis = editS.Opis;
             s.Era = editS.Era;
             s.Tip = editS.Tip;
             s.Arheoloski_obradjen = editS.Arheoloski_obradjen;
             s.Na_listi_UNESCO = editS.Na_listi_UNESCO;
             s.U_naseljenom_regionu = editS.U_naseljenom_regionu;
             s.Turisticki_st = editS.Turisticki_st;
             s.Slika = editS.Slika;
             s.GPrihod = editS.GPrihod;
             s.Datum = editS.Datum;
             s.Etikete = editS.Etikete;
             s.Types = Tabela.Tipovi;
             s.Eticets = TabelaE.Etikete;

             foreach (Etiketa et in s.Etikete)
             {
                 foreach (Etiketa etik in s.Eticets) //sve etikete
                 {
                     if (etik.Boja.Equals(et.Boja))
                     {
                         etik.Otkaceno = true;
                     }
                 }
             }

             this.DataContext = s;


         }



                     public event PropertyChangedEventHandler PropertyChanged;


         protected virtual void OnPropertyChanged(string name)
         {
             if (PropertyChanged != null)
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(name));
             }
         }

         private void Dodaj_Click(object sender, RoutedEventArgs e)
         {
             /* Spomenik s = new Spomenik();

              s.Id = id.Text;
              s.Naziv = naziv.Text;
              s.Opis = opis.Text;
              s.Era_int = eraP.SelectedIndex;

              if (s.Era_int == 1)
              {
                  s.Era = "paleolit";
              }
              else if (s.Era_int == 2)
              {
                  s.Era = "neolit";
              }
              else if (s.Era_int == 3)
              {
                  s.Era = "stari vek";
              }
              else if (s.Era_int == 4)
              {
                  s.Era = "srednji vek";
              }
              else if (s.Era_int == 5)
              {
                  s.Era = "renesansa";
              }
              else if (s.Era_int == 6)
              {
                  s.Era = "moderno doba";
              }
              else
              {
                  s.Era = "";
              }


              s.Tip.Ime = tip.DisplayMemberPath;
              s.Arheoloski_obradjen = (bool)arhObradjen.IsChecked;
              s.Na_listi_UNESCO = (bool)listaU.IsChecked; 
              s.U_naseljenom_regionu = (bool)naseljenaRegija.IsChecked;
              s.Turisticki_st_int = turistickiStatus.SelectedIndex;


             if (s.Turisticki_st_int == 1)
             {
                 s.Turisticki_st = "paleolit";
             }
             else if (s.Turisticki_st_int == 2)
             {
                 s.Turisticki_st = "neolit";
             }
             else if (s.Turisticki_st_int == 3)
             {
                 s.Turisticki_st = "stari vek";
             }
             else if{ 
                 s.Turisticki_st = "moderno doba";
             }
             else
             {
                 s.Turisticki_st = "";
             }

              s.Slika = (ikonicaShow.Source).ToString();
              s.GPrihod = double.Parse(prihod.Text);
              s.Datum = (DateTime)datum.SelectedDate; 

             //s.Etikete = listaEtiketa.ItemsSource;

             s.ProveriChekiraneEtikete();

             //dodavanje u glavnu listu
             ls.Add(s);

             Sp.Content = new TableS();

             s = null;

         }

     }*/




