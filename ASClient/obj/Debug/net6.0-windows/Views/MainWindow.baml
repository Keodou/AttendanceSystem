   M S B A M L   `   `   `  ????  ASClient    ASClient.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     ? Title$  Attendance System Utility??5   	   $	??720??6+   $
??1000??68   $	??350??5   	   $	??650??6    ? WindowStartupLocation$ CenterScreen=?5	   	    ? WindowStyle$ SingleBorderWindow=?6.   .??5
      ?  ? ShowGridLines$ False??6   ???#e0e6ea ? ColumnDefinitions 5   
   ?? 5      ?? 5      $	??440 ?6    ? RowDefinitions 5   
   ?? 5      $??50 ?6   ?? 5      ?? 5      $??50 ?6   .+?5   
   ?? -   5         ??Name$ UpdateStudent??5      $??+ Добавить??6(   $
??Left=?5      $??Center=?6,   $??16(?5      $??10,0,0,0q?5      $	??120??5      $??0??5      $??2??6!   65   ?? 5   
   -   5         ??Name$ 
GroupsList??5       ?? DisplayMemberPath$ Number??6'   $
??Left=?5      $??Center=?6.   $	??120??5      $??26??6   $??	160,0,0,0q?6+   6Y   &   System.Windows.Controls.DataGrid  5"   
   -   5        	  Name$	 StudentsList??5"      $??8,0,8,0q?6)   
   AutoGenerateColumns$
 False??6:      
IsReadOnly$
 True??6s      CanUserAddRows$ False??6?   $??1??5#      $??0??6    $??2??60   $??16(?6D      GridLinesVisibility$
 None=?5$         CanUserResizeColumns$ False??6.   
????  ?
???????   Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя??6>      Width5  /System.Windows.Controls.DataGridLengthConverter$	 220 6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *Name+6K     5(      $ Группа??6F   $ * 6V    6%   ?? *Group.Number+6V     5)      $ RFID метка??6A   $ * 6U    6%   ?? *	RfidTag+6U     5*      $ Посещаемость??6D   $ * 6Z    6%   ?? *
Attendance+6Z     5+      $ Время прихода??6H   $ * 6_    6%   ?? *AttendanceTime+6_   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $ 40 6)      CellTemplate 5-      ?? 5.      .R?5/      ?? $ EditStudent??6%   -   5        $??Р??5/   :   6F   50      52        53      $ 40 6)    54      ?? 55      .R?56      ?? $ DeleteStudent??6%   -   5        $??У??56   <   
???  ??6Z   57      59      5;      ?? 5>   
   -   5         ??Name$ RfidTag??5>      $?? AA AA AA AA ??5?      
???  ??$
??Left=?5@      $??10,0,0,0q?6+   $??Center=?6=   $??16(?5A      $
??Bold"?6   $??25??5B      $??2??6   ?? 5C   
   -   5        $ ButtonConnectPort??5C      $??Подключиться??5D      $
??Left=?5E      $??Center=?6,   $??16(?5F      $??	310,0,0,0q?5G      $	??120??5I      $??2??5J      $??1??6   $|?False??5K      ?? 5L   
   -   5        $ ButtonUpdatePorts??5L      $??Обновить??6,   $
??Left=?5M      $??	173,0,0,0q?6,   $??Center=?6?   $??16(?5N      $	??120??5O      $??2??5P      $??1??6   ?? 5Q   
   -	   5        $ 	PortsList??5Q      $
??Left=?5R      $??33,0,0,0q?6.   $??Center=?6@   $	??120??5S      $??25??6   $??2??5T      $??1??6    5U      5V      