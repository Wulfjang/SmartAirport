   M S B A M L   `   `   `  ����  SmartAirport    SmartAirport.BaggageForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$)  #Управление багажом��5   	   $	��500��6$   $	��600��61   .��5      � .+�5   
   �� $��
Багаж��6   $��16(�6!   $
��Bold"�6/   $
��Left=�6A   $��	20,20,0,0q�6\   &   System.Windows.Controls.DataGrid  5   
   -   5        $��BaggageGrid��5         AutoGenerateColumns .     
IsReadOnly . $��Stretch=�6T   $��Stretch=�6r   $��20,50,20,100q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер багажа��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	BaggageID+6Y     5
      $ Номер рейса��6%   $ * 6[    6:   �� *FlightNumber+6[     5      $ Вес��6%   $ * 6M    62   �� *Weight+6M     5      $ Статус��6%   $ * 6P    65   �� *Status+6P   5      �� 5   
   -   5        $!��Добавить багаж��5      $	��130��6*   $��30��66   $
��Left=�6B   $��Bottom=�6]   $��	20,0,0,20q�6x   6�   �� 5   
   -   5        $��Найти багаж��5      $	��130��6'   $��Center=�63   $��0,0,0,20q�6r   $��30��6�   $��Bottom=�6�   �� 5   
   -   5        $��Удалить багаж��5      $	��130��6)   $��30��65   $��Right=�6A   $��Bottom=�6]   $��	0,0,20,20q�6x   6�   5      5      