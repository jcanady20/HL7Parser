   M S B A M L   `   `   `  ����  	HL7Parser    HL7Parser.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
HL7 Parser��5   	   $	��550��5      $	��725��5      .��5      � $��Stretch=�6   $��Stretch=�6)   .+�5	      �� -   5        $��Stretch=�5	      $��Stretch=�6-   .@�5
      �� -   5         ��Name$ Editor��5
      ��5      �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $"��Images/126_Edit_24x24_72.png��6   $��23��64   $��23��6@   �� 5      $��Editor��6   $��Center=�6    $��
3, 0, 0, 0q�6;   $
��Bold"�6O   5      .��5      �  � RowDefinitions 5      �� 5      $��28 �6   �� 5      $��* �6   .+�5      c� $��0��6    `� IsLocked . .@�5      �� -   5         ��Name$ btnOpenFile��5      $��23��6$   $��23��6/    � ToolTip$ 	Open File��6;   .��5   	   �� $#��Images/OpenSelectedItemHS.png��6   5   	   �� 5      -   5        $ btnSave��5      $��23��6    $��23��6+   $ 	Save File��67   .��5   	   �� $*��$Images/Editor/base_floppydisk_32.png��6   5   	   �� 5      -   5        $ btnFind��5      $��23��6    $��23��6+   $
 Find��67   .��5   	   �� $��Images/Editor/Find_VS.png��6   5   	   �� 5       -   5        $ btnParseMessage��5       $��23��6(   $��23��63   $ 
Parse File��6?   .��5!   	   �� $'��!Images/Editor/RelationshipsHS.png��6   5"   	   5#      �� 5$      -   5         ��Name$ txtbxMessage��5$      $��1��6%    �� TextWrapping$ NoWrap=�62   "	 �� VerticalScrollBarVisibility$
	 Auto=�6H   $
 �� HorizontalScrollBarVisibility$

 Auto=�6k    �� AcceptsReturn . 6�   5&      5'      �� 5(      -   5        $ ParseResults��5(      ��5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $,��&Images/XSDSchema_GoToGraphViewCmd2.png��6   $��23��6>   $��23��6J   �� 5,      $��Parser��6   $��Center=�6    $��
3, 0, 0, 0q�6;   $
��Bold"�6O   5-      .��5/      �  � ColumnDefinitions 50      �� 51      $��* �6   .+�53      R� -	   5         R�Name$ trvOverView��53      $��6,6,6,6q�6%   $��Stretch=�66   $��Stretch=�6T   $��0��6p   ��54      �� 55   	    �� ItemsSource 6"   �� *
Children+.R�56   
   �  57      �� 58      �� 59      �� 5:      �� 5;      .+�5=      �� $
��Bold"�6O   $��0��6a   $��3q�6q   ��6   �� *Id+ �� FallbackValue$  �� �� TargetNullValue$  ��6q   �� 5>      $
��Bold"�6@   $��1��6R   $��3q�6b   ��6   �� *Name+ �� StringFormat$
 >{0}��6b   �� 5?      $��2��6.   $��3q�6>   ��6   �� *	Content+6>   �� 5@      $��3��62   $��3q�6B   ��6   �� *Description+6B   5A      5B   
   5D      5E      5F      �� 5G      -
   5        $ DataSources��5G      ��5H      �� 5I      $ 
Horizontal=�6   .+�5J      �� $!��Images/base_cylinder_32.png��6   $��23��63   $��23��6?   �� 5K      $��Data Source��6   $��Center=�6%   $��
3, 0, 0, 0q�6@   $
��Bold"�6T   5L      .��5N      �  5O      �� 5P      $��32 �6   �� 5Q      $��* �6   .+�5S      � $	��Top=�6   .+�5T      �� $ 
Horizontal=�6   .+�5U   	   �� -   5        $ btnRefreshSDataSource��5U      $��23��6/   $��23��6:   $
��Left=�6F   $��3q�6b   #��[" �6�   .��5V   	   �� $��Images/RepeatHS.png��6   5W   	   �� 5X      $��4��6   $
��Left=�6   �� 5Y   	   $��DataSources:��6   $��Center=�6'   $��3q�6C   �� 5Z   	   -   5         ��Name$ cmbxDataSources��5Z      $	��120��6+    �� SelectedIndex$ 0��67   $��3q�6I   $��23��6T   #��["�6`   .@�5[   
   �� $��HL7 2.3��6   �� 5\   
   $��HL7 2.5��6   5]   
   5^   	   �� 5_      $ 
Horizontal=�6   $��Right=�6,   .+�5`   	   �� -   5        $ btnSelectSearchColumns��5`      $��23��60   $��23��6;   $��3,0,0,0q�6G   #��[" �6}   .��5a   
   �� $ 
Horizontal=�6   .+�5b      �� $��Images/ZoomHS.png��6   5c      5d   
   �� 5e   	   -   5        $ txtbxDataSourceSearch��5e      $��23��60   $	��150��6<   $��1q�6H   
���   �$��3q�6p   6{   5f   	   5g      &   System.Windows.Controls.DataGrid  5h      -   5          Name$ dgDataSourceView��5h      $��1��6      AutoGenerateColumns .     RowHeaderWidth$ 0Q�6S      
IsReadOnly .    Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5j   	   ,  &System.Windows.Controls.DataGridColumn   Header$ Segment��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *	Segment+  5k   	   $	 Seq��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 45 6F    6)   �� *
Sequence+6F     5l   	   $ Description��6   $ * 6Q    61   �� *Description+6Q     5m   	   $ Length��6    6,   �� *Length+  5n   	   $ 
Repeatable��6    60   �� *
Repeatable+5p      5q      5r      �� 5s      -   5        $ SnoopTab��5s      ��5t      �� 5u      $ 
Horizontal=�6   .+�5v      �� $��Images/iNetwork.png��6   $��23��6+   $��23��67   �� 5w      $��Nextwork Snoop��6   $��Center=�6(   $��
3, 0, 0, 0q�6C   $
��Bold"�6W   5x      .��5z      � -   5         �Name$ SnoopContent��5z      6#   5{      5|      5}      5~      