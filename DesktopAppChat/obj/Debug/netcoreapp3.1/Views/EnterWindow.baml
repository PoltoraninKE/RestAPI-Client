   M S B A M L   `   `   `  ����I  EDesktopAppChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DesktopAppChat.ViewModelDesktopAppChat.ViewModel  5   	   G(clr-namespace:DesktopAppChat.AdditionalsDesktopAppChat.Additionals  5   	   &     DesktopAppChat.Views.EnterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   7
viewmodels&clr-namespace:DesktopAppChat.ViewModel  5   	   8	behaviors(clr-namespace:DesktopAppChat.Additionals  5   	     � Title$  EnterWindow��5
   	   $	��450��6   $	��350��6*    � DataContext 5      ,  &DesktopAppChat.ViewModel.UserViewModel  5   
   .��5      � 
����ح�.+�5   
   � $��0, 0, 0, 100q�6   .+�5      �� $��Login��6   $	��Top=�6%   $
��Left=�6=   $��25, 20, 10, 10q�6X   $��Courier New)�6p   $
��Bold"�6�   �� 5      
�������$��Center=�6v   $	��Top=�6�   $	��300��6�   $��10, 50, 10, 0q�6�   $��30��6�   $��Courier New)�6�   $
��Bold"�6�   ��6-   �� *Login+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��Password��6   $	��Top=�6(   $
��Left=�6@   $��25, 120, 10, 10q�6[   $��Courier New)�6t   $
��Bold"�6�   G� 5      
�������$��Center=�61   $��Bottom=�6N   $	��300��6i   $��10, 0, 10, 150q�6u   $��30��6�   .  (System.Windows.Interactivity.Interaction   	Behaviors 5      6  0DesktopAppChat.Additionals.PasswordBoxAdditional  5         Password 66   �� *
Password+$ TwoWay=�6c   5      5      � 5   
   $��0, 350, 0, 0q�6   .+�5      �� -   5         ��Name$ SignIn��5   0   
����p��$��Center=�6@   $��Right=�6[   $��10q�6w   $��25��6�   $��75��6�   ��6�   �� *SignIn+.��5      �� $��Sign in��6   $��14(�6+   $��Courier New)�69   $
��Bold"�6R   5      �� 5      -   5        $ LogIn��5   0   
����p��$��Center=�6?   $
��Left=�6Z   $��10q�6u   $��25��6�   $��75��6�   $
{�True��6�   ��6�   �� *LogIn+.��5      �� $��Log in��6   $��14(�6*   $��Courier New)�68   $
��Bold"�6Q   5       5!      5"      5#      