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
        public ObservableCollection<Tip> Tipovi { get; set; }
        
        public ObservableCollection<Etiketa> Etikete { get; set; }

        //public List<string> ep { get; set; }

        public IzmenaSpomenika(Spomenik s)
        {
            Spomenik = s;
            InitializeComponent();
            this.DataContext = s;

            this.Tipovi = DodajSpomenik.Tipovi;
            tipoviCbox.ItemsSource = DodajSpomenik.Tipovi;

            this.Etikete = DodajSpomenik.Etikete;
            etiketeList.ItemsSource = DodajSpomenik.Etikete;
            /* foreach (Etiketa etiketa in TabelaE.Etikete)
             {
                 etiketeList.SelectedItems.Add(etiketa);
             }*/

            //this.ep = DodajSpomenik.eraPorekla;

            //eraPoreklaCbox.ItemsSource = eraPorekla;

            //InitLists();
           

            tipoviCbox.SelectedIndex = Tipovi.IndexOf(Spomenik.Tip);
            //eraPoreklaCbox.SelectedIndex = eraPorekla.IndexOf(Spomenik.EraPorekla);
          //  turistickiStatusCbox.SelectedIndex = turistickiSt.IndexOf(Spomenik.TuristickiStatus);
            
        }

       /* private void InitLists()
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
        } */

        private void Izm_Click(object sender, RoutedEventArgs e)
        {
            idTxT.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
            nazivTxT.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
            opisTxt.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
            eraPoreklaCbox.GetBindingExpression(System.Windows.Controls.ComboBox.TextProperty).UpdateSource();
            arheoloskiObradjen.GetBindingExpression(System.Windows.Controls.Primitives.ToggleButton.IsCheckedProperty).UpdateSource();
            uNaseljenomRegionu.GetBindingExpression(System.Windows.Controls.CheckBox.IsCheckedProperty).UpdateSource();
            naListiUnesco.GetBindingExpression(System.Windows.Controls.Primitives.ToggleButton.IsCheckedProperty).UpdateSource();
            //turistickiSt.GetBindingExpression(System.Windows.Controls.ComboBox.TextProperty).UpdateSource();
            iconica.GetBindingExpression(System.Windows.Controls.Image.SourceProperty).UpdateSource();
            datePicker.GetBindingExpression(System.Windows.Controls.DatePicker.SelectedDateProperty).UpdateSource();
            prihodTxt.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
      

            this.Spomenik.Tip = (Tip)tipoviCbox.SelectedValue;
            //this.Spomenik.EraPorekla = (string)eraPoreklaCbox.SelectedValue;
            //this.Spomenik.TuristickiStatus = (string)turistickiStatusCbox.SelectedValue;

            //tipoviCbox.GetBindingExpression(System.Windows.Controls.ComboBox.TextProperty).UpdateSource();

            Spomenik.Etikete.Clear();
            foreach (var item in etiketeList.SelectedItems)
            {
                Spomenik.Etikete.Add((Etiketa)item);
            }
            Sp.Content = new TableS();

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

    }
}
