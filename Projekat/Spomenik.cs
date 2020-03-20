using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
        //private int era_porekla_int;
        private string era_porekla;
        //private String slika;
        private BitmapImage ikonica;
        private bool arheoloski_obradjen;
        private bool na_listi_UNESCO;
        private bool u_naseljenom_regionu;
        //private int turisticki_st_int;
        private String turisticki_st;
        private double g_prihod;
        private DateTime datum;
        //private ObservableCollection<Etiketa> etikete = new ObservableCollection<Etiketa>();

        private ObservableCollection<Etiketa> etikete;  //prazna
        public Spomenik() { Etikete = new ObservableCollection<Etiketa>(); }  //konstruktor


       /* public Spomenik(string id, string naziv, string opis, Tip tip, int era_porekla_int, string era_porekla, string slika, bool arheoloski_obradjen, bool na_listi_UNESCO, bool u_naseljenom_regionu, int turisticki_st_int, string turisticki_st, double g_prihod, DateTime datum, ObservableCollection<Etiketa> etikete)
        {
            this.id = id;
            this.naziv = naziv;
            this.opis = opis;
            this.tip = tip;
            this.era_porekla_int = era_porekla_int;
            this.era_porekla = era_porekla; 
            this.slika = slika;
            this.arheoloski_obradjen = arheoloski_obradjen;
            this.na_listi_UNESCO = na_listi_UNESCO;
            this.u_naseljenom_regionu = u_naseljenom_regionu;
            this.turisticki_st_int = turisticki_st_int;
            this.turisticki_st = turisticki_st;
            this.g_prihod = g_prihod;
            this.datum = datum;
            this.etikete = etikete;
        }*/

       

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

        /*public int Era_int
        {
            get
            {
                return era_porekla_int;
            }
            set
            {
                if (value != era_porekla_int)
                {
                    era_porekla_int = value;
                    OnPropertyChanged("Era_int");
                }
            }
        }

        public String Era
        {
            get
            {
                if (era_porekla_int == 1)
                {
                    era_porekla = "paleolit";
                }
                else if (era_porekla_int == 2)
                {
                    era_porekla = "neolit";
                }
                else if (era_porekla_int == 3)
                {
                    era_porekla = "stari vek";
                }
                else if (era_porekla_int == 4)
                {
                    era_porekla = "srednji vek";
                }
                else if (era_porekla_int == 5)
                {
                    era_porekla = "renesansa";
                }
                else if (era_porekla_int == 6)
                {
                    era_porekla = "moderno doba";
                }
                else
                {
                    era_porekla = "";
                }
                return era_porekla;
                }
                    set
                {
                        if (value != era_porekla)
                        {
                            era_porekla = value;
                            OnPropertyChanged("Era");
                        }
                    }
                } 

        */

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

        /*public int Turisticki_st_int
        {
            get
            {
                return turisticki_st_int;
            }
            set
            {
                if (value != turisticki_st_int)
                {
                    turisticki_st_int = value;
                    OnPropertyChanged("Turisticki_st_int");
                }
            }
        }

        public String Turisticki_st
        {
            get
            {
                if (turisticki_st_int == 1)
                {
                    turisticki_st = "eksploatisan";
                }
                else if (turisticki_st_int == 2)
                {
                    turisticki_st = "dostupan";
                }
                else if (turisticki_st_int == 3)
                {
                    turisticki_st = "nedostupan";
                }
                else
                {
                    turisticki_st = "";
                }
                return turisticki_st;
            }
            set
            {
                if (value != turisticki_st)
                {
                    turisticki_st = value;
                    OnPropertyChanged("Turisticki_st");
                }
            }
        }*/

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


        public DateTime Datum
        {
            get
            {
                return datum;
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

        /*  public ObservableCollection<Etiketa> Etikete
          {
              get
              {
                  return etikete;
              }
              set
              {
                  if (value != etikete)
                  {
                      etikete = value;
                      OnPropertyChanged("Etikete");
                  }
              }
          }

          public void ProveriChekiraneEtikete()
          {
              etikete.Clear();
              foreach (Etiketa e in Eticets)
              {
                  if (e.Otkaceno)
                  {
                      Console.WriteLine("Otkacena etiketa: " + e.Oznaka);
                      e.Otkaceno = false;
                      if (!etikete.Contains(e))
                          etikete.Add(e);
                  }

              }
          }

          private ObservableCollection<Etiketa> eticets;
          public ObservableCollection<Tip> types;

          public ObservableCollection<Etiketa> Eticets
          {
              get
              {
                  return eticets;
              }
              set
              {
                  if (value != eticets)
                  {
                      eticets = value;
                      OnPropertyChanged("Eticets");
                  }
              }

          }

          public ObservableCollection<Tip> Types
          {
              get
              {
                  return types;
              }
              set
              {
                  if (value != types)
                  {
                      types = value;
                      OnPropertyChanged("Types");
                  }
              }

          } */

    }
}
 