   M S B A M L   `   `   `  ????I  EShoesStore_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ShoesStore_WPF.ViewsShoesStore_WPF.Views  5      C&clr-namespace:ShoesStore_WPF.ConverterShoesStore_WPF.Converter  5      '    !ShoesStore_WPF.Views.BuyShoesView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:ShoesStore_WPF.Views     5      <	Converter&clr-namespace:ShoesStore_WPF.Converter     5      ???#90dfaa  ? 	Resources  5      1   +ShoesStore_WPF.Converter.ImagePathConverter   mynew:ImagePathConverter ?? 
TargetType  myCheckboxStyle ?? Property ?? Value ?? 
TargetType ?? Orientation ??Name ?? Triggers P? Property	 P? Value
 ?? 
TargetName ?? StringFormat ?? 	Converter??%?  &	        &	      7   7     5   
   6'   ?? 5   
   " ??6   .?5      ??  ? ?? 5      ?? 5      " ??6&   .R?5      ?? $ 
Horizontal=?6%   .+?5      ?? $ checkboxImage??6$   $U??OC:\Users\Oks\Downloads\GIT\ShoesStore_WPF\ShoesStore_WPF\Images\Status\Wait.png??6;   $??50??6?   ?? 5      5       5      P? 5       ?@d?	IsChecked$
	 TrueY?6;   . ?5   "   ?? $
 checkboxImage??6)    6V   ?? $
 true??8    ? ??5      P? 5       ?@d?	IsChecked$	 FalseY?6;   . ?5   "   ?? $
 checkboxImage??6)    6V   ?? $ false??8   ? ??5   #   5       5"      5#      5'      .??5(      ?  ? IsSharedSizeScope$
 True??6    ? RowDefinitions 5)   
   ?? 5*      $??50 ?6   ?? 5+      $
??auto ?6   ?? 5,      $??10 ?6   ?? 5-      $
??auto ?6   ?? 5.      $??10 ?6   ?? 5/      $
??auto ?6   .+?52   
   ?? $??0??53       
 Header#??[ 54      $??Shopping??55      ? 57   
   $??1??6    59      ?? 5:      $
??auto ?6    ?? 5;      $
??auto ?6    .+?5?      ?? $??0??6   $??Username??6%     	SubHeader#??[ 65   ?? 5@      $??1??5A      ??5C      ?? *
Username+ ?? UpdateSourceTrigger$ PropertyChanged=?.??6Q    ? ContextMenu 5E      ?? 5F      .@?5G      m? $??Copy The BEST??6#    m? Command$
 Copy??6:   6K   m? 5H      $??CUT The WORST??6#   $	 Cut??6:   6J   5J      .??5L   '   5M      5N      ? 5U   
   $??2??6    5V      ?? 5W      $
??auto ?6    ?? 5X      $
??auto ?6     ? ColumnDefinitions 5Z      ?? 5[      $
??auto ?6#    z? SharedSizeGroup$ FirstColumn??60   ?? 5\      $
??auto ?6#   $ SecondColumn??60   5_      ?? 5b   
   $ 
Horizontal=?6   $??Center=?6/   $??5??5c      .+?5e      ?? $??0??6   $
??BUY!??6G   ??6%   ?? *SubmitCommand+6G   ?? 5f      -   5        $??2??5f      $??0,0,0,0q?6%   $??Cancel??5h      ??5g      ?? *CancelCommand+5h   "   5i      ? 5l   
   $??3??6   .+?5n      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False??5o         CanUserAddRows$ False??5p      ??5n      ?? *MyCollection+   Columns 5r      4  .System.Windows.Controls.DataGridTemplateColumn  5s      ,  &System.Windows.Controls.DataGridColumn   Header$ Image??6.      Width5  /System.Windows.Controls.DataGridLengthConverter$	 320 6=      
IsReadOnly$
 True??6I      CellTemplate 5t      ?? 5u      .R?5v   "   ?? ??6(   ?? *Image+5w      5y      0  *System.Windows.Controls.DataGridTextColumn  5z      $ 70 6*   $ Price??65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   ?? *Price+  5|      $	 165 6*   $ Description??67    6L   ?? *Description+  5      $	 Buy??6.    5?      ?? 5?      .R?5?   "   ?? #??[ 5?   +    d? 	IsChecked 5?   +   ?? *
IsSelected+$ PropertyChanged=?5?   +   5?      5?      5?      5?      5?      5?      