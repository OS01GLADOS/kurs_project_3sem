   M S B A M L   `   `   `  ���� H  DkursProjectV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:kursProjectV3.pageskursProjectV3.pages  '    !kursProjectV3.pages.FindDirection   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:kursProjectV3.pages     -   .��]� .+��� $	��Top=�.+�]� .+��� $	��125��$��../logo.jpg���� $��Center=�.+��� $��Center=�$��Center=�$��30(�$��WrapWithOverflow=�  J� Effect  3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFF7F27��   ShadowDepth$ 2Q�   	Direction$	 270Q�$!��Поиск маршрута���� -   $��20��$	��150��$��Bottom=����	#FFFF7F27
�������.��личный кабинет�� ���	#FFFF7F27$��15��]� .+��� $��Center=�$	��Top=�$��0 5 0 5q�.+���  �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��40��$	��Top=�$��0 5 0 5q�.+��� $��20(����	#FF287BDE$��5 0 5 0q�Откуда:�� -    ��Name$ 	FromPoint��$	��100��$��20(����	#FF287BDE$	��180���� $��20(����	#FF287BDE$��5 0 5 0q�	Куда:�� -   $ ToPoint��$	��100��$��20(����	#FF287BDE$	��180���� -   ���	#FF287BDE
�������$��25(�$	��130��.��Показать�� $ 
Horizontal=�$
��Left=�.+��� $��20(����	#FF287BDE$��5 0 5 0q�Сортировать по�� -    ��Name$ 	HowToSort��$��20(� �� SelectedIndex$ 0�����	#FF287BDE$	��180���� -   $ Order��$��20(�$ 0�����	#FF287BDE$	��180��$��5 0 5 0q��� $	��Top=�.���� .+�&   System.Windows.Controls.DataGrid  -     Name$ AllDirections��	   AutoGenerateColumns	 .  
   
IsReadOnly
 . ���	#FF287BDE
�������   VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush
 �����$��12(�$��0 0 0 5q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Откуда��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.6* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *DepartingPoint+  $ Куда��$
 0.6*  �� *ArrivalPoint+  $ Отправление��$
 0.7*  �� *DepartingTime+  $ Прибытие��$
 0.7*  �� *ArrivalTime+  $! Время в пути, ч.��$ 1*  �� *TimeToReach+  $ Цена за 1 кг��$
 0.8*  �� *Price+  $% Дата отправления��$ 1*  �� *DepartureDate+  $ Перевозчик��$
 0.9*  �� *	Carrier+�� -	    ��Name$	 Tip��$��20(� �� TextAlignment$ Center=�a_Дважды нажмите на результат, для бронирования места�� $ 
Horizontal=�$��Center=�$��Bottom=�$��Bottom=�$��70��.+��� -
    ��Name$ 
ToMainPage��$��5 0 0 5 q�$	��300��$��60��$��25(����	#FF287BDE
�������.��НА ГЛАВНУЮ