using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekat.Komande
{
    class RoutedCommands
    {


////////////////////////////////////////////////GLAVNI MENI/////////////////////////////////////////////////////////
        public static readonly RoutedUICommand PrikazPocetne = new RoutedUICommand(
        "Prikaz Pocetne",
        "PrikazPocetne",
        typeof(RoutedCommands),
        new InputGestureCollection()
        {
                new KeyGesture(Key.P, ModifierKeys.Control),
                new KeyGesture(Key.P, ModifierKeys.Alt | ModifierKeys.Control)

        }
        );

        public static readonly RoutedUICommand PrikazTipa = new RoutedUICommand(
        "Prikaz Tipa",
        "PrikazTipa",
        typeof(RoutedCommands),
        new InputGestureCollection()
        {
                new KeyGesture(Key.T, ModifierKeys.Control),
                new KeyGesture(Key.T, ModifierKeys.Alt | ModifierKeys.Control)

        }
        );

        public static readonly RoutedUICommand PrikazEtikete = new RoutedUICommand(
            "Prikaz Etikete",
            "PrikazEtikete",
            typeof(RoutedCommands),
            new InputGestureCollection()
           {
                new KeyGesture(Key.E, ModifierKeys.Control),
                new KeyGesture(Key.E, ModifierKeys.Alt | ModifierKeys.Control)

           }
           );

        public static readonly RoutedUICommand PrikazSpomenika = new RoutedUICommand(
           "Prikaz Spomenika",
           "PrikazSpomenika",
           typeof(RoutedCommands),
           new InputGestureCollection()
          {
                new KeyGesture(Key.S, ModifierKeys.Control),
                new KeyGesture(Key.S, ModifierKeys.Alt | ModifierKeys.Control)

          }
          );

        public static readonly RoutedUICommand PrikazMape = new RoutedUICommand(
          "Prikaz Mape",
          "PrikazMape",
          typeof(RoutedCommands),
          new InputGestureCollection()
         {
                new KeyGesture(Key.M, ModifierKeys.Control),
                new KeyGesture(Key.M, ModifierKeys.Alt | ModifierKeys.Control)

         }
         );


/////////////////////////////////////////////////////TIP/////////////////////////////////////////////////////
        public static readonly RoutedUICommand DodavanjeTipa = new RoutedUICommand(
        "Dodavanje Tipa",
        "DodavanjeTipa",
        typeof(RoutedCommands),
        new InputGestureCollection()
       {
                new KeyGesture(Key.D, ModifierKeys.Control),
                new KeyGesture(Key.D, ModifierKeys.Alt | ModifierKeys.Control)

       }
       );

       public static readonly RoutedUICommand IzmeniTip = new RoutedUICommand(
      "Izmeni Tip",
      "IzmeniTip",
      typeof(RoutedCommands),
      new InputGestureCollection()
     {
                new KeyGesture(Key.I, ModifierKeys.Control),
                new KeyGesture(Key.I, ModifierKeys.Alt | ModifierKeys.Control)

     }
     );


    public static readonly RoutedUICommand ObrisiTip = new RoutedUICommand(
       "Obrisi Tip",
       "ObrisiTip",
       typeof(RoutedCommands),
       new InputGestureCollection()
      {
                new KeyGesture(Key.O, ModifierKeys.Control),
                new KeyGesture(Key.O, ModifierKeys.Alt | ModifierKeys.Control)

      }
      );

/////////////////////////////////////////////////ETIKETA/////////////////////////////////////////////////////////




    }
}
