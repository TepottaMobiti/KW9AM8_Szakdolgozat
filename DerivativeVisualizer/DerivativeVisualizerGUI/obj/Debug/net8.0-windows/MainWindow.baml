   M S B A M L   `   `   `  ����R  NDerivativeVisualizerGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:DerivativeVisualizerGUIDerivativeVisualizerGUI  5   	   (    "DerivativeVisualizerGUI.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:DerivativeVisualizerGUI     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	      '   !DerivativeVisualizerGUI.ViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��	0,10,0,10q�6X   .+�5      �� $	��200��5      $��30��6    �� 	MaxLength$ 20��5      $��20(�5       �� 	UndoLimit$ 98��5      ��5      �� *	InputText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $��30��6   $��30��6    $��10,0,0,0q�6,    �� CornerRadius$ 5��5      ��5      �� *
InputValid+   BooleanToBrushConverter	 �� 	Converter#	 [  ._�5      �� $��16(�5       $
��Bold"�6"   
�������
 �� TextAlignment$
 Center=�5!   '   $��Center=�5"      $��Center=�6/   ��5      �� *
InputValid+  BooleanToCheckConverter#	 [ 5"   /   5#      �� 5%      $��?��6   $��30��6!   $��30��6,   $��5,0,0,0q�68   y�5&      �� *
InputValid+   BooleanToVisibilityConverter#	 [  �� ConverterParameter$ False����5'      �� *ToggleErrorMessageCommand+�� 5*      
���  ��$��5,0,0,0q�5,      ��5*      �� *ErrorMessage+y�5+      �� *ShowErrorMessage+#	 [ 5,      5-      �� 50   
   $��1��6   $
��Auto=�51      $
��Auto=�52      y�53      �� *TreeToPresent+  NullToVisibilityConverter#	 [ .��54      ,   &DerivativeVisualizerGUI.BinaryTreeView  
�������   TreeToPresent 6#   �� *TreeToPresent+ 6^   �� 55      56      57      