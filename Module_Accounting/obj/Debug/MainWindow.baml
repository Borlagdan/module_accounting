   M S B A M L   `   `   `  ����L  HModule_Accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Module_AccountingModule_Accounting  5	   	   "    Module_Accounting.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:Module_Accounting  5	   	   -   5           MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowState$ 	Maximized=�6Z    � WindowStyle$
 None=�6r   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   � $��0��6   
���W�.�.+�5      �  � ColumnDefinitions 5      �� 5      $
��.15* �6'   �� 5      $
��.85* �6'   .+�5       � $��0��6   $��2q�6'   .+�5!      (� .��5"      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6>   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:1.2X�.��5#      �� $
��Auto��6$   $
��Auto��62   $��/Images/logo.png��6?   6[   5$      5%      5&      � 5(      $��1��6   .+�5)      (� $
��Left=�6   .��5*         6>     *SlideInFromRight+$ 0:0:1.2X�.��5+      �� 
������� �� Padding$ 5 5 5 5q�6;   $(��"Christian Centre School Foundation��6M   5,      5-      5.      5/      50      � 52   
   $��1��6    53      �� 54      $
��.30* �6    �� 55      $
��.70* �6    .+�58      � $��0��6    59      �� 5:      $��* �6'   �� 5;      $��* �6'   �� 5<      $��* �6'   �� 5=      $��* �6'   .+�5@      � $��0��6   .+�5A         6:     *SlideInFromLeft+$ 0:0:1.2X�.��5B      �� $��Total Students��6#     MaterialDesignCardGroupBox#���  5C      $��10q�5D      ��5E      �� 5F   "   .R�5G   &   �� 	 �� Orientation$	 
Horizontal=�61   .+�5H   *   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]
   Kind$
 Account=�6B   $��32��5I   >   $��32��5J   >   
�������$��Center=�5L   >   �� 5N   *   $	��8 0q�64   $��Center=�5O   0    % !MaterialDesignSubheadingTextBlock#��[ 5P   0   
���������5R   0   �� 5T   '   5U   #   .��5W      (� .��5X   "   �� -   5         ��Name$ lbl_TotalStudents��5X   ,   $��0��5Y   (   5[      5\      5]      5^      � 5`      $��1��6   .+�5a         6:     *SlideInFromLeft+$ 0:0:1.2X�.��5b      �� $��Paid Students��6#   #���  5c      $��10q�5d      ��5e      �� 5f   "   .R�5g   &   �� $	 
Horizontal=�61   .+�5h   *     $
 AccountCheck=�6B   $��32��5i   >   $��32��5j   >   
�������$��Center=�5l   >   �� 5n   *   $	��8 0q�64   $��Center=�5o   0   #��[ 5p   0   
���������5r   0   �� 5t   '   5u   #   .��5w      (� .��5x   "   �� -   5        $ lbl_PaidStudents��5x   ,   $��0��5y   (   5{      5|      5}      5~      � 5�      $��2��6   .+�5�         6:     *SlideInFromRight+$ 0:0:1.2X�.��5�      �� $��Unpaid Students��6#   #���  5�      $��10q�5�      ��5�      �� 5�   "   .R�5�   &   �� $	 
Horizontal=�61   .+�5�   *     $
 AccountAlert=�6B   $��32��5�   >   $��32��5�   >   
�������$��Center=�5�   >   �� 5�   *   $	��8 0q�64   $��Center=�5�   0   #��[ 5�   0   
���������5�   0   �� 5�   '   5�   #   .��5�      (� .��5�   "   �� -   5        $ lbl_UnPaidStudents��5�   ,   $��0��5�   (   5�      5�      5�      5�      � 5�      $��3��6   .+�5�         6:     *SlideInFromRight+$ 0:0:1.2X�.��5�      �� $��Collection Today��6#   #���  5�      $��10q�5�      ��5�      �� 5�   "   .R�5�   &   �� $	 
Horizontal=�61   .+�5�   *     $

 Cash=�6B   $��32��5�   >   $��32��5�   >   
�������$��Center=�5�   >   �� 5�   *   $	��8 0q�64   $��Center=�5�   0   #��[ 5�   0   
���������5�   0   �� 5�   '   5�   #   .��5�      (� .��5�   "   �� -   5        $ lbl_CollectionToday��5�   ,   $��0��5�   (   5�      5�      5�      5�      5�      � 5�      $��1��6   .+�5�         66     *FadeIn+$ 0:0:1.2X�.��5�      &   System.Windows.Controls.DataGrid  -   5        $��dgv_Records��5�      $��10q�5�         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5�         CanUserSortColumns .    CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5�         ColumnHeaderPadding$ 8q�5�         ClipboardCopyMode$ IncludeHeader=�5�         Columns 5�      0	  *System.Windows.Controls.DataGridTextColumn	  5�      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Grade Level��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *grade_level+	  5�      $ Section��61    6B   �� *	section+	  5�      $ Student Number��61    6I   �� *student_number+	  5�      $ 	Last Name��61    6D   �� *	last_name+	  5�      $ 
First Name��61    6E   �� *
first_name+4  .System.Windows.Controls.DataGridTemplateColumn  5�       
  HeaderTemplate 5�   "   �� 5�   &   .R�5�   *   �� $��Options��64   5�   '      CellTemplate 5�   "   �� 5�   &   .R�5�   *   �� $	 
Horizontal=�65   .+�5�   .   ��  ��Name$ btn_View��5�   -   -   5        $��5q�5�   5   $��32��5�   -   $��32��5�   -    * &MaterialDesignFloatingActionDarkButton#��[ 5�   -    � ToolTip$ View Record��5�   -   $��Right=�5�   -   .��5�   2     $	
 Eye=�6J   $��24��5�   *   $��24��5�   *   5�   /   �� 5�   .   $ 
btn_Update��5�   -   -   5        $��5q�5�   5   $��32��5�   -   $��32��5�   -   #��[ 5�   -   $ Update Record��5�   -   $��Right=�5�   -   .��5�   2     $
 Pencil=�6J   $��24��5�   *   $��24��5�   *   5�   /   5�   +   5�   '   5�      5�      5�      5�      5�      5      5     