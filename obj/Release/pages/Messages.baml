   M S B A M L   `   `   `  ���� H  DkursProjectV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:kursProjectV3.pageskursProjectV3.pages  "    kursProjectV3.pages.Messages   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:kursProjectV3.pages     -   .��]� .+��� $	��Top=�.+�]� .+��� $	��125��$��../logo.jpg���� $��Center=�.+��� -     ��Name$  GreetingsText��$��Center=�$��Center=�$��30(�$��WrapWithOverflow=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFF7F27��   ShadowDepth$ 2Q�   	Direction$	 270Q�$!��Обратная связь���� -   $��20��$	��150��$��Bottom=����	#FFFF7F27
�������.��личный кабинет�� ���	#FFFF7F27$��15���� -    ��Name$ ShowAllMessages��$y�Visible=�$	��Top=�.+��� -    ��Name$ 
NewMessage��$��20(�$��0 0 0 5q����	#FF287BDE
�������.��Написать�� $	��235��.���� .+��� $��20(�$��Center=�Входящие�� -   $  
NoIncoming��$��18(�$y�Visible=�64У вас нет входящих сообщений&   System.Windows.Controls.DataGrid  -     Name$ 
InMessages��$y�Visible=�   AutoGenerateColumns .  	   
IsReadOnly	 . ���	#FF287BDE
�������
   VerticalGridLinesBrush

 �����   HorizontalGridLinesBrush
 �����$��15(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$  ��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.4* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IsReaded+  $ Заголовок��$ *  �� *headerMessage+�� $��20(�$��Center=�Исходящие�� -   $  NoOutcoming��$��18(�$y�Visible=�86У вас нет исходящих сообщений  -	   $ OutMessages��$y�Visible=� .  	 . ���	#FF287BDE
�������

 �����
 �����$��15(�   $  ��$
 0.4*  �� *
IsReaded+  $ Заголовок��$ *  �� *headerMessage+��  �� Orientation$ 
Horizontal=�$��Center=�$��Bottom=�$��Bottom=�$��70��.+��� -
   $��5 5 5 5 q�$	��300��$��60��$��25(����	#FF287BDE
�������.��На главную�� -   $ WriteNewMessage��$	��Top=�$��Center=�$y�	Collapsed=�.+��� -   $ ChooseUsers��$ 
Horizontal=�.+��� $��20(�	Кому:�� -    ��Name$ 
SelectUser�� �� SelectedIndex$ 0��$��55 0 0 0q�$	��100�����	#FF287BDE$��18(��� $ 
Horizontal=�.+��� $��20(�$��0 5 5 0q�Заголовок:�� -    ��Name$ EnterHeader��$�� 2 5 5 5q�$	��400��
����ح����	#FF287BDE$��Center=�$��18(��� -   $  EnterHeaderError��
���  ��$	��150��$��12(��� $��20(� Текст сообщения:�� $��2q�.���� -   $ MessageText��$	��165��
����ح� �� TextWrapping$
 Wrap=�$��16(����	#FF287BDE�� $ 
Horizontal=�$��Center=�$��Bottom=�$��Bottom=�$��70��.+��� -   $��5 0 0 5 q�$	��300��$��60��$��25(����	#FF287BDE
�������.��
Назад�� -   $��5 0 0 5 q�$	��300��$��60��$��25(����	#FFFF7F27
�������.��Отправить�� -   $ ReadMessage��$y�	Collapsed=�$��Center=�.+��� $ 
Horizontal=�.+��� $��20(�$��Center=�От:�� -   $  Sender��$��30 5 0 0q�$��18(�$��Center=��� $ 
Horizontal=�.+��� $��20(�$��Center=�	Кому:�� -   $  Adresee��$��5 5 0 0q�$��18(�$��Center=��� $ 
Horizontal=�.+��� $��20(�$��0 5 0 5q�Заголовок:�� -   $  Header��$�� 7 5 5 5q�$	��400��$��18(�$��Center=��� 
���  ��$	��150��$��12(��� $��20(� Текст сообщения:�� .���� $��1q����	#FF287BDE._��� -   $
  Text��$	��100��$��16(�$��5 0 0 5q��� $ 
Horizontal=�$��Center=�$��Bottom=�$��Bottom=�$��70��.+��� -   $��5 0 0 5 q�$	��300��$��60��$��25(����	#FF287BDE
�������.��
Назад