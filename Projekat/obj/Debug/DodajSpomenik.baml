   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      C ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat 5         Projekat.DodajSpomenik   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9System&clr-namespace:System;assembly=mscorlib     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Projekat     5        N� Title$  DodajSpomenik��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��70* �6   �� 5      $	��30* �6   .+�5   
   � $��0��6   .+�5      �� .+�5      �� $	��Id:��6   $��10 0 0 0q�6'   $
��Bold"�6;   �� 5      -   5         ��Name$ idTxT��5      $��2q�6*   $��
10,2,39,20q�66    �� TextWrapping$
 Wrap=�6J   ��6^   ��  �� Path$ Spomenik.Id� �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��Naziv:��6   $��	 10 0 0 0q�6*   $
��Bold"�6>   �� 5      -   5        $ nazivTxT��5      $��2q�6,   $��
10,2,39,20q�68   $
 Wrap=�6L   ��6`   �� $ Spomenik.Naziv� �� Mode$ OneWay=�$ PropertyChanged=��� 5      $��Opis:��6   $��	 10 2 0 0q�6)   $
��Bold"�6=   �� 5      -   5        $ opisTxt��5      $��2q�6+   $��
10,0,39,20q�67   $
 Wrap=�6K    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   "	 �� VerticalScrollBarVisibility$
	 Auto=�6�   ��6_   �� $ Spomenik.Opis�$ OneWay=�$ PropertyChanged=�6�   �� 5      
 �� Orientation$
 
Horizontal=�6   $��10 0 0 0q�66   .+�5      �� $
��Tip:��6   $��	10 0 10 0q�6,   $
��Bold"�6@   �� 5      -   5         ��Name$ 
tipoviCbox��5      $��	10 0 10 0q�64   $	��Top=�6G   $	��100��6_    �� 
IsEditable .  ��6~   �� $ Tipovi�$ PropertyChanged=���5       �� 5!      .R�5"   "   �� ��6,   �� *Ime+5#      5%      �� 5'      $��Ikonica:��6   $��0 0 10 0q�60   $
��Bold"�6B   �� 5(      $��1q�6   
��� � � �� CornerRadius$ 3��6E   $��0 0 8 0q�6V   $
��Left=�6g   $	��Top=�6�   $��25��6�   $��25��6�   ._�5)      �� -   5         ��Name$
 icon��5)       $��0,0,0,0q�6/   $	��Top=�6@   $��24��6X   $��24��6e   ��6q   �� $ Ikonica�$ OneWay=�$ PropertyChanged=�5*      �� 5+      -   5        $��Učitaj��5+      $
��Left=�6.   $��0 0 8 0q�6I   $��Bottom=�6Z   $��50��6u   6�   5-      �� 5/      $
 
Horizontal=�6   $��	10 15 0 0q�66   .+�50      �� $��Era porekla:��6   $��	10 15 0 0q�64   �� 51      -   5        $ eraPoreklaCbox��51      $��	10 15 0 0q�69   $	��100��6M    .  ��6l   �� $ 
eraPorekla�$ OneWay=�$ PropertyChanged=��� 53      $��Turistički status:��6   $��	10 15 0 0q�6:   �� 54      -   5        $ turistickiStatusCbox��54      $��	10 15 0 0q�6>   $	��100��6R    .  ��6q   �� $ turistickiSt�$ PropertyChanged=�55      �� 57      $
 
Horizontal=�6   $��	10 10 0 0q�66   .+�58      �� $��Arheološki obrađen:��6   $��0 0 10 0q�6<   �� 59      -	   5         ��Name$ arheoloskiObradjen��59      $��0 6 10 0q�6;    d� 	IsChecked 6N   �� $" Spomenik.Arheoloski_obradjen�$ OneWay=�$ PropertyChanged=��� 5:      $��Na listi UNESCO:��6   $��0 0 10 0q�68   �� 5;      -
   5        $ naListiUnesco��5;      $��0 6 10 0q�67    6I   �� $ Spomenik.Na_listi_UNESCO�$ OneWay=�$ PropertyChanged=��� 5<      $��U naseljenom regionu:��6   $��0 0 10 0q�6=   �� 5=      -   5        $ uNaseljenomRegionu��5=      $��0 6 10 0q�6;    6M   �� $# Spomenik.U_naseljenom_regionu�$ OneWay=�$ PropertyChanged=�5>      �� 5@      $
 
Horizontal=�6   $��	10 10 0 0q�66   .+�5A      �� $"��Godišnji prihod od turizma:��6   $��	10 2 10 0q�6B   �� 5B      -   5        $ 	prihodTxt��5B      $��2q�61   $��0 0 5 0q�6=   $	��200��6N    �� TextAlignment$ Right=�6[   $
 Wrap=�6q   ��6�   �� $ Spomenik.GPrihod�$ OneWay=�$ PropertyChanged=��� 5C      $	��USD��6    $��7 10 0 0q�6+   
��� � �6=   5D      �� 5F      $��Datum otkrivanja:��6   $��10 5 0 0q�64   (  "System.Windows.Controls.DatePicker  5G      -   5          Name$ 
datePicker��5G      $
��Left=�61   $��10 2 0 0q�6M   $	��300��6_      SelectedDate 6k   �� $ Spomenik.Datum�$ OneWay=�$ PropertyChanged=�
 �� Now �� TargetNullValue# Z 5H      5J      � 5M   
   $��1��6   .+�5N      �� .+�5O      �� $��Etikete:��6   $��	24,0,10,0q�6,   �� 5P      -   5         ��Name$ etiketeList��5P       �� SelectionMode$ Multiple=�6/   $	��Top=�6I   $��Visible=�6a   $	��308��6�   $��	24,0,10,0q�6�   ��6�   �� $ Etikete�$ PropertyChanged=���5Q      �� 5R      .R�5S      �  5T   "   �� 5U   &   �� 5V   &   �� 5W   &   .+�5Z   "   � $��	0 0 10 0 q�6'   $��0��6:   .+�5[   &   �� $	��100��60   ��6<   �� $
 Boja�6Y   5\   #   � 5^   "   $��0 0 0 0q�6'   $��1��68   .+�5_   &   �� ��60   �� *Oznaka+5`   #   5a      5b      5d      �� 5f      -   5         ��Name$ Dodaj��5f      $��DODAJ��6%   $��
80,70,20,0q�65   $
��Bold"�6I    J� RenderTransformOrigin$ 0.127,2.773&�6o   5h      5i      � 5l   
   .+�5m       � -   5          �Name$ Sp��5m        � NavigationUIVisibility$ Hidden=�6    $��
0,0,-243,0q�6@   5n      5q      5r      