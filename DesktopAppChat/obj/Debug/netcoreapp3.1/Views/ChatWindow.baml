   M S B A M L   `   `   `  ����I  EDesktopAppChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DesktopAppChatDesktopAppChat  5   	   C&clr-namespace:DesktopAppChat.ViewModelDesktopAppChat.ViewModel  5   	       DesktopAppChat.ChatWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DesktopAppChat     5   	   =
viewmodels&clr-namespace:DesktopAppChat.ViewModel     5   	     � Title$  
ChatWindow��5	   	   $	��600��6   $	��800��6)    � DataContext 5
      ,  &DesktopAppChat.ViewModel.ChatViewModel  5   
   .��5      � 
����ح�.+�5   
   �� $	��Top=�6   $
��Left=�6,   $��	20,20,0,0q�6G   $	��450��6{   $	��620��6�   ��6Z   �� *
Messages+ �� View 5      �� 5      .P�5      ��  �� Width$	 125��6%    �� DisplayMemberBinding 61   �� *
UserName+.��5      �� $
��User��6$   5      �� 5      $	 340��6%    61   �� *	Message+.��5      �� $��Message��6$   5      �� 5      $	 150��6&    62   �� *Time+.��5      �� $
��Time��6$   5      5      5      �� 5   
   $��30��6   $	��620��6   $
��Left=�6*   $��Bottom=�6E   $��	20,0,0,20q�6`   ��6s   �� *	Message+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   
����p��$��Bottom=�6,   $��Right=�6G   $��0, 0, 10, 20q�6c   $��30��6y   $	��100��6�   $
{�True��6�   ��6�   �� *SendMessageCommand+.��5      �� $
��Send��6   5       �� 5!   
   
����p��$��30��6,   $	��100��68   $	��Top=�6D   $��Right=�6\   $��
0,400,10,0q�6x   ��6�   �� *ChatConnect+.��5"      �� $��Connect��6   5#      �� 5$   
   
����p��$��30��6,   $	��100��68   $	��Top=�6D   $��Right=�6\   $��
0,365,10,0q�6x   ��6�   �� *ChatDisconnect+.��5%      �� $��
Disconnect��6   5&      5'      5(      