   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5          Projekat.Tabela   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Projekat     5        N� Title$  Tabela��5	      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Tejbl��5         
IsReadOnly .    AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6t   $��22,63,66,10q�6�   ��6"   ��  �� Path$ Tipovi�   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6)      CellTemplate 5      �� 5      .R�5   "   �� 	 �� Orientation$	 
Horizontal=�6-   .+�5   &   �� ��60   �� *Oznaka+5   #   5      5      0  *System.Windows.Controls.DataGridTextColumn  5      $ Naziv��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *Ime+6N     5      $
 Opis��6%   
 63   �� *Opis+6N     5      $ Ikonica��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6:    5      �� 5      .R�5      �� $
��None=�6?   ��6$   �� *	Ikonica+6?   5      5!      5$      �� 5;   
   -   5         ��Name$	 Tip��5;      $��Tabela tipova��6   $
��Bold"�65   ���	#FF168AA4$��30(�6^   $
��Left=�6l   $��
274,10,0,0q�6�   $	��Top=�6�   $��48��6�   $	��254��6�   � 5?   
   .+�5@       � -   5          �Name$ FrejmIzmeni��5@        � NavigationUIVisibility$ Hidden=�6)   5A      5B      5C      