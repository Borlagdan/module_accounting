   M S B A M L   `   `   `  ����L  HModule_Accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Module_AccountingModule_Accounting  5	   	   "    Module_Accounting.Accounting   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:Module_Accounting  5	   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  
Accounting��5   	   $	��600��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66    � WindowState$ 	Maximized=�6[    � WindowStyle$
 None=�6s   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   � $��0��6   
���W�.�.+�5      �  � ColumnDefinitions 5      �� 5      $
��.15* �6'   �� 5      $
��.85* �6'   .+�5       � $��0��6   $��2q�6'   .+�5!      (� .��5"      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6>   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:1.2X�.��5#      �� $
��Auto��6$   $
��Auto��62   $��/Images/logo.png��6?   6[   5$      5%      5&      � 5(      $��1��6   .+�5)      (� $
��Left=�6   .��5*         6>     *SlideInFromRight+$ 0:0:1.2X�.��5+      �� 
������� �� Padding$ 5 5 5 5q�6;   $(��"Christian Centre School Foundation��6M   5,      5-      5.      5/      50      � 52   
   $��1��6    53      �� 54      $
��.35* �6#   �� 55      $
��.65* �6#   .+�58      � $��0��6    59      �� 5:      $
��.50* �6$   �� 5;      $
��.50* �6$   .+�5>      � $��0��6   .+�5?      #  MaterialDesignThemes.Wpf.Card  $��5q�6*   +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth2=�65   .��5@      �  5A      �� 5B   "   $
��.44* �60   �� 5C   "   $
��.20* �60   �� 5D   "   $
��.12* �60   �� 5E   "   $
��.12* �60   �� 5F   "   $
��.12* �60   .+�5I      (� $��0��6&   $��4 4 4 4q�63   .��5J   "   �� -   5        
 ��Name$
 
img_Avatar��5J   (   $��/Images/avatar.png��6<   5K      (� 5M      $��1��6&   .��5N   "   �� -   5         ��Name$ lbl_StudentName��5N   ,   $��Student Name��6E   5O      (� 5Q      $��2��6&   .��5R   "   �� -   5        $ lbl_StudentNumber��5R   ,   $��Student Number��6G   5S      (� 5U      $��3��6&   .��5V   "   �� -   5        $ lbl_GradeLevel��5V   ,   $��Grade Level��6D   5W      (� 5Y      $��4��6&   .��5Z   "   �� -   5        $ lbl_Section��5Z   ,   $��Section��6A   5[      5\      5]      5^      � 5`      $��1��6   $��5q�6$   .+�5a      �� $��Balances��6     MaterialDesignCardGroupBox#���  5b      ��5c      �� 5d      .R�5e   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5f   &   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6>   $��32��5g   >   $��32��5h   >   
�������$��Center=�5j   >   �� 5l   &   $	��8 0q�60   $��Center=�5m   0    % !MaterialDesignSubheadingTextBlock#��[ 5n   0   
���������5p   0   �� 5r   #   5s      .��5u       � -   5          �Name$ 
f_Balances��5u         � NavigationUIVisibility$ Hidden=�5v      $
��Auto��5w      $
��Auto��5x      5y      5z      5{      � 5}      $��1��6    5~      �� 5      $
��.90* �6'   �� 5�      $
��.10* �6'   .+�5�      � $��0��6    5�      �� 5�      $
��.50* �6(   �� 5�      $
��.50* �6(   .+�5�      � $��0��6   $��5q�6(   .+�5�      �� $��Payment Records��6#   #���  5�      ��5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *     $ Account=�6B   $��32��5�   >   $��32��5�   >   
�������$��Center=�5�   >   �� 5�   *   $	��8 0q�64   $��Center=�5�   0   #��[ 5�   0   
���������5�   0   �� 5�   '   5�   #   .��5�      &   System.Windows.Controls.DataGrid  -   5        $��dgv_Payments��5�   '      ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$ *	 5�   '      CanUserSortColumns .    CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  -
  'MaterialDesignThemes.Wpf.DataGridAssist 
  CellPadding$ 13 8 8 8q�5�   '    
  ColumnHeaderPadding$ 8q�5�   '      ClipboardCopyMode$ IncludeHeader=�5�   '      Columns 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,  &System.Windows.Controls.DataGridColumn   Header$	 Fee��6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
fee_type+6V     5�   &   $ Amount��6\    69   �� *payment_amount+6\     5�   &   $ Balance��6W    69   �� *	remaining+6W     5�   &   $ Status��6U    69   �� *	remarks+6U   5�      5�      5�      � 5�      $��1��6   $��5q�6(    5�      �� 5�      $��* �6/   �� 5�      $��* �6/   .+�5�      � $��0��6   .+�5�      �� $��Installments��6'   #���  5�      ��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   .+�5�   .     $ Account=�6F   $��32��5�   >   $��32��5�   >   
�������$��Center=�5�   >   �� 5�   .   $	��8 0q�68   $��Center=�5�   0   #��[ 5�   0   
���������5�   0   �� 5�   +   5�   '   .��5�   "     -   5        $��dgv_Installments��5�   +   $ *	 5�   +    .  .   .  .  $ 13 8 8 8q�5�   +   $ 8q�5�   +   $ IncludeHeader=�5�   +    5�   &     5�   *   $ Number��6W    6=   �� *count+6W     5�   *   $
 Date��6b    6=   �� *installment_date+6b     5�   *   $ Amount��6d    6=   �� *installment_amount+6d   5�   #   5�      5�      � 5�      $��1��6   5�      5�      5�      � 5�      $��1��6   .+�5�      �� $ Vertical=�6!   $��Center=�68   $��Center=�6U   .+�5�      �� -	   5         ��Name$ btn_CurrentPayments��5�   !    * &MaterialDesignFloatingActionDarkButton#��[ 5�   !    � ToolTip$" Current School Year Payments��5�   !   $��5q�5�   !   .��5�        $ Calendar=�66   $��24��5�   6   $��24��5�   6   5�      �� 5�      -
   5        $ btn_ArchivedPayments��5�   !   #��[ 5�   !   $ Archived Payments��5�   !   $��5q�5�   !   .��5�        $ CalendarClock=�66   $��24��5�   6   $��24��5�   6   5�      5�      5�      5�      5�      5�      5�      