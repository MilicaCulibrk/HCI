   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5          Projekat.Mapa   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Projekat     5        N� Title$
  Mapa��5	      $	��630��6   $
��1300��6"   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��75* �6   �� 5      $	��25* �6   .+�5   
   � $��0��6   
�������.+�5      �� -   5        $��
canvasMapa��5       J� 	AllowDrop . ��5      �� 5      -   5        mapaImg�� j� Stretch$
 Fill=�5   2   5       � 5      -   5          �Name$
 Mapp��5        � NavigationUIVisibility$ Hidden=�6"   5      � 5    
   $��1��6   ���	#FF168AA4.+�5"      R� -   5         R�Name$ TipoviSp��5"      $	��589��5$   5   $��10,10,23,43q�6B   ��5"   -   ��  �� Path$ 
TipoviTree� �� Mode$ TwoWay=�	 � 	Resources	 5%      
 �� DataType   Projekat.Tip �� ItemsSource �� Orientation   Projekat.Spomenik � Cursor��%�  (��       5&   3   *, +)(��     52   '   *, +)�� 5&      "
  63    6Q   �� *SpomeniciUtipu+.R�5)      �� $ 
Horizontal=�6)   .+�5*   "   �� $��0,0,5,0q�6(   $��40��6V   $��40��6a   ��6:   �� *	Ikonica+5,   #   �� 5.   "   $��30(�6A   $
��Bold"�6O   ��6,   �� *Ime+6O   50      51      �� 52      "
  6'   .R�53      �� $ 
Horizontal=�6)   $
 Hand��6B   .+�54   "   �� $��30��6)   $��30��64   ��6@   �� *	Ikonica+�� 55   "   $��24(�6@   ��6,   �� *Id+6@   �� 56   "   $�� (��6,   $��24(�66   �� 57   "   $��24(�6C   ��6,   �� *Naziv+6C   �� 58   "   $��)��6,   $��24(�65   59      5:      5<      5=      5?      � 5A   
   $��0��6   .+�5B       � -   5        $	 Map��5B      $ Hidden=�6!   $��
0,0,-699,0q�6A   5C      5D      5E      