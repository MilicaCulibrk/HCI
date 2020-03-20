using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace Projekat
{
    [Serializable]
    public class Etiketa : INotifyPropertyChanged
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
        private string opis;
        private SolidColorBrush boja;
        private bool otkaceno;


        public Etiketa()
        {

        }

        public Etiketa(Etiketa et)
        {
            this.oznaka = oznaka;
            this.boja = boja;
            this.opis = opis;
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

      

        //[field: NonSerialized]

       
        public SolidColorBrush Boja
        {
            get { return boja; }
            set
            {

                if (value != boja)
                {
                    boja = value;
                  
                    OnPropertyChanged("Boja");
                }
            }
        }

        public bool Otkaceno
        {
            get
            {
                return otkaceno;
            }
            set
            {
                if (value != otkaceno)
                {
                    otkaceno = value;
                    OnPropertyChanged("Otkaceno");
                }

            }
        }



    }
}