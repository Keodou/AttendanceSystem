   M S B A M L   `   `   `  ????C  ?ASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ASClient.ViewsASClient.Views  5   	   "    ASClient.Views.DetailsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ASClient.Views     5   	     ? Title$  DetailsWindow??5   	   $	??450??6   $	??600??6,    ? WindowStartupLocation$ CenterScreen=?68    ? WindowStyle$
 None=?5	   	    ? 
ResizeMode$ NoResize=?6   .??5
      ? ???#e0e6ea ? RowDefinitions 5   
   ?? 5      $??5* ?6   ?? 5      $	??20* ?6   ?? 5      $??4* ?6   .+?5   
   ?? $-??'История посещаемости??6   $??Center=?5      $??Center=?6/   $??26(?5      $
??Bold"?6"   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ HistoryList??5      $??8q?6(      AutoGenerateColumns$ False??63      
IsReadOnly$
 True??6O      CanUserAddRows$ False??6a   $??1??5      $??16(?6    	   GridLinesVisibility$
	 None=?5      
   CanUserResizeColumns$
 False??6.   
????  ?
???????   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Посещаемость??6I      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ??  ?? Path$ 
Attendance?6_     5      $! Дата посещения??6M   $ * 6e    6%   ?? $ AttendanceTime?6e   5      ?? 5   
   -   5         ??Name$ Close??5      $??Закрыть??6    $??Center=?5      $??Center=?6.   $??16(?5       $	??100??5!      $??2??5"      $??1??6   
???  ??5#   #   5$      5%      