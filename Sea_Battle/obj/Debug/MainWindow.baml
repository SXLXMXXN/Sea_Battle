   M S B A M L   `   `   `  ????E  ASea_Battle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Sea_Battle
Sea_Battle  5   	       Sea_Battle.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Sea_Battle     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??500??6)   $	??450??5	      $	??500??6   .??5
      ?  ? RowDefinitions 5   
   ?? 5      $??5* ?6   ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      $
??172* ?6   ?? 5      $	??39* ?6   ?? 5      $	??39* ?6   .+?5   
   ?? -   5         ??Name$ Field??5      $??45,44,10,10q?6!   $??Disabled=?66   $??Disabled=?6m   ??5      ?? 5       ?? 
TargetType" ??6   .?5      ??  ?? Property ? ?? ?? Value$ Stretch=?6C   6U   ?? 5       ? ??$ Stretch=?6A   6S   ?? 5       ? ??$ 0q?60   6<   ?? 5       ? ??$ 1q?68   ?? 5       ? ??
 ?   ?64   5      ??5      ?? 5       .R?5!      A?  A? Columns$ 10??6"    A? Rows$ 10??6/   5"      5$      ?? 5%   
   -   5        $??letters??5%      $??
10,44,0,10q?6!   $
??Left=?65   $??30??6P   $??Disabled=?6[   $??Disabled=?6?   ??5&      ?? 5'      " ??6   .?5(      ??  ? ??$ Center=?6C   6T   ?? 5)       ? ??$ Center=?6A   6R   ?? 5*       ? ??$ 0q?60   6<   ?? 5+       ? ??$ 1q?68   ?? 5,       ? ??
 ?   ?64   5-      ??5/      ?? 50      .R?51      A? $ 10??6#   52      54      ?? 55   
   -   5        $??numbers??55      $??29??6#   $??
45,10,10,0q?6/   $	??Top=?6C   $??Disabled=?6[   $??Disabled=?6?   ??56      ?? 57      " ??6   .?58      ??  ? ??$ Center=?6C   6T   ?? 59       ? ??$ Center=?6A   6R   ?? 5:       ? ??$ 0q?60   6<   ?? 5;       ? ??$ 1q?68   ?? 5<       ? ??
 ?   ?64   5=      ??5?      ?? 5@      .R?5A      A? $ 10??6"   5B      5D      (? 5g   
   $??
10,20,0,20q?6   $??1??6&   .??5h      ?? -   5        	 ??Name$	 	turnsLeft??5h      $??Turns Left:??6.   
 ?? TextAlignment$

 Left=?6A   $	??249??6V   5i      (? 5j   
   $??
10,20,0,20q?6   $??2??6&   .??5k      ?? -   5        $	 currentScore??5k      $??Current score:??60   $

 Left=?6F   $	??250??6[   5l      (? 5m   
   $??
5,10,10,10q?6   $??1??6&   $??2??66   $??2??6C   .??5n      ?? -   5        $	 	bestScore??5n      $??2??6+   $?? ??69   $??88??6B   $
 Center=?6M   5o      (? 5p   
   $??
45,9,44,11q?6   $??1??6&   $??1??66   $??2??6C   .??5q      ?? -   5         ??Name$ start??5q      $??1??6$   $??Start??64   $??42??6[   $??88??6g   $??0,10,0,0q?6r   5r      ?? 5y   
   $??1??6   $??
0,44,0,121q?6#   $??Disabled=?67   $??Disabled=?6n    J? IsHitTestVisible .  ??6?   Z? ??5z      ?? 5{      " ??6   .?5|      ??  ? ??$ Stretch=?6C   6U   ?? 5}       ? ??$ Stretch=?6A   6S   5~      ??5?      ?? 5?      .R?5?      A? $ 4??6#   5?      .@?5?      ?? .??5?      ?? $??Center=?6   $??/Files/Screenshot_111.png??64   $??Uniform=?6W   $??Center=?6i    J? OpacityMask 5?      ?? 5?       j? Stretch$ Uniform=?6%    ?? ImageSource$ /Files/Screenshot_111.png??67   5?      5?      ?? 5?      $??Center=?6   $??/Files/Screenshot_110.png??60   $??Uniform=?6S   $??Center=?6e    5?      ?? 5?      $ Uniform=?6!   $ /Files/Screenshot_110.png??63   5?      ?? 5?      $??Center=?6   $??/Files/Screenshot_109.png??60   $??Uniform=?6S   $??Center=?6e    5?      ?? 5?      $ Uniform=?6!   $ /Files/Screenshot_109.png??63   5?      ?? 5?      $??Center=?6   $??/Files/Screenshot_108.png??60   $??Uniform=?6S   $??Center=?6e    5?      ?? 5?      $ Uniform=?6!   $ /Files/Screenshot_108.png??63   5?      5?      ?? 5?   
   $??2??6   $??
0,44,0,121q?6#   $??Disabled=?67   $??Disabled=?6n    .  ??6?   Z? ??5?      ?? 5?      " ??6   .?5?      ??  ? ??$ Stretch=?6C   ?? 5?       ? ??$ Stretch=?6A   ?? 5?       ? ??$ 0q?68   ?? 5?       ? ??
 ?????64   5?      ??5?      ?? 5?      .R?5?      A? $ 4??6#   5?      .@?5?      ?? .??5?      (?  J? RenderTransformOrigin$ 0.515,0.501&?6   .??5?      ?? -   5        $??deck4??5?       $??1??6/   $
??Wrap=?6@   $?? ??6T   $??Center=?6\   $??14??6w   $??Center=?6?   $??70??6?   5?      5?      (? 5?      .??5?      ?? -	   5        $??deck3??5?      $
??Wrap=?6-   $?? ??6A   $??Center=?6I   $??14??6d   $??Center=?6p   $??70??6?   5?      (? 5?      .??5?      ?? -
   5        $	 deck2??5?      $
??Wrap=?6-   $?? ??6A   $??Center=?6I   $??14??6d   $??Center=?6p   $??70??6?   5?      (? 5?      .??5?      ?? -   5        $	 deck1??5?      $
??Wrap=?6-   $?? ??6A   $??Center=?6I   $??14??6d   $??Center=?6p   $??70??6?   5?      5?      5?      5?      