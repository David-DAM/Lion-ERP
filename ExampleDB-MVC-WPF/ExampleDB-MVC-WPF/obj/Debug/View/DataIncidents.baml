   M S B A M L   `   `   `  ����L  HExampleDB-MVC-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExampleDB_MVC_WPF.ViewExampleDB_MVC_WPF.View  5   	   *    $ExampleDB_MVC_WPF.View.DataIncidents   5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ExampleDB_MVC_WPF.View     5   	     � Title$  DataIncidents��5   	   $	��720��6   $
��1280��6,   $
��1280��5	   	   $	��720��6   $
��1280��6)   $	��720��69    � 
ResizeMode$ CanMinimize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��4* �6   �� 5      $��* �6   .+�5   
   �� -   5        $%��lblOrdersBusinessResponsability��5      $��16(�67   $(��"INCIDENTS OF THE COMPANY IN ORDERS��6E   $��0��6r   $��0��6   $��Center=�6�   $��Center=�6�   �� 5   
   -   5         ��Name$" txbCountOrdersResponsability��5      $��16(�68   $��1��6F   $��0��6S   $��44,15,44,11q�6c   $��Center=�6x   $��Center=�6�   {�.  6�   �� 5   
   -   5        $��lblProductsIncidents��5      $��16(�6,   $��PRODUCTS INCIDENTS��6:   $��2��6W   $��0��6d   $��Center=�6t   $��Center=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvProductsIncidents��5      $��16(�61   $��0��6?   $��3��6O   $
��Left=�6\   $��72,0,0,0q�6w   $	��Top=�6�      AutoGenerateColumns .     
IsReadOnly . $	��341��6�   $	��294��6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5       -   5        dgtcCountProduct��,  &System.Windows.Controls.DataGridColumn
   Header$
 COUNT��5    V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *id+6V     5!      -   5        dgtcNameProduct��$

 Name��5!   W    6>   �� *name+6W   5#      �� 5%   
   -   5        $%��lblOrdersCustomerResponsability��5%      $��16(�67   $)��#INCIDENTS OF THE CUSTOMER IN ORDERS��6E   $��0��6s   $��2��6�   $��Center=�6�   $��Center=�6�   �� 5&   
   -   5        $* $txbCountOrdersCustomerResponsability��5&      $��16(�6@   $��1��6N   $��2��6[   $��44,15,44,11q�6k   $��Center=�6�   $��Center=�6�   {�.  6�   �� 5(   
   -	   5        $��lblMoneyResponsability��5(      $��16(�6.   $��MONEY SPENT ON INCIDENTS��6<   $��0��6_   $��1��6l   $��Center=�6|   $��Center=�6�   �� 5)   
   -
   5        $ txbMoneyResponsability��5)      $��16(�62   $��1��6@   $��1��6M   $��44,15,44,11q�6]   $��Center=�6r   $��Center=�6�   {�.  6�   �� 5+   
   -   5        $��lblProductsReturnes��5+      $��16(�6+   $��MOST RETURNED PRODUCTS��69   $��2��6Z   $��1��6g   $��Center=�6w   $��Center=�6�     5,   
   -   5        $ dgvProductsReturned��5,      $��16(�60   $��1��6>   $��3��6N   $
��Left=�6[   $��52,0,0,0q�6v   $	��Top=�6�    .   . $	��341��6�   $	��334��6�   	 5-        5.      -   5        dgtcCountProductReturned��$
 COUNT��5.   ^    6G   �� *id+6^     5/      -   5        dgtcNameProductReturned��$

 Name��5/   _    6F   �� *name+6_   51      �� 53   
   -   5        $��lblProductsDefectives��53      $��16(�6-   $��MOST DEFECTIVES PRODUCTS��6;   $��2��6^   $��2��6k   $��Center=�6{   $��Center=�6�     54   
   -   5        $ dgvProductsDefectives��54      $��16(�62   $��2��6@   $��3��6P   $
��Left=�6]   $��63,0,0,0q�6x   $	��Top=�6�    .   . $	��346��6�   $	��308��6�   	 55        56      -   5        dgtcCountProductDefectives��$
 COUNT��56   `    6I   �� *id+6`     57      -   5        dgtcNameProductDefectives��$

 Name��57   a    6H   �� *name+6a   59      �� 5;   
   -   5         ��Name$ 	btnCancel��5;      $��16(�6$   $��4��62   $��1��6?   $��Cancel��6O   $
��Left=�6`   $��
145,22,0,0q�6{   $	��Top=�6�   $��87��6�    '  #MahApps.Styles.Button.Square.Accent#��[  6�   
���  ��6   5=      5>      