   M S B A M L   `   `   `  ����  SmartAirport    SmartAirport.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$,  &SmartAirport - Главное окно��5   	   $	��600��6-   $	��800��6:   .��5      � .+�5   
   o� $	��Top=�6   $��Stretch=�6'   .@�5      m� $��Файл��6   .@�5      m� -   5        $��
Выход��5      6*   5	      m� 5
      $��Управление��6   .@�5      m� -   5        $��
Рейсы��5      6*   m� 5      -   5        $��
Багаж��5      6*   m� 5      -   5        $��Безопасность��5      61   5      5      �� 5   
   $'��!Расписание рейсов��6   $��16(�6-   $
��Bold"�6;   $
��Left=�6M   $��	20,40,0,0q�6h   &   System.Windows.Controls.DataGrid  5   
   -   5        $��FlightScheduleGrid��5         AutoGenerateColumns .     
IsReadOnly . $��Stretch=�6[   $��Stretch=�6y   $��20,70,20,80q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер рейса��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *FlightNumber+6[     5      $% Пункт назначения��6%   $ * 6_    6?   �� *Destination+6_     5      $' !Время отправления��6%   $ * 6b    6@   �� *DepartureTime+6b     5      $ Статус��6%   $ * 6P    65   �� *Status+6P   5      �� 5   
   -   5        $��Добавить рейс��5      $	��200��6)   $��30��65   $
��Left=�6A   $��Bottom=�6\   $��	20,0,0,20q�6w   6�   �� 5   
   -   5        $)��#Редактировать рейс��5      $	��300��6.   $��30��6:   $��Center=�6F   $��0,0,0,20q�6c   $��Bottom=�6�   �� 5   
   -   5        $��Удалить рейс��5      $	��200��6(   $��30��64   $��Right=�6@   $��	0,0,20,20q�6\   $��Bottom=�6�   5      5      