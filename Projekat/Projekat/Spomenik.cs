using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace Projekat
{
    public class Spomenik : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String id;
        private String naziv;
        private String opis;
        private Tip tip;
        private string tipId = "";
        //private int era_porekla_int;
        private string era_porekla;
        //private String slika;
        private BitmapImage ikonica;
        private String ikonicaS;
        private byte[] byteIkonica;
        private bool arheoloski_obradjen;
        private bool na_listi_UNESCO;
        private bool u_naseljenom_regionu;
        //private int turisticki_st_int;
        private String turisticki_st;
        private double g_prihod;
        private DateTime datum;
        //private string strDatum = "";
        //private ObservableCollection<Etiketa> etikete = new ObservableCollection<Etiketa>();

        private ObservableCollection<Etiketa> etikete;  //prazna
        private  List<string> etId = new List<string>();

        public Spomenik() { Etikete = new ObservableCollection<Etiketa>(); }  //konstruktor


       

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                if (value != naziv)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }


        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }


        [JsonIgnore]
        public Tip Tip
        {
            get
            {
                return tip;
            }
            set
            {
                if (value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public string TipId
        {
            get
            {
                return tipId;
            }
            set
            {
                if (value != tipId)
                {
                    tipId = value;
                    OnPropertyChanged("TipId");
                }
            }
        }



        public string EraPorekla
        {
            get { return era_porekla; }
            set
            {
                if (value != era_porekla)
                {
                    era_porekla = value;
                    OnPropertyChanged("EraPorekla");
                }
            }
        }

        [JsonIgnore]
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

        public byte[] ByteIkonica
        {
            get
            {
                return byteIkonica;
            }
            set
            {
                if (value != byteIkonica)
                {
                    byteIkonica = value;
                    OnPropertyChanged("ByteIkonica");
                }
            }
        }

        public String IkonicaS
        {
            get
            {
                return ikonicaS;
            }
            set
            {
                if (value != ikonicaS)
                {
                    ikonicaS = value;
                    OnPropertyChanged("IkonicaS");
                }
            }
        }


        public bool Arheoloski_obradjen
        {
            get
            {
                return arheoloski_obradjen;
            }
            set
            {
                if (value != arheoloski_obradjen)
                {
                    arheoloski_obradjen = value;
                    OnPropertyChanged("Arheoloski_obradjen");
                }
            }
        }

        public bool Na_listi_UNESCO
        {
            get
            {
                return na_listi_UNESCO;
            }
            set
            {
                if (value != na_listi_UNESCO)
                {
                    na_listi_UNESCO = value;
                    OnPropertyChanged("Na_listi_UNESCO");
                }
            }
        }

        public bool U_naseljenom_regionu
        {
            get
            {
                return u_naseljenom_regionu;
            }
            set
            {
                if (value != u_naseljenom_regionu)
                {
                    u_naseljenom_regionu = value;
                    OnPropertyChanged("U_naseljenom_regionu");
                }
            }
        }

     

        public string TuristickiStatus
        {
            get { return turisticki_st; }
            set
            {
                if (value != turisticki_st)
                {
                    turisticki_st = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }

        public double GPrihod
        {
            get
            {
                return g_prihod;
            }
            set
            {
                if (value != g_prihod)
                {
                    g_prihod = value;
                    OnPropertyChanged("GPrihod");
                }
            }
        }

       [JsonIgnore]
        public DateTime Datum
        {
            get
            {
                if(datum == default(DateTime))
                {
                    return DateTime.Today.Date;
                }
                return datum.Date;
            }
            set
            {
                if (value != datum)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
         
      /*  public string StrDatum
        {
            get
            {
                return strDatum;
            }
            set
            {
                if (value != strDatum)
                {
                    strDatum = value;
                    OnPropertyChanged("StrDatum");
                }
            }
        }*/

        [JsonIgnore]
        public ObservableCollection<Etiketa> Etikete
        {
            get { return etikete; }
            set
            {
                if (value != etikete)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        
        public List<string> EtId
        {
            get { return etId; }
            set
            {
                if (value != etId)
                {
                    etId = value;
                    OnPropertyChanged("EtId");
                }
            }
        }


    }
}
 