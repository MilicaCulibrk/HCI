   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5          Projekat.TipForm   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Projekat     5        N� Title$  TipForm��5	      $��460.8��6   $��1024.618��6&   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��774 �6   �� 5      $	��251 �6   .+�5   
   � $��0��6   .+�5      � 
�������.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ Tejbl��5         
IsReadOnly .    AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6|   $��24,69,36,24q�6�   $��24(�6�   ��6*   ��  �� Path$ Tipovi�   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��61   	   CellTemplate	 5      �� 5   "   .R�5   &   �� 
 �� Orientation$
 
Horizontal=�61   .+�5   *   �� $��14(�6L   ��64   �� *Oznaka+6L   5   '   5   #   5      0  *System.Windows.Controls.DataGridTextColumn  5      $ Naziv��6-      FontSize$ 14Q�6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Ime+6d     5       $
 Opis��6-   $ 14Q�6T    6;   �� *Opis+6d     5"      $ Ikonica��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6B   	 5#      �� 5$   "   .R�5%   &   �� $
��None=�6G   ��6,   �� *	Ikonica+6G   5&   #   5(      5+      5,      5-      � 5/   
   $��1��6   .+�50      � -   5         �Name$ GridMenu��50      ���	#FFE8EBEC$
��10,0q�6<   .+�52      �� $
 
Horizontal=�6   $	��Top=�66   �� 53      -   5         ��Name$ Izmeni��53      $��Izmeni��6)   $��MV Boli)�6:   $��20(�6O   
�������$��0q�6p   ���	#FFD2EEE5���	#FF168AA4$��10,99,10,319q�6�   $��43��6�   6�   �� 54      -   5        $ Dodaj��54      $��Dodaj��6(   $��MV Boli)�68   $��20(�6M   
�������$��0q�6n   ���	#FFD2EEE5���	#FF168AA4$��14,36,10,384q�6�   �� 55      -   5        $ Obriši��55      $��Obriši��6)   $��MV Boli)�6:   $��20(�6O   
�������$��0q�6p   ���	#FFD2EEE5���	#FF168AA4$��10,168,14,252q�6�   56      57      �� 59   
   -   5         ��Name$	 Tip��59      $��Tabela Tipova��6   $
��Bold"�65   ���	#FF168AA4$��30(�6^   $
��Left=�6l   $��
280,10,0,0q�6�   $	��Top=�6�   $��47��6�   $	��262��6�   � 5;   
   .+�5<       � -   5          �Name$ TipFormFrame��5<        � NavigationUIVisibility$ Hidden=�6*   5=      5?      5@      