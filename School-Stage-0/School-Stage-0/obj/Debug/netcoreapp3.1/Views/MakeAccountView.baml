   M S B A M L   `   `   `  ����I  ESchool-Stage-0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:School_Stage_0.ViewsSchool_Stage_0.Views  5      *    $School_Stage_0.Views.MakeAccountView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:School_Stage_0.Views     5      .��5	      �   � IsSharedSizeScope$
  True��6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��0��6   $��Crate an account��5      � 5   
   $��1��6   $��0 25 0 0q�6    5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   .+�5      �� $��0��6   $��0��5      $��Email��5       �� 5!      $��1��6   $��0��5"      $��0 5 0 0q�5$      ��5#      �� *emailBinding+ �� UpdateSourceTrigger$ PropertyChanged=�5$      5%      � 5'   
   $��2��6   $��0 10 0 0q�6    5)      �� 5*      $
��auto �6    60   �� 5+      $
��auto �6    60    � ColumnDefinitions 5.      �� 5/      $
��auto �6#    z� SharedSizeGroup$ FirstColumn��60   6P   �� 50      $
��auto �6#   $ FirstColumn��60   6P   .+�54      �� $��0��6   $��0��55      $��Start Money��56      �� 57      $��1��6   $��0��58      $��0 5 0 0q�5:      ��59      �� *startMoneyBinding+$ PropertyChanged=�5:      �� 5;      $��0��6   $��1��5<      $��Nationality��5=      $	��100��5>      $��5 0 0 0q�5?      �� 5@      $��1��6   $��1��5A      $��5 5 0 0q�5C      ��5B      �� *nationalityBinding+$ PropertyChanged=�5C      5D      �� 5F   
    �� Orientation$ 
Horizontal=�6   $��3��6.   $��0 25 0 0q�6;   .+�5H      �� $��Submit��6   ��6&   �� *SubmitCommand+6J   �� 5I      $��5 0 0 0q�6   $��Cancel��6&   ��67   �� *CancelCommand+6[   5K      5L      5M      