   M S B A M L   `   `   `  ����L  HExampleDB-MVC-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExampleDB_MVC_WPF.ViewExampleDB_MVC_WPF.View  5   	   (    "ExampleDB_MVC_WPF.View.ControlUser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   0local$clr-namespace:ExampleDB_MVC_WPF.View  5   	     � Title$  User manage��5	   	   $	��720��6   $
��1280��6*   $
��1280��5
   	   $	��720��6   $
��1280��6)   $	��720��69    � 
ResizeMode$ CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $
��0.5* �6   .+�5   
   �� -   5         ��Name$ lblName��5      $��16(�6!   $��0��6/   $��Name:��6<   $��Right=�6L   $
��Left=�6o   $��
498,58,0,0q�6�   $	��Top=�6�   $��42��6�   $��73��6�   �� 5   
   -   5        $ lblPassword��5      $��16(�6%   $��0��63   $��	Password:��6@   $��Right=�6T   $
��Left=�6w   $��470,123,0,0q�6�   $	��Top=�6�   $��42��6�   $	��101��6�   �� 5   
   -   5         ��Name$ txtName��5      $��16(�6#   $��0��61   $
��Left=�6>   $��41��6Y   $��
588,58,0,0q�6e    �� TextWrapping$
 Wrap=�6y   $	��Top=�6�   $	��149��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvAssigned��5      $��16(�6(   $��1��66   $
��Left=�6C   $	��277��6^   $��
347,45,0,0q�6k   $	��Top=�6   $	��213��6�   	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        dgtcAssigned��,  &System.Windows.Controls.DataGridColumn   Header$!         ASSIGNED ROLES     ��5   [   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *description+6[   5      �� 5   
   -   5         ��Name$ 	btnCancel��5      $��2��6$   $��16(�61   $��CANCEL��6?   $
��Left=�6P   $��
514,10,0,0q�6k   $	��Top=�6   $��94��6�    '  #MahApps.Styles.Button.Square.Accent#��[  6�   $��45��6�   
���  ��6  �� 5   
   -   5        $ btnOk��5      $��2��6    $��16(�6-   $��OK��6;   $
��Left=�6H   $��
657,10,0,0q�6c   $	��Top=�6w   $��95��6�   #��[  6�   $��45��6�     5    
   -   5        $ 
dgvAllowed��5       $��16(�6'   $��1��65   $
��Left=�6B   $	��277��6]   $��
657,45,0,0q�6j   $	��Top=�6~   $	��210��6�   	 .  
 .  5!        5"      -	   5        dgtcAllowed��$!          AllOWED ROLES     ��5"   Z    6:   �� *description+6Z   5$      �� 5%   
   -
   5        $ btnLeft��5%      $��1��6"   $��<-��6/   $
��Left=�6?   $��
581,99,0,0q�6Z   $	��Top=�6n   $��48��6�   $��18(�6�   #��[  6�   �� 5&   
   -   5        $ btnRight��5&      $��1��6#   $��->��60   $
��Left=�6@   $��581,153,0,0q�6[   $	��Top=�6p   $��48��6�   $��18(�6�   #��[  6�   �� 5'   
   -   5        $ btnSend��5'      $��0��6"   $��16(�6/   $��
SEND EMAIL��6=   $
��Left=�6R   $��588,123,0,0q�6m   $	��Top=�6�   $	��151��6�   #��[  6�   $��45��6�   5)      5*      