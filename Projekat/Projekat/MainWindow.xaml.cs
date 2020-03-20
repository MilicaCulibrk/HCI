using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

    
       private Mapa mapa;
     
//////////////////////////////////////////////////OTVARANJE///////////////////////////////////////////////////////////
        public MainWindow()
        {
            /*string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamReader reader = new StreamReader(System.IO.Path.Combine(path, "tipovi.txt")))
            {
                string json1 = reader.ReadToEnd();
                string json4 = json1.Replace(@"\\\\", @"-");
                string json2 = json4.Replace(@"\", string.Empty);
                string json = json2.Replace(@"-", @"\\\\");
                List<Tip> res = JsonConvert.DeserializeObject<List<Tip>>(json.Trim().Substring(1, (json.Length - 2)));
                foreach (Tip t in res)
                {
                    t.Ikonica = ByteArrayToBitmapImage(t.ByteIkonica);
                }
                DodajTip.l = res;
            }


            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamReader reader = new StreamReader(System.IO.Path.Combine(path, "etikete.txt")))
            {
                string json1 = reader.ReadToEnd();
                string json4 = json1.Replace(@"\\\\", @"-");
                string json2 = json4.Replace(@"\", string.Empty);
                string json = json2.Replace(@"-", @"\\\\");
                List<Etiketa> res1 = JsonConvert.DeserializeObject<List<Etiketa>>(json.Trim().Substring(1, (json.Length - 2)));
                DodajEtiketu.le = res1;
            }

            string path3 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamReader reader = new StreamReader(System.IO.Path.Combine(path, "spomenici.txt")))
            {
                string json1 = reader.ReadToEnd();
                string json4 = json1.Replace(@"\\\\", @"-");
                string json2 = json4.Replace(@"\", string.Empty);
                string json = json2.Replace(@"-", @"\\\\");
                List<Spomenik> res2 = JsonConvert.DeserializeObject<List<Spomenik>>(json.Trim().Substring(1, (json.Length - 2)));
                foreach (Spomenik sp in res2)
                {
                    sp.Ikonica = ByteArrayToBitmapImage(sp.ByteIkonica);
                    //sp.Datum = DateTime.Parse(sp.StrDatum);
                    foreach (Tip t in DodajTip.l)
                    {
                        if (t.Ime.Equals(sp.TipId))
                        {
                            sp.Tip = t;
                        }

                    }

                    int broj = sp.EtId.Count();
                   
                    foreach (String oz in sp.EtId)
                    {
                        foreach (Etiketa et in DodajEtiketu.le)
                        {
                            if (et.Oznaka.Equals(oz))
                            {
                                sp.Etikete.Add(et);


                            }
                        }
                    }

                }
                DodajSpomenik.ls = res2;
            }

           string path4 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamReader reader = new StreamReader(System.IO.Path.Combine(path, "ikonice.txt")))
            {
                string json1 = reader.ReadToEnd();
                string json4 = json1.Replace(@"\\\\", @"-");
                string json2 = json4.Replace(@"\", string.Empty);
                string json = json2.Replace(@"-", @"\\\\");
                List<Ikonica> res4 = JsonConvert.DeserializeObject<List<Ikonica>>(json.Trim().Substring(1, (json.Length - 2)));
                MapaIkonice.mapaIk.Clear();
                foreach (Ikonica ic in res4)
                {
                    foreach (Spomenik sp in DodajSpomenik.ls)
                    {
                        if (ic.SpId.Equals(sp.Id))
                        {
                            ic.Sp = sp;
                            MapaIkonice.mapaIk.Add(ic);
                        }
                    }
                }

            } */

            InitializeComponent();
            mapa = new Mapa();
            Main.Content = new Pocetna();
            
         

        }

/////////////////////////////////////////////////////////DUGMAD///////////////////////////////////////////////////////
        private void Spomenik_Click(object sender, RoutedEventArgs e)
        {
            
            Main.Content = new TableS();
        }

      private void Etiketa_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TabelaE();
        }

        private void Tip_Click(object sender, RoutedEventArgs e)
        {
          
            Main.Content = new Tabela();
        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pocetna();
        }

        private void Mapa_Click(object sender, RoutedEventArgs e)
        {

            // Main.Content = mapa;
            // Main2.Content = new Mapa();

            Main.Content = new Mapa();
        }


 /////////////////////////////PRECICE/////////////////////////////////////////////////////////////////////////
        private void PrikazPocetne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PrikazPocetne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Main.Content = new Pocetna();
        }

        private void PrikazTipa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PrikazTipa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Main.Content = new Tabela();
        }

        private void PrikazEtikete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PrikazEtikete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Main.Content = new TabelaE();
        }


        private void PrikazSpomenika_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PrikazSpomenika_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Main.Content = new TableS();
        }

        private void PrikazMape_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PrikazMape_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Main.Content = new Mapa();
        }



////////////////////////////////////////////////////ZATVARANJE/////////////////////////////////////////////////////
        private void Window_Closing(object sender, CancelEventArgs e)
        {
           if(System.Windows.Forms.MessageBox.Show("Da li zelite da sacuvate izmene?",
                "Potvrda o cuvanju izmena", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question,
                System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                var json = JsonConvert.SerializeObject(DodajTip.l);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (StreamWriter file = File.CreateText(System.IO.Path.Combine(path, "tipovi.txt")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, json);
                }

                var json1 = JsonConvert.SerializeObject(DodajEtiketu.le);
                string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (StreamWriter file = File.CreateText(System.IO.Path.Combine(path1, "etikete.txt")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, json1);
                }

                var json2 = JsonConvert.SerializeObject(DodajSpomenik.ls);
                string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (StreamWriter file = File.CreateText(System.IO.Path.Combine(path2, "spomenici.txt")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, json2);
                }

                int br = 0;
                int ind = 0;
                foreach (Ikonica ik in MapaIkonice.mapaIk)
                {
                    foreach (String stari in TableS.stariId)
                    {
                        if (ik.SpId.Equals(stari))
                        {
                            ind = TableS.index[br];
                            ik.SpId = DodajSpomenik.ls[ind].Id;
                            br++;
                        }
                    }

                }
                TableS.stariId.Clear();
                TableS.index.Clear();

                var json3 = JsonConvert.SerializeObject(MapaIkonice.mapaIk);
                string path3 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (StreamWriter file = File.CreateText(System.IO.Path.Combine(path2, "ikonice.txt")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, json3);
                }

            }


        }

        public static BitmapImage ByteArrayToBitmapImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                //image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

    }
}
