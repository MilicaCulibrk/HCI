   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5      3clr-namespace:Projekat.KomandeProjekat.Komande  5          Projekat.Tabela   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Projekat     5      .cmdclr-namespace:Projekat.Komande     5        N� Title$  Tabela��5
      $	��630��6   $
��1300��6#    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   	   -   5           Command$&  cmd:RoutedCommands.DodavanjeTipa��5      6�     5   
   -   5        $" cmd:RoutedCommands.IzmeniTip��5      6�     5   
   -   5        $" cmd:RoutedCommands.ObrisiTip��5      6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��70* �6   �� 5      $	��30* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      �� 5      $��9* �6    .+�5      � $��0��6   ���	#FF168AA4$��50��68   $��Bottom=�6D    5!      �� 5"      $	��10* �6'   �� 5#      $	��20* �6'   �� 5$      $	��70* �6'   .+�5'      � $��0��6   .+�5(      �� $��Center=�6!   $��DemiBold"�6=   ���	#FFE8EBEC���	#FF168AA4$��6 0 0 0q�5)   F   $��24(�6W   
Filtriraj:6q   5*      � 5,      $��1��6   .+�5.      �� -   5         ��Name$ combo��5.      $��Center=�6.   $��44��6r   $��2��6~   $��24(�6�    �� SelectedIndex 6I   �� *OpcijaPretrage+.@�5/      �� $��24(�6'   .��65   	Sva polja6@   �� 50      .��6'   Oznaka6/   �� 51      .��6'   Naziv6.   52      53      � 55      $��2��6   .+�56      �� -   5         ��Name$ poljePretrage��56      $��Center=�65   $��44��6P   $��	10,3,96,3q�6\   $��24(�6�   6�   �� 57      -   5         ��Name$ clearFilter��57      	 � Cursor$
	 Hand��62   $��Ponisti��6@   $��0��6m   $��	546,5,0,0q�6{   $
��Left=�6�   $��91��6�   $��42��6�   $	��Top=�6�   $��22(�6�   $
��Bold"�6�   59      5:      � 5<      $��1��6   .+�5=      � 
�������6   &   System.Windows.Controls.DataGrid  5>      -   5        
  Name$
 Tejbl��5>         
IsReadOnly .    AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6|   $��30,63,36,172q�6�   $��24(�6�   ��6*   ��  �� Path$ Tipovi�   Columns 5?      4  .System.Windows.Controls.DataGridTemplateColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��61      CellTemplate 5A      �� 5B   "   .R�5C   &   ��  �� Orientation$ 
Horizontal=�61   .+�5D   *   �� $��14(�6L   ��64   �� *Oznaka+6L   5E   '   5F   #   5H      0  *System.Windows.Controls.DataGridTextColumn  5I      $ Naziv��6-      FontSize$ 14Q�6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Ime+6d     5J      $
 Opis��6-   $ 14Q�6T    6;   �� *Opis+6d     5L      $ Ikonica��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6B    5M      �� 5N   "   .R�5O   &   �� $
��None=�6G   ��6,   �� *	Ikonica+6G   5P   #   5R      5U      �� 5V      -   5         ��Name$	 Tip��5V      $��Tabela Tipova��6%   $
��Bold"�6=   ���	#FF168AA4$��35(�6f   $
��Left=�6t   $��	321,0,0,0q�6�   $	��Top=�6�   $	��329��6�   $��MV Boli)�6�   $��58��6�   �� 5W      -	   5        $ Obriši��5W      $
	 Hand��6)   $��Obrisi��67    � ToolTip$ Ctrl + O��6H   $"��cmd:RoutedCommands.ObrisiTip��6[   ���	#FF168AA4$
��Bold"�6�   $��734,430,36,64q�6�   $��32(�6�   $��MV Boli)�6�   �� 5X      -
   5        $ Izmeni��5X      $
	 Hand��6)   $��Izmeni��67   $ Ctrl + I��6H   $"��cmd:RoutedCommands.IzmeniTip��6[   ���	#FF168AA4$
��Bold"�6�   $��566,430,200,64q�6�   $��32(�6�   $��MV Boli)�6�   �� 5Y      -   5        $ Dodajj��5Y      $
	 Hand��6)   $��_Dodaj��67   $ Ctrl + D��6I   $&�� cmd:RoutedCommands.DodavanjeTipa��6\   ���	#FF168AA4$
��Bold"�6�   $��414,430,362,64q�6�   $��32(�6�   $��MV Boli)�6�   5Z      5[      � 5^   
   $��1��6   ���	#FF168AA4$��0,13,0,0q�66   .+�5_      � -   5         �Name$ GridMenu��5_      $��	5,5,20,40q�6&   ���	#FFE8EBEC.+�5`      �� $ 
Horizontal=�6   $	��Top=�66   9� 5a       9� ExpandDirection$
 Down=�6    9� 
IsExpanded .  $��Pretraga��6E   $	��Top=�6W   $��MV Boli)�6o   $��36(�6�   $	��560��6�   $��0,10,0,0q�6�   ���	#FF168AA4.��5b      � .+�5c      �� $��Oznaka:��6    $��Right=�62   $��57��6N   $	��Top=�6Z   $��94��6r   $��0,154,269,0q�6}   $��24(�6�   $��Segoe UI)�6�   �� 5d      $��Naziv:��6    $
��Left=�61   $��77��6L   $	��Top=�6X   $��94��6p   $��	0,231,0,0q�6{   $��Segoe UI)�6�   $��24(�6�   �� 5e      -   5        $ oznaka��5e   "   
���   �$
��Left=�6F   $��60��6a   $��112,0,0,302q�6m    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $��Bottom=�6�   $	��241��6�   $��28(�6�   $��Segoe UI)�6�   �� 5f      -   5        $ naziv��5f   "   
���   �$
��Left=�6F   $��60��6a   $��112,216,0,0q�6m   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��241��6�   $��28(�6�   $��Segoe UI)�6�   �� 5h      -   5        $
 Pret��5h   !   $
	 Hand��6/   $��Pretrazi��6=   $ Ctrl + P��6P   ���	#FF168AA4$
��Bold"�6{   $��24,42,204,386q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��30(�6�   $��MV Boli)�6�   �� 5j      -   5        $ Ponisti��5j   !   $
	 Hand��63   $ 	Ctrl + PO��6A   ���	#FF168AA4$��Ponisti��6l   $
��Bold"�6~   $��196,42,28,386q�6�   $ 0.5,0.5&�6�   $��30(�6�   $��MV Boli)�6�   5l      5m      5n      5o      � 5r   
   .+�5s       � -   5          �Name$ FrejmIzmeni��5s        � NavigationUIVisibility$ Hidden=�6)   $��
0,0,-387,0q�6I   5t      5u      5v      