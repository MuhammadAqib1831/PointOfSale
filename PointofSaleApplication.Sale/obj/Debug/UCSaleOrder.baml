   M S B A M L   `   `   `  ����  PointofSaleApplication.Sale-    'PointofSaleApplication.Sale.UCSaleOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��400��5      $	��800��6   .��5      � $��0,0,0,10q�6     � RowDefinitions  5	   
   �� 5
      $��70 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   �� ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      �  � Color$ 	#FF007ACC��6#    � Offset$ 1Q�65   � 5      $ White��6#   5      5      �� 5   
   .+�5      �� -   5         ��Name$ comboProduct��5      
 �� Top$ 35��6.    �� Left$ 34��6>   $	��180��6O   	 �� SelectedValuePath$	 Id��6[   
 �� DisplayMemberPath$

 Name��6r   6�   �� 5      -   5         ��Name$ txtQuantity��5      $ 35��6+   $	 255��6;   $��1��6N   $��80��6X   �� 5      -   5        $ txtSalePrice��5      $ 35��6,   $	 371��6<   $��TextBox��6O   $��83��6_   �� 5      -   5         ��Name$ Product��5      $��Product��6%   $ 5��67   $ 26��6F   $
��Bold"�6X   �� 5      -   5        $ lblQuantity��5      $��Quantity��6)   $ 5��6<   $��80��6K   $
��Bold"�6V   $	 255��6h   �� 5      $��
Sale Price��6   $ 5��6)   $	 367��68   $��83��6K   $
��Bold"�6V   �� 5      -   5         ��Name$	 btn��5      $	��Add��6"   $ 35��60   $	 498��6@   $��75��6S   6^   5      &   System.Windows.Controls.DataGrid  5    
   -   5        $��dgSale��5          AutoGenerateColumns .  $��1��6>   $��Stretch=�6L   $��Stretch=�6j      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$
 Item��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *
ItemName+6P     5#      $ Quantity��6%   $	 150 6T    67   �� *
Quantity+6T     5$      $ 
Unit Price��6%   $	 150 6W    69   �� *	UnitPrice+6W     5%      $ Amount��6%   $	 150 6T    65   �� *
GrossTotal+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5&         CellTemplate 5'      �� 5(      .R�5)      �� $ btn_row��6%   $��Delete��66   
���  ��$��70��6X   $��Delete��6c   5*      5,      5.      �� 5/   
   $��2��6   .+�50      �� -   5        $ btnSaveOrder��50      $
��Save��6+   $ 10��6:   $	 597��6J   $��75��6]   6h   51      52      53      