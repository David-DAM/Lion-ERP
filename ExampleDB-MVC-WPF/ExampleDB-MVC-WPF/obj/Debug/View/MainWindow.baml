   M S B A M L   `   `   `  ����L  HExampleDB-MVC-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ExampleDB_MVC_WPFExampleDB_MVC_WPF  5   	   "    ExampleDB_MVC_WPF.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   +localclr-namespace:ExampleDB_MVC_WPF  5   	     � Title$  Login��5	   	   $	��400��6   $	��500��6$   $	��500��5
   	   $	��400��6   $	��500��6(   $	��400��67    � 
ResizeMode$ CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ lblLittlerp��5      $��0��6%   $��LION-ERP��62   $
��Left=�6E   $��52��6`   $��
176,24,0,0q�6l   $	��Top=�6�   $	��185��6�   $��36(�6�   $
��Bold"�6�   $��Times New Roman)�6�   �� 5   
   -   5        $ lblLogin��5      $��1��6"   $��Login:��6/   $��Right=�6@   $
��Left=�6c   $��42��6~   $��	81,10,0,0q�6�   $	��Top=�6�   $	��113��6�   $��20(�6�   $��Arial)�6�   �� 5   
   -   5        $ lblPassword��5      $��1��6%   $��	Password:��62   $��Right=�6F   $
��Left=�6i   $��37��6�   $��	76,57,0,0q�6�   $	��Top=�6�   $	��118��6�   $��20(�6�   $��Arial)�6�   �� 5   
   -   5         ��Name$ txtLogin��5      $��1��6$   $
��Left=�61   $��35��6L   $��
207,10,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��169��6�   $��18(�6�    J� RenderTransformOrigin$ 0.603,0.449&�6�   �� 5   
   -   5        	 ��Name$	 btnOK��5      $��2��6    $��OK��6-   $
��Left=�6:   $��50��6U   $��
269,28,0,0q�6a   $	��Top=�6u   $��92��6�   $��18(�6�   $
��Bold"�6�    '  #MahApps.Styles.Button.Square.Accent#��[  6�   �� 5   
   -   5        $	 btnOK_Copy1��5      $��2��6&   $��CLOSE��63   $
��Left=�6C   $��50��6^   $��
153,28,0,0q�6j   $	��Top=�6~   $��92��6�   $��18(�6�   $
��Bold"�6�   
���  ��#��[  6�   G� 5   
   -   5        
 G�Name$
 pwdPassword��5      $��18(�6+   $��1��69   $
��Left=�6F   $��
207,57,0,0q�6a   $	��Top=�6u   $	��169��6�   $ 0.492,0.426&�6�   $��37��6�   5      5       