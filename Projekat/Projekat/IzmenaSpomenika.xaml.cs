using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for IzmenaSpomenika.xaml
    /// </summary>
    public partial class IzmenaSpomenika : Page
    {
        public Spomenik Spomenik{get; set; }
        //public List<string> eraPorekla { get; set; }
        public List<string> turistickiSt { get; set; }
        public static ObservableCollection<Tip> Tipovi3 { get; set; }
        
        public ObservableCollection<Etiketa> Etikete3 { get; set; }
        public ObservableCollection<Etiketa> EtiketePomocna { get; set; }
        double cena1;



        public IzmenaSpomenika(Spomenik s)
        {
            Spomenik = s;
            InitializeComponent();
            this.DataContext = s;

            Tipovi3 = new ObservableCollection<Tip>(DodajTip.l);
            // tipoviCbox.SelectedIndex = Tipovi.IndexOf(Spomenik.Tip);
            tipoviCbox.ItemsSource = DodajTip.l;

            this.Etikete3 = new ObservableCollection<Etiketa>(DodajEtiketu.le);
            //this.EtiketePomocna = DodajSpomenik.Etikete;
            etiketeList.ItemsSource = DodajEtiketu.le;
            /* foreach (Etiketa etiketa in TabelaE.Etikete)
             {
                 etiketeList.SelectedItems.Add(etiketa);
             }*/

            etiketeList.SelectedItems.Clear();
            foreach (Etiketa et in Spomenik.Etikete)
            {
                etiketeList.SelectedItems.Add(et);
            }

            //InitLists();
            tipoviCbox.SelectedIndex = DodajTip.l.IndexOf(Spomenik.Tip);
           // Spomenik.EtId.Clear();
            //eraPoreklaCbox.SelectedIndex = eraPorekla.IndexOf(Spomenik.EraPorekla);
            //turistickiStatusCbox.SelectedIndex = turistickiSt.IndexOf(Spomenik.TuristickiStatus);

        }


        private void Izm_Click(object sender, RoutedEventArgs e)
        {
            

            if (validate())
            {
         
                int f = 0;


                foreach (Spomenik spmn in DodajSpomenik.ls)
                {
                    if (!Spomenik.Equals(spmn))
                    {
                        if (idTxT.Text.Equals(spmn.Id))
                        {
                            idTxT.BorderBrush = System.Windows.Media.Brushes.Red;
                            System.Windows.MessageBox.Show("Već postoji spomenik sa istim id-em. Unesite drugačiji id spomenika!");
                            f = 1;
                            break;
                        }
                    }
                }


              
                nazivTxT.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                opisTxt.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                eraPoreklaCbox.GetBindingExpression(System.Windows.Controls.ComboBox.TextProperty).UpdateSource();
                arheoloskiObradjen.GetBindingExpression(System.Windows.Controls.Primitives.ToggleButton.IsCheckedProperty).UpdateSource();
                uNaseljenomRegionu.GetBindingExpression(System.Windows.Controls.CheckBox.IsCheckedProperty).UpdateSource();
                naListiUnesco.GetBindingExpression(System.Windows.Controls.Primitives.ToggleButton.IsCheckedProperty).UpdateSource();
                turistickiStatusCbox.GetBindingExpression(System.Windows.Controls.ComboBox.TextProperty).UpdateSource();
                iconica.GetBindingExpression(System.Windows.Controls.Image.SourceProperty).UpdateSource();
                datePicker.GetBindingExpression(System.Windows.Controls.DatePicker.SelectedDateProperty).UpdateSource();
                prihodTxt.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                //tipoviCbox.GetBindingExpression(System.Windows.Controls.ComboBox.TextProperty).UpdateSource();

                Spomenik.ByteIkonica = BitmapImageToByteArray(Spomenik.Ikonica);


                this.Spomenik.Tip = (Tip)tipoviCbox.SelectedValue;

                Spomenik.TipId = Spomenik.Tip.Ime;




                int i = 0;
                foreach (var item in etiketeList.SelectedItems)
                {

                    //  Spomenik.Etikete.Clear();
                    Spomenik.Etikete.Add((Etiketa)item);
                    i++;
                }

                if (i != 0)
                {
                    for (int j = 0; j < (Spomenik.Etikete.Count - i); j++)
                    {
                        Spomenik.Etikete.RemoveAt(0);
                        i--;
                    }
                }


                Spomenik.EtId.Clear();
                foreach (Etiketa et in Spomenik.Etikete)
                {
                    Spomenik.EtId.Add(et.Oznaka);
                }

                i = 0;

                if(f == 0)
                {
                  
                    idTxT.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                 
                    Sp.Content = new TableS();
                }
                else
                {

                    Sp.Content = new IzmenaSpomenika(Spomenik);
                }

               
               
            }
            else
            {

                System.Windows.MessageBox.Show("Molimo Vas da popunite prazna polja!");
            }
          

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
                iconica.Source = ResizeImage(System.Drawing.Image.FromFile(bitmap.UriSource.LocalPath.ToString()), 25, 25);
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
            if (datePicker.Text == "")
            {
                //labelaOpis.Content = "*Morate uneti odgovarajuci tekst!";
                datePicker.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //labelaOpis.Content = "";
                datePicker.BorderBrush = System.Windows.Media.Brushes.Black;
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
