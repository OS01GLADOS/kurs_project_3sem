   M S B A M L   `   `   `  ���� H  DkursProjectV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:kursProjectV3.pageskursProjectV3.pages  (    "kursProjectV3.pages.AccountControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:kursProjectV3.pages     -   .��]� .+��� $	��Top=�.+�]� .+��� $	��125��$��../logo.jpg���� $��Center=�.+��� $��Center=�$��Center=�$��30(�$��WrapWithOverflow=�  J� Effect  3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFF7F27��   ShadowDepth$ 2Q�   	Direction$	 270Q�$-��'Управление профилями���� -   $��20��$	��150��$��Bottom=����	#FFFF7F27
�������.��личный кабинет�� ���	#FFFF7F27$��15���� .��]� .+��� $	��Top=�.+�9� $-��'Сортировка аккаунтов��$��20(����	#FF287BDE.���� $��Center=�.+���  �� Orientation$ 
Horizontal=�$��Right=�$�� 0 5 0 5q�.+��� $��18(�Сортировать по�� -    ��Name$ SortPref��$��18(� �� SelectedIndex$ 0��$	��200��$��5 0 0 0q��� $ 
Horizontal=�$��Right=�.+��� $��18(�%#Порядок сортировки�� -   $ 	SortOrder��$��18(�$ 0��$	��200��$��5 0 0 0q�9� $!��Искать аккаунт��$��20(����	#FF287BDE.���� $ Vertical=�$��Center=�.+��� $ 
Horizontal=�$��Right=�.+��� $��18(�Искать по:�� -   $ SearchParams��$��18(�$ 0��$	��200��$��5 5 0 5q�.@��� !Имя пользователя�� Телефон�� $ 
Horizontal=�.+��� $��18(�53Введите значение для поиска�� -    ��Name$ 	SearchVar��$	��200��$��20(�$��5 5 0 5q��� $��20(�DBКликните дважды для выбора аккаунта&   System.Windows.Controls.DataGrid  -     Name$ AllUsers��	   AutoGenerateColumns	 .  
   
IsReadOnly
 . ���	#FF287BDE
�������   VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush
 �����$��12(�$��0 0 0 5q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$% Имя пользователя��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Username+  $ Статус��$ 0.25*  �� *
Userstatus+  $! Номер телефона��$ 1*  �� *PhoneNumber+  $% Дата регистрации��$
 0.5*  �� *RegistrationDate1+  $ Рейтинг��$ 0.25*  �� *	Ranking+9� -    9�Name$ AboutAccount��$��Об аккаунте��$��0 0 0 5q�$��20(����	#FF287BDE$y�	Collapsed=�.���� .+��� $��Center=�.+��� -	    ��Name$ Status��$
��Wrap=�$��18(��� -
   $ 	AllOrders��$��18(�  -   $ ThisUserOrders��	 .  
 . ���	#FF287BDE
�������
 �����
 �����$��12(�$��0 0 0 5q�   $ Номер заказа��$ 1*  �� *Order+  $ Откуда��$ 1*  �� *DepartingPoint+  $ Куда��$ 1*  �� *ArrivalPoint+  $ Стоимость��$ 1*  �� *
OrderPrice+  $ Вес Груза��$ 1*  �� *CargoWeight+  $ Статус заказа��$ 1*  �� *OrderStatus+9� -   $ ChangeSelectedAccount��$%��Изменить аккаунт��$��0 0 0 5q�$��20(����	#FF287BDE$y�	Collapsed=�.���� $��Center=�.+��� $��20(�Изменить статус�� $ 
Horizontal=�.+��� $��18(�*(Выберите новый статус�� -   $ 
ShowStatus��$��18(�$��8 0 0 0q�$	��150��.@��� User�� 	Carrier�� Admin�� $��18(�Изменить пароль�� $ 
Horizontal=�.+��� $��18(�(&Введите новый пароль�� -   $ ChangePassword��$	��150��$��15 0 0 0q�$��20(�
����ح��� -   $ PasswordError��
���  ��$��12(��� $��20(�!Изменить телефон�� $ 
Horizontal=�.+��� $��18(�*(Введите новый телефон�� -   $ ChangePhone��$	��150��$��18(�$��5 0 0 0q�
����ح��� -   $ 
PhoneError��
���  ��$��12(��� $��20(�!Изменить рейтинг�� -    ��Name$ ShowRanking�� � Maximum$ 10Q� � Minimum$ 1Q� �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q� �� TickPlacement$ BottomRight=��� -    ��Name$ SaveChanges�����	#FFFF7F27
�������$��0 5 0 0q�.��'%Сохранить изменения�� $ 
Horizontal=�$��Center=�$��Bottom=�$��Bottom=�$��70��.+��� -   $��5 0 0 5 q�$	��300��$��60��$��25(����	#FF287BDE
�������.��На главную