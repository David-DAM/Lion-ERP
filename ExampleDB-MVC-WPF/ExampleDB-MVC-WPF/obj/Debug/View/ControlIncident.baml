   M S B A M L   `   `   `  ����L  HExampleDB-MVC-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExampleDB_MVC_WPF.ViewExampleDB_MVC_WPF.View  5   	   ,    &ExampleDB_MVC_WPF.View.ControlIncident   5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ExampleDB_MVC_WPF.View     5   	     � Title$  ControlIncident��5   	   $	��720��6!   $
��1280��6.   $
��1280��5	   	   $	��720��6   $
��1280��6)   $	��720��69    � 
ResizeMode$ CanMinimize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��4* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��
lblProduct��5      $��16(�6"   $��PRODUCT��60   $��0��6B   $��0��6O   $��Right=�6_   $��Center=�6�   $��489,34,10,11q�6�   $��42��6�   �� 5   
   -   5        $��lblDescription��5      $��16(�6&   $��INCIDENT DESCRIPTION��64   $��1��6S   $��0��6`   $��Right=�6p   $��Center=�6�   $��208,26,10,27q�6�   $��33��6�   �� 5   
   -   5        $��lblResponsability��5      $��16(�6)   $%��CUSTOMER PAYMENT RESPONSABILITY��67   $��2��6a   $��0��6n   $��Right=�6~   $��Center=�6�   $��131,20,10,27q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��39��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.006Q�6&   T� 5       5!      5#      �� 5$   
   -   5        $��lblOrder��5$      $��16(�6    $��ORDER PRODUCTS��6.   $��3��6G   $��2��6T   $��Center=�6h   $��Center=�6�   $	��Top=�6�   $��537,15,535,0q�6�   $	��202��6�   $��48��6�   �� 5%   
   -   5         ��Name$ 
txbProduct��5%      $��16(�6&   $��0��64   $��1��6A   $��10,34,310,21q�6Q   {�.  6g   �� 5&   
   -   5        $ txbDescription��5&      $��16(�6*   $��1��68   $��1��6E   $��10,26,310,27q�6U   {�.  6k   �� 5'   
   -   5        $ txbResponsability��5'      $��2��6-   $��1��6:   $��10,22,310,29q�6J   {�.  
���  ��6r   &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ dgvProductsOrder��5)      $��3��6-   $��16(�6:   	   AutoGenerateColumns	 .  
   
IsReadOnly
 . $��300,68,300,0q�6v   $��2��6�      Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+6<     5,      -	   5        dgtcName��$ Description��5,   P    67   �� *name+6P     5-      -
   5        	dgtcPrice��$ Price��5-   V    68   �� *	priceSale+6V     5.      -   5        
dgtcAmount��$ Amount��5.   X    69   �� *
amountSale+6X   50      �� 52   
   -   5         ��Name$ btnFix��52      $��4��6!   $��16(�6.   $��1��6=   $��send product��6N   $
��Left=�6e   $��	10,10,0,0q�6�   $	��Top=�6�   $	��137��6�    '  #MahApps.Styles.Button.Square.Accent#��[  6�   $��43��6	  �� 53   
   -   5        $ 	btnCancel��53      $��4��6$   $��16(�61   $��0��6?   $��Cancel��6O   $
��Left=�6`   $��
528,10,0,0q�6{   $	��Top=�6�   $��99��6�   #��[  6�   
���  ��$��43��6  54      55      