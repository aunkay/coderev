   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   e aDe.TorstenMandelkow.MetroChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d5b8d1bbc99c4a2awTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5   	    Dashboard.WPF   Dashboard.WPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4c&clr-namespace:System;assembly=mscorlib     5   	   fchartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5   	     � Title$  	Dashboard��5   	   $	��500��6   $	��700��6(   .��5      � -   5         �Name$ maingrid��5      ��6   ��  �� Path$ MainBackground� � RowDefinitions 5   
   �� 5	      $��75 �6   �� 5
      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��120 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   ._�5      �� $��Bottom=�5         BackButtonStyle#��[  5      $	����5       ^� ToolTip$
 Back��5      ��5      �� $ MainForeground���5      �� $ GoBackCommand�5      5      �� 5      $��1��6   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 	pageTitle��5   f   $��Bottom=�6K   $��	Dashboard��6y     PageHeaderTextStyle#��[ 6�   ��6    �� $ MainForeground�6�   �� 5      $��Bottom=�6K   $��0 0 0 3q�6f    J� Opacity$
 0.75Q�6w   $
��Demo��6�     SectionHeaderSmallTextStyle#��[ 6�   ��6    �� $ MainForeground�6�   5       5!      �� 5"      $��2��6   ._�5#      �� $ 
Horizontal=�6   $��Bottom=�66   $��Right=�6Q   .+�5$      �� $ 
Horizontal=�6!   .+�5%      d� -   5        	 d�Name$	 clearButton��5%   '     ToggleButtonWithText#��[ 6<   .��5&      �� $��Clear��6(   ��65   �� $ MainForeground�5'      d� 5(      -   5        $	 
saveButton��5(   '   #��[ 6;   .��5)      �� $
��Save��6(   ��64   �� $ MainForeground�5*      d� 5+      -   5        $	 
loadButton��5+   '   #��[ 6;   .��5,      �� $
��Load��6(   ��64   �� $ MainForeground�5-      d� 5.      -   5        $	 aboutButton��5.   '   #��[ 6<   .��5/      �� $��About��6(   ��65   �� $ MainForeground�50      51      59      5:      5;      �� 5<   
   $��1��6   ._�5=      �� $��120 10 20 10q�5?        SelectableListBoxItem#��[ 5A      
������ ��5>      �� $ MainForeground�
 �� SelectedItem
 5C      �� $ SelectedChartType� �� Mode$ TwoWay=���5D      �� 5E      .R�5F      �� $ 
Horizontal=�6%   5G      ��5I      �� 5J      .R�5K      ��   SectionHeaderTextStyle#��[ 65   ��6$   �� 65   5L      ��5N      �� 5O      .R�5P      ��  ��Name$ 
LayoutRoot��6!   
������ $��0q�6O   #��z��6c   ._�5Q      ��  ��Name$ ScrollViewer��6V   #��z��6l   #��z��6�   #��z��6�   $��0q�6F  
������ ��6+   �� $ MainForeground�.��5R   "   �� 5S      5T      5U      5Y      5Z      �� 5[   
   $��2��6   $��Disabled=�6$   $
��Auto=�6K   $��0q�6p   .��5\      �� -   5        $��stackCharts��5\   G   $ 
Horizontal=�6   $��120 15 25 0q�62   .+�5v      �� -   5        $��Center=�5x      $+��%../fonts/seguisym.ttf#Segoe UI Symbol)�5y      $��Normal"�5z      $��56(�5{      $	����5|      $
 Back��5}      ��5w      �� $ MainForeground�5~      5      5�      5�      5�      