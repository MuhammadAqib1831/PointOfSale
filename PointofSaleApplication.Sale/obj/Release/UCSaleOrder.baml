   M S B A M L   `   `   `  ����   PointofSaleApplication.Sale-    'PointofSaleApplication.Sale.UCSaleOrder   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $	��400��$	��800��.��� $��0,0,0,10q�  � RowDefinitions  �� $��70 ��� $��* ��� $��40 �.+��� ����  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF007ACC�� � Offset$ 1Q�� $ White���� .+��� -    ��Name$ comboProduct��
 �� Top$ 35�� �� Left$ 34��$	��180��	 �� SelectedValuePath$	 Id��
 �� DisplayMemberPath$

 Name���� -    ��Name$ txtQuantity��$ 35��$	 255��$��1��$��80���� -   $ txtSalePrice��$ 35��$	 371��$��TextBox��$��83���� -    ��Name$ Product��$��Product��$ 5��$ 26��$
��Bold"��� -   $ lblQuantity��$��Quantity��$ 5��$��80��$
��Bold"�$	 255���� $��
Sale Price��$ 5��$	 367��$��83��$
��Bold"��� -    ��Name$	 btn��$	��Add��$ 35��$	 498��$��75��&   System.Windows.Controls.DataGrid  -   $��dgSale��   AutoGenerateColumns .  $��1��$��Stretch=�$��Stretch=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Item��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ItemName+  $ Quantity��$	 150  �� *
Quantity+  $ 
Unit Price��$	 150  �� *	UnitPrice+  $ Amount��$	 150  �� *
GrossTotal+4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate �� .R��� $ btn_row��$��Delete��
���  ��$��70��$��Delete���� $��2��.+��� -   $ btnSaveOrder��$
��Save��$ 10��$	 597��$��75��