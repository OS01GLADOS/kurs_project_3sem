   M S B A M L   `   `   `  ���� H  DkursProjectV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:kursProjectV3.pageskursProjectV3.pages  %    kursProjectV3.pages.UserCabinet   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:kursProjectV3.pages     .��]� .+��� $	��Top=�.+�]� .+��� $	��125��$��../logo.jpg���� $��Center=�.+��� $��Center=�$��Center=�$��30(�$��WrapWithOverflow=�  J� Effect  3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFF7F27��   ShadowDepth$ 2Q�   	Direction$	 270Q�$!��Личный кабинет���� -    ��Name$ UsernameOut��$��Center=�$��Center=�$��30(�$��WrapWithOverflow=��� ���	#FFFF7F27$��15���� .���� .+��� $��30(�#!Выберите действие9� $��Статистика��$��25(����	#FF287BDE.���� $��Center=�.+��� -   $ 
ShowStatus��$��23(�Статус:�� -   $ ShowRegistrationDate��$��23(�" Дата регистрации:�� -   $ ShowOrderAmount��$��23(�(&Колличество заказов:9� $��Смена пароля��$��25(����	#FF287BDE.���� $��Center=�.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� $��23(�Старый парольG� -    G�Name$ PasswordOld��$��23(�$	��300��$��5 5 5 5q�
����ح��� -   $ passwordOldError��
���  ��$	��160��$��WrapWithOverflow=�$��Center=�$��12(��� $ 
Horizontal=�$��Right=�.+��� $��23(�Новый парольG� -   $ PasswordEntered1��$��23(�$	��300��$��5 5 5 5q�
����ح��� -   $ password1Error��
���  ��$	��160��$��WrapWithOverflow=�$��Center=�$��12(��� $ 
Horizontal=�$��Right=�.+��� $��23(�!Повторите парольG� -	   $ PasswordEntered2��$��23(�$	��300��$��5 5 5 5q�
����ح��� -
   $ password2Error��
���  ��$	��160��$��WrapWithOverflow=�$��Center=�$��12(��� -   ���	#FF287BDE
�������.��Изменить пароль9� $��Мои заказы��$��25(����	#FF287BDE.���� .+��� -   $ NoOrders��$��23(��� $D�>Вы еще не сделали ни одного заказа���� -   $	 tip��$��23(�@>Щёлкните дважды для отмены заказа�� .��&   System.Windows.Controls.DataGrid  -     Name$ ThisUserOrders��   AutoGenerateColumns .  	   
IsReadOnly	 . $��21(����	#FF287BDE
�������
   VerticalGridLinesBrush

 �����   HorizontalGridLinesBrush
 �����   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.1* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Order+  $ Откуда��$
 0.9*  �� *DepartingPoint+  $ Куда��$
 0.9*  �� *ArrivalPoint+  $ Стоимость��$ 0.85*  �� *
OrderPrice+  $ Вес Груза��$ 1*  �� *CargoWeight+  $ Статус ��$
 0.9*  �� *OrderStatus+�� $ 
Horizontal=�$��Center=�$��Center=�.+��� -   $��0 0 5 5 q�$	��300��$��60��$��25(����	#FFFF7F27
�������.��На главную�� -   $��0 0 5 5 q�$	��300��$��60��$��25(����	#FF287BDE
�������.�� Выход из системы