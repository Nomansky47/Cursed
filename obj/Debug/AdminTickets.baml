   M S B A M L   `   `   `  ����A  =Cursed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CursedCursed  5          Cursed.AdminTickets   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Cursed     5      -   5          N� Title$  AdminTickets��5	      .��5
      � 
������� � RowDefinitions 5   
   �� 5      $	��238 �6   6+   �� 5      $	��37* �6   6+   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MyGrid��5         AutoGenerateColumns .     
IsReadOnly . 
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер рейса��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
FlightID+6Y     5      $ 
Логин��6%    64   �� *	Userlogin+6T     5      $ Ряд��6%    62   �� *Row+6L     5      $ 
Место��6%    64   �� *Seat+6O     5      $ Цена��6%    63   �� *Price+6O     5      $ Время вылета��6%    6;   �� *Departure_Time+6`   4  .System.Windows.Controls.DataGridTemplateColumn  5         Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6)   	   CellTemplate	 5      �� 5      .R�5      �� $��EditBtn��6%   -   5        $ ��Редактировать��5   F   $��5q�6^   $	��175��6i   $��30��6u   $��Center=�6�   
����� �5      5      5      5       �� 5!   
   -   5        $��Добавить��5!      $��1��6$   $
��Left=�61   $	��175��6^   $	��Top=�6j   $��30��6�   $��5,5,0,0q�6�   6�   �� 5"   
   -   5        $��Удалить��5"      $��1��6#   $��Right=�60   $	��175��6^   $	��Top=�6j   $��30��6�   $��0,5,5,0q�6�   6�   5#      5$      