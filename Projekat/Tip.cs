using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Projekat
{
    [Serializable]
    public class Tip : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string oznaka;
        private string ime;
        private BitmapImage ikonica;
        private string opis;

        public Tip()
        {


        }
       

        public Tip(String oznakaT, String imeT, String opisT)
        {
            this.oznaka = oznakaT;
            this.ime = imeT;
            this.opis = opisT;
        }

        public string Oznaka
        {
            get { return oznaka; }
            set
            {
                if (value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }

            }
        }

     public string Ime
        {
            get { return ime; }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }


        public BitmapImage Ikonica
        {
            get
            {
                return ikonica;
            }
            set
            {
                if (value != ikonica)
                {
                    ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }


        public string Opis
        {
            get { return opis; }
            set
            {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
    }
}
