   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5   	   3clr-namespace:Projekat.KomandeProjekat.Komande  5   	       Projekat.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Projekat     5   	   .cmdclr-namespace:Projekat.Komande     5   	   -   5          � Icon$-  'pack://siteoforigin:,,,/Images/icon.png��5	   	    � Title$4 .Evidencija o mapi svetskih kulturnih spomenika��5
   	   $	��700��6A   $
��1300��6N    � WindowStartupLocation$ CenterScreen=�6[    � 
ResizeMode$ NoResize=�6�    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   	   -   5           Command$&  cmd:RoutedCommands.PrikazPocetne��5      6�     5   
   -   5        $# cmd:RoutedCommands.PrikazTipa��5      6�     5   
   -   5        $&  cmd:RoutedCommands.PrikazEtikete��5      6�     5   
   -   5        $( "cmd:RoutedCommands.PrikazSpomenika��5      6�     5   
   -   5        $# cmd:RoutedCommands.PrikazMape��5      6�   .��5      �  � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5       $	��20* �6#   �� 5!      $	��20* �6#   �� 5"      $	��20* �6#   �� 5#      $	��20* �6#   �� 5$      $	��20* �6#   .+�5'      � $��0��6   .+�5(      �� -   5         ��Name$ PočetnaStranica��5(      	 � ToolTip$	 Ctrl + P��62   $&�� cmd:RoutedCommands.PrikazPocetne��6F   ���	#FFE8EBEC$��22(�6�   $
��Bold"�6�   $��POCETNA STRANICA��6�   
 � Cursor$

 Hand��6�   $��0q�6�   ���	#FFE8EBEC$��MV Boli)�6�   ���	#FF168AA46*  5)      � 5*      $��3��6   .+�5+      �� -   5        $ 	Spomenici��5+      $	 Ctrl + S��6,   $(��"cmd:RoutedCommands.PrikazSpomenika��6@   ���	#FFE8EBEC$��22(�6�   $
��Bold"�6�   $��	SPOMENICI��6�   $

 Hand��6�   $��0q�6�   ���	#FFE8EBEC$��MV Boli)�6�   ���	#FF168AA46   5,      � 5-      $��2��6   .+�5.      �� -	   5        $ Etikete��5.      $	 Ctrl + E��6+   $&�� cmd:RoutedCommands.PrikazEtikete��6?   ���	#FFE8EBEC$��22(�6�   $
��Bold"�6�   $��ETIKETE��6�   $

 Hand��6�   $��0q�6�   ���	#FFE8EBEC$��MV Boli)�6�   ���	#FF168AA46  5/      � 50      $��1��6   .+�51      �� -
   5        $ Tipovi��51      $#��cmd:RoutedCommands.PrikazTipa��6*   $	 Ctrl + T��6T   ���	#FFE8EBEC$��22(�6~   $
��Bold"�6�   $��TIPOVI��6�   $

 Hand��6�   $��0q�6�   ���	#FFE8EBEC$��MV Boli)�6�   ���	#FF168AA46  52      � 53      $��4��6   .+�54      �� -   5        $ 	MapaSveta��54      $	 Ctrl + M��6-   $#��cmd:RoutedCommands.PrikazMape��6A   ���	#FFE8EBEC$��22(�6�   $
��Bold"�6�   $
��MAPA��6�   $

 Hand��6�   $��0q�6�   ���	#FFE8EBEC$��MV Boli)�6�   ���	#FF168AA46  56      57      � 59   
   $��1��6   .+�5:       � -   5          �Name$
 Main��5:        � NavigationUIVisibility$ Hidden=�6"   5;      5=      5>      