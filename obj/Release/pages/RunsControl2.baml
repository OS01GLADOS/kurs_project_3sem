   M S B A M L   `   `   `  ���� H  DkursProjectV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:kursProjectV3.pageskursProjectV3.pages  &     kursProjectV3.pages.RunsControl2   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:kursProjectV3.pages     -   .��]� .+��� $	��Top=�.+�]� .+��� $	��125��$��../logo.jpg���� $��Center=�.+��� $��Center=�$��Center=�$��30(�$��WrapWithOverflow=�  J� Effect  3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFF7F27��   ShadowDepth$ 2Q�   	Direction$	 270Q�$A��;Управление маршрутами и рейсами���� -   $��20��$	��150��$��Bottom=����	#FFFF7F27
�������.��личный кабинет�� ���	#FFFF7F27$��15���� .���� .+��� $��Center=�$��0 5 0 0q�.+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ ForAdminText��$��20(�$��Center=�$��0 0 5 0q�)'Текущий пользователь�� -    ��Name$ ForAdmin�� �� SelectedIndex$ 0��$��20(�$	��200�����	#FF287BDE�� $��20(� �� TextAlignment$ Center=�Все маршруты&   System.Windows.Controls.DataGrid  -   	  Name$	 AllDirections��
   AutoGenerateColumns
 .     
IsReadOnly . ���	#FF287BDE
�������   VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush
 �����$��15(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$! Номер маршрута��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Direction+  $ Откуда��$ 1*  �� *DepartingPoint+  $ Куда��$ 1*  �� *ArrivalPoint+  $' !Время отправления��$ 1*  �� *DepartingTime+  $% Проведено рейсов��$ 1*  �� *RunsCountByDir+�� -   $ NoDirections��$y�	Collapsed=�$��20(�$ Center=�=;Вы не создали ни одного маршрута�� -   
����������	#FFFF7F27$��18(�.��!Добавить маршрут�� -    ��Name$ FormToAddDirection��$y�	Collapsed=�$��Center=�.+��� $ 
Horizontal=�$��Right=�$��0 5 0 0q�.+��� $��18(�$"Город отправления:�� -	    ��Name$ DepartingPointIn��
����ح�$	��300��$��18(��� -
   $ DepartingPointInError��
���  ��$��12(�$	��150���� $ 
Horizontal=�$��Right=�$��0 5 0 0q�.+��� $��18(�" Город назначения:�� -   $ ArrivalPointIn��
����ح�$	��300��$��18(��� -   $ ArrivalPointInError��
���  ��$	��150��$��12(��� $ 
Horizontal=�$��Right=�$��0 5 0 0q�.+��� $��18(�/-Цена за перевозку 1 кг, р.:�� -   $ PriceIn��
����ح�$	��300��$��18(��� -   $ PriceInError��
���  ��$	��150��$��12(��� $ 
Horizontal=�$��Right=�$��0 5 0 0q�.+��� $��18(�#!Время отправления�� -   $ DepartureTimeIn��
����ح�$	��300��$��18(��� -   $ DepartureTimeInError��
���  ��$	��150��$��12(��� $ 
Horizontal=�$��Right=�$��0 5 0 0q�.+��� $��18(�Время прибытия�� -   $ ArrivalTime��
����ح�$	��300��$��18(��� -   $ ArrivalTimeInError��
���  ��$	��150��$��12(��� $ 
Horizontal=�$��Right=�$��0 5 0 0q�.+��� $��18(�Вместимость, кг.�� -   $ 
CapacityIn��
����ح�$	��300��$��18(��� -   $ CapacityInError��
���  ��$	��150��$��12(��� -    ��Name$ AddDirectionButton��$��18(�
����������	#FF287BDE.��Добавить�� -   $ DeleteDirection��$y�	Collapsed=�$��18(�
����������	#FF287BDE.��Удалить маршрут9� -    9�Name$  RunsOnChosenDirectionStats��$1��+Рейсы по этому маршруту��$y�	Collapsed=�$��20(�.���� .+�  -   $	 RunsOnChosenDirection��
 .   . ���	#FF287BDE
�������
 �����
 �����$��15(�   $ Номер рейса��$ 1*  �� *Run+  $ Дата��$ 1*  �� *DepartureDate+  $+ %Колличество заказов��$ 1*  �� *
OrderCount+  $ Статус ��$ 1*  �� *	RunStatus+�� -   $ NoRuns��$��18(�<:по даннному маршруту нет рейсов�� -   
����������	#FFFF7F27$��18(�.��DBДобавить рейс по выбранному машруту�� -   $ AddRun��$y�	Collapsed=�$��Center=�.+��� $ 
Horizontal=�$��Right=�$��0 5 0 0q�.+��� $��18(�" Дата отправления:�� -   $ RunDepartingTime��
����ح�$	��300��$��18(��� -   $ RunDepartingTimeError��
���  ��$	��150��$��12(��� $ 
Horizontal=�$��Right=�$��0 5 0 5q�.+��� $��18(� Вместимость, кг.:�� -   $ RunAvailableCapacity��
����ح�$	��300��$��18(��� -   $ RunAvailableCapacityError��
���  ��$	��150��$��12(��� -    $ AddRunButton��$��18(�
����������	#FF287BDE.��Добавить�� -!   $ 	deleteRun��$y�	Collapsed=�.��Отменить рейс�� -"   $ completeRun��$y�	Collapsed=�.��42Подтвердить прибытие рейса�� -#   $ AllOrdersOnCurrentRun��.+��� -$   $ AllOrdersTopic��$��18(�$ Center=�0.Все заказы на данный рейс  -%   $ 	 AllOrdersOnCurrentRunTable��$y�	Collapsed=�
 .   . ���	#FF287BDE
�������
 �����
 �����$��15(�   $ Клиент��$ 1*  �� *Client+  $ Вес груза��$ 1*  �� *CargoWeight+  $# Телефон клиента��$ 1*  �� *phoneNumber+�� -&   $ NoOrders��$��20(�$y�	Collapsed=�97На данный рейс ещё нет заказов�� $ 
Horizontal=�$��Center=�$��Bottom=�$��Bottom=�$��70��.+��� -'   $��5 0 0 5 q�$	��300��$��60��$��25(����	#FF287BDE
�������.��На главную