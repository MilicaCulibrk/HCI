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
        public List<string> eraPorekla { get; set; }
        public List<string> turistickiSt { get; set; }
        public static ObservableCollection<Tip> Tipovi { get; set; }
        public static ObservableCollection<Etiketa> Etikete { get; set; }
        double cena1;

        public DodajSpomenik()      //konstruktor bez parametara
        {
            InitializeComponent();
            this.DataContext = this;
            this.Spomenik = new Spomenik();
            Tipovi = new ObservableCollection<Tip>(DodajTip.l);
            Etikete = new ObservableCollection<Etiketa>(DodajEtiketu.le);
            /* funcButton.Content = "Dodaj";
             funcButton.Click += new RoutedEventHandler(DodajSpomenik);*/

            InitLists();
        }

        public DodajSpomenik(Spomenik spomenik)      //konstruktor sa parametrima
        {
            InitializeComponent();
            this.DataContext = this;
            this.Spomenik = spomenik;
            Tipovi = new ObservableCollection<Tip>(DodajTip.l);
            Etikete = new ObservableCollection<Etiketa>(DodajEtiketu.le);
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
           // Spomenik.EtId.Clear();
           

        }

        protected void Dodaj_Click(object sender, RoutedEventArgs e)
        {
          
            if (validate())
            {
                
                AzurirajInformacije();

                int flag = 0;
                foreach (Spomenik spmn in DodajSpomenik.ls)
                {
                    if (this.Spomenik.Id.Equals(spmn.Id))
                    {
                        idTxT.BorderBrush = System.Windows.Media.Brushes.Red;
                        System.Windows.MessageBox.Show("Već postoji spomenik sa istim  id-em. Unesite drugačiji id spomenika!");
                        flag = 1;
                        break;
                    }
                }

                if (flag == 0)
                {
                    ls.Add(Spomenik);
                    Sp.Content = new TableS();
                }

          
            }
            else
            {
                System.Windows.MessageBox.Show("Molimo Vas da popunite prazna polja!");
            }
          
        }

        protected void AzurirajInformacije()
        {
            this.Spomenik.Id = idTxT.Text;
            this.Spomenik.Naziv = nazivTxT.Text;
            this.Spomenik.Opis = opisTxt.Text;
            this.Spomenik.Tip = (Tip)tipoviCbox.SelectedValue;

            Spomenik.TipId = Spomenik.Tip.Ime;

            if (etiketeList.SelectedItem != null)
            {
                this.Spomenik.Etikete.Clear();
                foreach (var item in etiketeList.SelectedItems)
                {
                    this.Spomenik.Etikete.Add((Etiketa)item);
                    
                }

                foreach (Etiketa et in this.Spomenik.Etikete)
                {
                    Spomenik.EtId.Add(et.Oznaka);
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

            Spomenik.ByteIkonica = BitmapImageToByteArray(Spomenik.Ikonica);
            //Spomenik.StrDatum = Spomenik.Datum.ToString();

            this.Spomenik.IkonicaS = icon.Source.ToString();
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
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
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

        public static byte[] BitmapImageToByteArray(BitmapImage bitmapImage)  //pretvaranje slike
        {
            byte[] data;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        private bool validate()
        {
            bool validation = true;

            if (idTxT.Text == "")
            {
                //labelaID.Content = "*Morate uneti odgovarajuci tekst!";
                idTxT.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //labelaID.Content = "";
                idTxT.BorderBrush = System.Windows.Media.Brushes.Black;
            }

            if (nazivTxT.Text == "")
            {
               // labelaIme.Content = "*Morate uneti odgovarajuci text!";
                nazivTxT.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //labelaIme.Content = "";
                nazivTxT.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            if (opisTxt.Text == "")
            {
                //labelaOpis.Content = "*Morate uneti odgovarajuci tekst!";
                opisTxt.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //labelaOpis.Content = "";
                opisTxt.BorderBrush = System.Windows.Media.Brushes.Black;
            }
           /* if (datum.Text == "")
            {
                labelaDatum.Content = "*Morate uneti datum!";
                datum.BorderBrush = Brushes.Red;

                validation = false;
            }
            else
            {
                labelaDatum.Content = "";
                datum.BorderBrush = Brushes.Black;
            }*/
            if (eraPoreklaCbox.Text == "")
            {
                //labelaAlkohol.Content = "*Morate odabrati status!";
                eraPoreklaCbox.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //labelaAlkohol.Content = "";
                eraPoreklaCbox.BorderBrush = System.Windows.Media.Brushes.Black;
            }
           /* if (Etikete.Count() == 0)
            {
                labelE.Content = "*Morate odabrati bar jednu etiketu!";
                etiketeList.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                labelE.Content = "";
                etiketeList.BorderBrush = System.Windows.Media.Brushes.Black;
            }*/
            if (turistickiStatusCbox.Text == "")
            {
                //labelaCena.Content = "*Morate odabrati kategoriju!";
                turistickiStatusCbox.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //labelaCena.Content = "";
                turistickiStatusCbox.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            if (datePicker.Text == "")
            {
                datePicker.BorderBrush = System.Windows.Media.Brushes.Red;
                validation = false;
            }
            else
            {
                datePicker.BorderBrush = System.Windows.Media.Brushes.Black;
            }


            if (tipoviCbox.Text == "")
            {
                //labelaTip.Content = "*Morate odabrati tip!";
                tipoviCbox.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //labelaTip.Content = "";
                tipoviCbox.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        
            if (prihodTxt.Text == "0")
            {
                labella.Content = "*Morate uneti cenu!";
                prihodTxt.BorderBrush = System.Windows.Media.Brushes.Red;
                prihodTxt.BorderThickness = new Thickness(1);
                validation = false;
            }
            else
            {
                //labelaBr.Content = "";
                prihodTxt.BorderBrush = System.Windows.Media.Brushes.Black;

                try
                {
                    cena1 = double.Parse(prihodTxt.Text.Trim());
                    if (cena1 < 0)
                    {
                        labella.Content = "*Morate uneti pozitivan broj!";
                        prihodTxt.BorderBrush = System.Windows.Media.Brushes.Red;
                        prihodTxt.BorderThickness = new Thickness(1);
                        validation = false;
                    }
                }
                catch (Exception e)
                {
                    labella.Content = "*Morate uneti broj!";
                    prihodTxt.BorderBrush = System.Windows.Media.Brushes.Red;
                    prihodTxt.BorderThickness = new Thickness(1);
                    validation = false;
                }

            }

            return validation;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Sp.Content = new TableS();
        }


    }

}

  



