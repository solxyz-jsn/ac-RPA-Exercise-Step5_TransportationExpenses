   M S B A M L   `   `   `  ���� J  F交通費精算, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:交通費精算交通費精算       交通費精算.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:交通費精算     -     �Name$  WindowMainWindow�� � Title$ 交通費精算��$	��500��$	��800��.��� .+��� -    ��Name$ ButtonNewEntry��$��新規登録��$
��Left=�$��50��$��	45,83,0,0q�$	��Top=�$	��200�����	#FF007BFF
����������	#FF003E7B�� -    ��Name$ lblTitle��$��交通費精算��$
��Left=�$��45,5,0,0q�$	��Top=�$��28(�$
��Bold"�$	��232���� -   $ ButtonClose��$��アプリ終了��$
��Left=�$��50��$��
539,83,0,0q�$	��Top=�$	��200�����	#FFDDDDDD
���   ����	#FF70707B&   System.Windows.Controls.DataGrid  -   $��DataGridExpenses��   
IsReadOnly$
 True��$��45,150,45,80q�   AutoGenerateColumns$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	年月日��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *Date+  $ 経路��$	 200 	 �� *Route+  $ 種別��$	 100 	 �� *
Categories+  $ 行先��$	 190 	 �� *Destination+  $ 金額��$ 50 	 �� *	Expense+
   ElementStyle
 ��  �� 
TargetType" ��.���  �� Property �@��TextAlignment �� Value$ Right=�  $ 登録番号��$ 70 	 �� *	RegNumber+