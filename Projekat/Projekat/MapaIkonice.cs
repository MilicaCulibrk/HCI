using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{

    [Serializable]

    class MapaIkonice : INotifyPropertyChanged
    {

        public static ObservableCollection<Ikonica> mapaIk = new ObservableCollection<Ikonica>();

        public MapaIkonice()
        {

            this.MapaIk = mapaIk;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<Ikonica> MapaIk
        {
            get { return mapaIk; }
            set
            {
                if (mapaIk != value)
                {
                    mapaIk = value;
                    OnPropertyChanged("MapaIk");
                }
            }
        }
    }
}
