   M S B A M L   `   `   `  ����Q  MSystem.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;,clr-namespace:System.Xml;assembly=System.Xml
System.Xml  5       	HL7Parser"   HL7Parser.Controls.XmlViewer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Axmlstack,clr-namespace:System.Xml;assembly=System.Xml     5        � 	Resources  5	       �� Color   xmlValueBrush  xmAttributeBrush  xmlTagBrush  xmlMarkBrush  attributeTemplate �� Orientation �� Path �� 
TargetType �� Property �� Value  treeViewTemplate �� ItemsSource �� XPath	 ��Name
 �� Triggers �� Binding �� Value   System.Xml.XmlNodeType �� 
TargetName��%�  &	        &	 #     &	 E     &	 o     &	 �     7  7  7   7  'Q� �    &	     7  7  7  7  �� 5
      $
 Blue��6   6!   �� 5      $	 Red��6   6    �� 5      $ DarkMagenta��6   6(   �� 5      $
 Blue��6   6!   �� 5      .R�5      �� $ 
Horizontal=�6   $��3,0,0,0q�5      $��Center=�6*   .+�5      �� 8��  ��6   �� $
 Name�5      �� 5      $��="��6   8�� 5      �� 5      8�� ��6   �� $ Value�5      �� 5      $��"��6   8�� 5      5      5      �� 5      " Q�6
   .�5      ��  �@Q�
IsExpanded . 6"   5      �� 5!       5"   #   �� $ child::node()��.R�5#      �� $ 
Horizontal=�6   $��3,0,0,0q�6)   $��Center=�5$      .+�5%      �� $	 startTag��5'      $��<��5%      $��Center=�6   8��  5'      �� 5)      $	 xmlTag��5,      $��0q�5*      $��Center=�5+      8�� ��5)      �� $
 Name�5-      �� 5/      8�� $��Center=�52      ��51      �� $ 
Attributes���53      �� 54      .R�55   	   �� $ 
Horizontal=�6   56   	   58      �� 5:      $	 endTag��5<      $��>��5:      $��Center=�6   8�� 5<      5=      
 5?      �� 5@       6   �� *
NodeType+ 5A       5B      Text=�6#   .a�5D      �� $ xmlTag��5E       5D      �� *	InnerText+ � ��5E      �� 5F      $ xmlTag��5G       � ��
 ��  ��� 5H      $ startTag��5I       � y�$ 	Collapsed=�5H   $   5I      �� 5J      $ endTag��5K       � y�$ 	Collapsed=�5J   $   5K      5L      �� 5N      $ False��64    6   �� *HasChildNodes+.a�5O      �� $ endTag��6,    � ��$ />��6   6,   5P      5R      5S      .��5U      � .+�5V      R� -   5        $��xmlTree��5V   .   $��2��6   $��2��6   #��[ 5W      5X      5Y      