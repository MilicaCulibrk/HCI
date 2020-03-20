using System;
using System.Collections.Generic;
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
    /// Interaction logic for IzmenaTipa.xaml
    /// </summary>
    public partial class IzmenaTipa : Page
    {
        private Tip tip = new Tip();
       
        public IzmenaTipa(Tip t)
        {
            tip = t;
            InitializeComponent();
            this.DataContext = t;
         
        }

        private void Izm_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {

                int flag = 0;


                foreach (Tip t in Tabela.Tipovi)
                {
                    if (!t.Equals(tip))
                    {
                        if (textBoxOznaka.Text.Equals(t.Oznaka))
                        {
                            textBoxOznaka.BorderBrush = System.Windows.Media.Brushes.Red;
                            System.Windows.MessageBox.Show("Već postoji tip sa istom ozankom. Unesite drugačiju oznaku tipa!");
                            flag = 1;
                            break;
                        }
                    }
                }

                textBoxIme.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                TextBoxOpis.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                iconica.GetBindingExpression(System.Windows.Controls.Image.SourceProperty).UpdateSource();

                tip.ByteIkonica = BitmapImageToByteArray(tip.Ikonica);


                if (flag == 0)
                {
                    textBoxOznaka.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();


                    Frejm.Content = new Tabela();
                }
                else
                {
                    Frejm.Content = new IzmenaTipa(tip);
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

            if (textBoxOznaka.Text == "")
            {
                //LabelaID.Content = "*Morate uneti odgovarajuci tekst!";
                textBoxOznaka.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                // LabelaID.Content = "";
                textBoxOznaka.BorderBrush = System.Windows.Media.Brushes.Black;
            }

            if (textBoxIme.Text == "")
            {
                //LabelaIME.Content = "*Morate uneti odgovarajuci text!";
                textBoxIme.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //LabelaIME.Content = "";
                textBoxIme.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            if (TextBoxOpis.Text == "")
            {
                //LabelaOpis.Content = "*Morate uneti odgovarajuci tekst!";
                TextBoxOpis.BorderBrush = System.Windows.Media.Brushes.Red;

                validation = false;
            }
            else
            {
                //LabelaOpis.Content = "";
                TextBoxOpis.BorderBrush = System.Windows.Media.Brushes.Black;
            }
          
             return validation;
            }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Frejm.Content = new Tabela();
        }

    }
    }
