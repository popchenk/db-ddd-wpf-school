   M S B A M L   `   `   `  ����K  GWpfDbApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WpfDbApplication.ViewsWpfDbApplication.Views  5      I)clr-namespace:WpfDbApplication.ViewModelsWpfDbApplication.ViewModels  6A   ,    &WpfDbApplication.Views.MakeAccountView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:WpfDbApplication.Views     5      @
viewmodels)clr-namespace:WpfDbApplication.ViewModels     6A   .��5	      �   � IsSharedSizeScope$
  True��6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��0��6   $��Crate an account��5      � 5   
   $��1��6   $��0 25 0 0q�6    5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   .+�5       �� $��0��6   $��0��5!      $��Email��5"      �� 5#      $��1��6   $��0��5$      $��0 5 0 0q�5&      ��5%      �� *emailBinding+ �� UpdateSourceTrigger$ PropertyChanged=�5&      5'      � 5)   
   $��2��6   $��0 10 0 0q�6    5+      �� 5,      $
��auto �6    60   �� 5-      $
��auto �6    60    � ColumnDefinitions 50      �� 51      $
��auto �6#    z� SharedSizeGroup$ FirstColumn��60   6P   �� 52      $
��auto �6#   $ FirstColumn��60   6P   .+�56      �� $��0��6   $��0��57      $��Start Money��58      �� 59      $��1��6   $��0��5:      $��0 5 0 0q�5<      ��5;      �� *startMoneyBinding+$ PropertyChanged=�5<      �� 5=      $��0��6   $��1��5>      $��Nationality��5?      $	��100��5@      $��5 0 0 0q�5A      �� 5B      $��1��6   $��1��5C      $��5 5 0 0q�5E      ��5D      �� *nationalityBinding+$ PropertyChanged=�5E      5F      � 5H   
   $��3��6   $��0 10 0 0q�6    5J      �� 5K      $
��auto �6    60   �� 5L      $
��auto �6    60   �� 5M      $
��auto �6    60    5P      �� 5Q      $
��auto �6#   $ FirstColumn��60   6P   �� 5R      $
��auto �6#   $ FirstColumn��60   6P   �� 5S      $
��auto �6#   $ FirstColumn��60   6P   .+�5W      �� $��0��6   $��0��5X      $��Card num��5Y      �� 5Z      $��1��6   $��0��5[      $��0 5 0 0q�5]      ��5\      �� *cardNumBinding+$ PropertyChanged=�5]      �� 5^      $��0��6   $��1��5_      $	��Cvv��5`      $	��100��5a      $��5 0 0 0q�5b      �� 5c      $��1��6   $��1��5d      $��5 5 0 0q�5f      ��5e      �� *
cvvBinding+$ PropertyChanged=�5f      �� 5g      $��0��6   $��2��5h      $��End Date��5i      $	��100��5j      $��5 0 0 0q�5k      �� 5l      $��1��6   $��2��5m      $��5 5 0 0q�5o      ��5n      �� *expDateBinding+$ PropertyChanged=�5o      5p      �� 5r   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��0 25 0 0q�6;   .+�5t      �� $��Submit��6   ��6&   �� *SubmitCommand+6J   �� 5u      $��5 0 0 0q�6   $��Cancel��6&   ��67   �� *CancelCommand+6[   5w      5x      5y      