   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      C ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat 5         Projekat.IzmenaSpomenika   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9System&clr-namespace:System;assembly=mscorlib     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Projekat     5        N� Title$  IzmenaSpomenika��5
       N� 
Background
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      $	��70* �6   �� 5      $	��30* �6   .+�5   
   � $��0��6   .+�5      �� .+�5      �� $	��Id:��6   $��10 0 0 0q�6'   $
��Bold"�6;   �� 5      -   5         ��Name$ idTxT��5      $��2q�6*   $��
10,2,39,20q�66    �� TextWrapping$
 Wrap=�6J   ��6^   ��  �� Path$ Id� �� UpdateSourceTrigger$ Explicit=��� 5      $��Naziv:��6   $��	 10 0 0 0q�6*   $
��Bold"�6>   �� 5      -   5        $ nazivTxT��5      $��2q�6,   $��
10,2,39,20q�68   $
 Wrap=�6L   ��6`   �� $ Naziv�$ Explicit=��� 5      $��Opis:��6   $��	 10 2 0 0q�6)   $
��Bold"�6=   �� 5      -   5        $ opisTxt��5      $��2q�6+   $��
10,0,39,20q�67   $
 Wrap=�6K    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   "	 �� VerticalScrollBarVisibility$
	 Auto=�6�   ��6_   �� $
 Opis�$ Explicit=�6�   �� 5      
 �� Orientation$
 
Horizontal=�6   $��10 0 0 0q�66   .+�5       �� $
��Tip:��6   $��	10 0 10 0q�6,   $
��Bold"�6@   �� 5!      -   5         ��Name$ 
tipoviCbox��5!      $��	10 0 10 0q�64   $	��Top=�6G   $	��100��6_    �� 
IsEditable .  ��6~   �� $ DodajSpomenik.Tipovi�$ Explicit=���5"      �� 5#      .R�5$   "   �� ��6,   �� *Ime+5%      5'      �� 5*      $��Ikonica:��6   $��0 0 10 0q�60   $
��Bold"�6B   �� 5+      $��1q�6   
��� � � �� CornerRadius$ 3��6E   $��0 0 8 0q�6V   $
��Left=�6g   $	��Top=�6�   $��25��6�   $��25��6�   ._�5,      �� -   5         ��Name$ iconica��5,       $��0,0,0,0q�62   $	��Top=�6C   $��24��6[   $��24��6h   ��6s   �� $ Ikonica� �� Mode$ TwoWay=�$ Explicit=�5-      �� 5.      -   5        $��Učitaj��5.      $
��Left=�6.   $��0 0 8 0q�6I   $��Bottom=�6Z   $��50��6u   6�   50      �� 52      $
 
Horizontal=�6   $��	10 15 0 0q�66   .+�53      �� $��Era porekla:��6   $��	10 15 0 0q�64   �� 55      -   5        $ eraPoreklaCbox��55      $
��Left=�6y   $��	10,15,0,0q�6�   $	��Top=�6�   $	��100��6�    �� Text 68   �� *
EraPorekla+$ PropertyChanged=�.@�56      �� .��6&   
Paleolit60   �� 57      .��6'   Neolit6/   �� 58      .��6'   	Stari vek62   �� 59      .��6'   Srednji vek64   �� 5:      .��6'   	Renesansa62   �� 5;      .��6'   Moderno doba65   5<      �� 5@      $��Turistički status:��6   $��	10 15 0 0q�6:   �� 5B      -   5        $��turistickiStatusCbox��5B      $
��Left=�6|   $	��100��6�   $��	10 15 0 0q�6�   $	��Top=�6�    6;   �� $ turistickiSt�$ Explicit=�.@�5C      �� $��Eksploatisan��6'   �� 5D      $��Dostupan��6'   �� 5E      $��
Nedostupan��6'   5F      5H      �� 5J      $
 
Horizontal=�6   $��	10 10 0 0q�66   .+�5K      �� $��Arheološki obrađen:��6   $��0 0 10 0q�6<   �� 5L      -	   5         ��Name$ arheoloskiObradjen��5L      $��0 6 10 0q�6;    d� 	IsChecked 6N   �� $ Arheoloski_obradjen�$ Explicit=��� 5M      $��Na listi UNESCO:��6   $��0 0 10 0q�68   �� 5N      -
   5        $ naListiUnesco��5N      $��0 6 10 0q�67    6I   �� $ Na_listi_UNESCO�$ Explicit=��� 5O      $��U naseljenom regionu:��6   $��0 0 10 0q�6=   �� 5P      -   5        $ uNaseljenomRegionu��5P      $��0 6 10 0q�6;    6M   �� $ U_naseljenom_regionu�$ Explicit=�5Q      �� 5S      $
 
Horizontal=�6   $��	10 10 0 0q�66   .+�5T      �� $"��Godišnji prihod od turizma:��6   $��	10 2 10 0q�6B   �� 5U      -   5        $ 	prihodTxt��5U      $��2q�61   $��0 0 5 0q�6=   $	��200��6N    �� TextAlignment$ Right=�6[   $
 Wrap=�6q   ��6�   �� $ GPrihod�$ Explicit=��� 5V      $	��USD��6    $��7 10 0 0q�6+   
��� � �6=   5W      �� 5Y      $��Datum otkrivanja:��6   $��10 5 0 0q�64   (  "System.Windows.Controls.DatePicker  5Z      -   5          Name$ 
datePicker��5Z         SelectedDate 61   �� *Datum+$ Explicit=�   Text 6n   �� *Datum+$ Explicit=�5[      5]      � 5`   
   $��1��6   .+�5a      �� .+�5b      �� $��Etikete:��6   $��	24,0,10,0q�6,   �� 5c      -   5         ��Name$ etiketeList��5c       �� SelectionMode$ Multiple=�6/   $	��Top=�6I   $��Visible=�6a   $	��308��6�   $��	24,0,10,0q�6�   ��6�   �� $ DodajSpomenik.Etikete�$ Explicit=���5d      �� 5e      .R�5f      �  5g   "   �� 5h   &   �� 5i   &   �� 5j   &   .+�5m   "   � $��	0 0 10 0 q�6'   $��0��6:   .+�5n   &   �� $	��100��60   ��6<   �� $
 Boja�6Y   5o   #   � 5q   "   $��0 0 0 0q�6'   $��1��68   .+�5r   &   �� ��60   �� *Oznaka+5s   #   5t      5u      5w      �� 5x      -   5         ��Name$ Izmeni��5x      $��IZMENI��6)   $��
80,70,20,0q�6:   $
��Bold"�6N    J� RenderTransformOrigin$ 0.127,2.773&�6`   6�   5z      5{      � 5~   
   .+�5       � -   5          �Name$ Sp��5        � NavigationUIVisibility$ Hidden=�6    $��
0,0,-243,0q�6@   5�      5�      5�      