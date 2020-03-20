using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projekat
{
    [Serializable]

    class Ikonica : INotifyPropertyChanged
    {

        private double x;   //koordinate
        private double y;
        private Spomenik sp;
        private string spId;


        public event PropertyChangedEventHandler PropertyChanged;

        public Ikonica(double x, double y, Spomenik sp, string spId)
        {
            this.x = x;
            this.y = y;
            this.sp = sp;
            this.spId = spId;
        }

       
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        [JsonIgnore]
        public Spomenik Sp
        {
            get { return this.sp; }
            set
            {
                if (this.sp != value)
                {
                    sp = value;
                    OnPropertyChanged("Sp");
                }
            }
        }

        public string SpId
        {
            get { return this.spId; }
            set
            {
                if (this.spId != value)
                {
                    spId = value;
                    OnPropertyChanged("SpId");
                }
            }
        }
    }
}
