   M S B A M L   `   `   `  ����  ASClient    ASClient.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$:  4Учёт посещаемости студентов��5   	   $	��720��6-   $
��1060��6:   $	��350��5   	   $	��650��6    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$ SingleBorderWindow=�6.   .��5
      �  � ShowGridLines$ False��6   ���#e0e6ea � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      $��30 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10,8,0,8q�6.   $��0��6@   .+�5      �� -   5         ��Name$ 
GroupsList��5       �� DisplayMemberPath$ Number��6+   $	��100��5      $��24��6#   �� 5      -   5         ��Name$ UpdateStudent��5      $	��Top=�6,   $��16(�5      $
��Bold"�6   $��	10,-2,0,0q�5      $��34��5      .��5      �� $ 
Horizontal=�6   .+�5      �� $��/Views/AddButton2.png��6   $��26��6;   $��34��6G   5      5      �� 5      -   5        $ EditStudent��5      $��0q�6*   $��16(�5       $��	10,-2,0,0q�6#   $��34��5!      .��5"      �� $ 
Horizontal=�6   .+�5#      �� $��/Views/EditButton6.png��6   $��20��6<   $��34��6H   6U   5$      5%      �� 5&      -   5        $ DeleteStudent��5&      $��	10,-2,0,0q�6,   $��0q�6?   $��16(�5'      $��34��6#   .��5)      �� $ 
Horizontal=�6   .+�5*      �� $*��$/Views/Images/Icons/DeleteButton.png��6   $��20��6J   $��34��6V   6c   5+      5,      �� 5-      -   5        $ OpenHistory��5-      $	��Top=�6*   $��16(�5.      $��	10,-2,0,0q�5/      $��34��50      .��51      �� $ 
Horizontal=�6   .+�52      �� $%��/Views/Images/Icons/history.png��6   $��20��6E   $��34��6Q   6^   53      54      �� 55      -   5        $ 	PortsList��55      $��10,0,0,0q�56      $	��100��57      $��24��6   $��1��6+   �� 58      -   5        $ ButtonUpdatePorts��58      $
��Left=�59      $��	10,-2,0,0q�6,   $��Center=�6?   $��16(�5:      $��36��5;      $��1��6   $��0q�6,   .��5<      �� $ 
Horizontal=�6   .+�5=      �� $$��/Views/Images/Icons/Update.png��6   $��20��6D   $��34��6P   6]   5>      5?      �� 5@      -   5        $ ButtonConnectPort��5@      $��16(�5A      $��	10,-2,0,0q�6   $��36��5C      $��0q�5D      .��5E      �� $ 
Horizontal=�6   .+�5F      �� $#��/Views/Images/Icons/Input.png��6   $��20��6C   $��34��6O   6\   5G      5H      5I      &   System.Windows.Controls.DataGrid  5L   
   -	   5        	  Name$	 StudentsList��5L      $��8,0,8,0q�6)   
   AutoGenerateColumns$
 False��6:      
IsReadOnly$
 True��6V      CanUserAddRows$ False��6h   $��1��5M      $��0��6    $��2��60   $��16(�6D      GridLinesVisibility$
 None=�5N         CanUserResizeColumns$ False��6.   
�������
�������   Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+6K     5R      $ Группа��6F   $ * 6V    6%   �� *Group.Number+6V     5S      $ Время прихода��6`   $ * 6w    6%   �� *AttendanceTime+ �� ConverterCulture$ ru-ru��6w   5U      �� 5X   
   -
   5         ��Name$ RfidTag��5X      
���  ��$
��Left=�5Z      $��10,0,0,0q�6+   $��Center=�6=   $��12(�5[      $
��Bold"�6   $��20��5\      $��3��5]      $��0��6   $��2��6-   5^      5_      