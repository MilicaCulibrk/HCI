using System;
using System.Collections.Generic;
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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Mapa2.xaml
    /// </summary>
    public partial class Mapa2 : Page
    {
        public Point pomocna;
        Image pomocnaIkonica = new Image();

        public Mapa2(int br)
        {
            InitializeComponent();

            //canvasMapa2 = (Canvas)canvasMapa2.Parent;

            pomocnaIkonica.Height = 20;
            pomocnaIkonica.Width = 20;


            for (int i = 0; i < MapaIkonice.mapaIk.Count(); i++)
            {

                pomocna.X = MapaIkonice.mapaIk[i].X;
                pomocna.Y = MapaIkonice.mapaIk[i].Y;

                pomocnaIkonica.Name = MapaIkonice.mapaIk[i].Sp.Id;
                pomocnaIkonica.Source = MapaIkonice.mapaIk[i].Sp.Ikonica;

               // sale.Children.RemoveAt(i);
                //sale.Children.Insert(i, pomocnaIkonica);

                Canvas.SetLeft(pomocnaIkonica, pomocna.X);
                Canvas.SetTop(pomocnaIkonica, pomocna.Y);
            }
        }
    }
}
