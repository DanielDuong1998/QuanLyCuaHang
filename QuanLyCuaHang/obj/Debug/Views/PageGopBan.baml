   M S B A M L   `   `   `  ����H  DQuanLyCuaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:QuanLyCuaHang.ViewModelsQuanLyCuaHang.ViewModels  5           QLCuaHang.Views.PageGopBan   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:QuanLyCuaHang.ViewModels     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5          �Name$  Wgopban��5      $	��130��5      $	��500��6    � WindowStyle$
 None=�6    � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ NoResize=�6W    � Title$ 
PageGopBan��5	         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � DataContext 5      2   ,QuanLyCuaHang.ViewModels.KhuVucBanViewModels  5   
   6&   .��5      � ���#b8b894 � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   � $��0��6   	 � ColumnDefinitions	 5      �� 5      6%   �� 5      6%   .+�5      � $��5,5,5,5q�6   $��0��6$    5       �� 5!      $
��Auto �6$   64   �� 5"      $
��Auto �6$   64   .+�5$      �� $��Center=�6   $��Segoe UI)�6<   $��15(�6R   $
��Bold"�6`   
����  �$��Chọn bàn cần gộp��6�   6�   �� 5%      
 �� DisplayMemberPath$
 TENBAN��6�   $��1��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Chọn bàn��6�   ��6   �� *
BanMuonGop+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6n   �� *SelectedBanMuonGop+$ OneWayToSource=�6  5&      � 5'      $��5,5,5,5q�6   $��1��6$    5(      �� 5)      $
��Auto �6$   64   �� 5*      $
��Auto �6$   64   .+�5,      �� $��Center=�6   $��Segoe UI)�6<   $��15(�6R   $
��Bold"�6`   
����  �$��
Bàn gộp��6�   6�   �� 5-      $
 TENBAN��6�   $��1��6�   $ Chọn bàn��6�   ��6   �� *
BanDcGop+$ TwoWay=�$ PropertyChanged=� 6l   �� *SelectedBanDcGop+$ OneWayToSource=�6�   5.      5/      � 50   
   $��1��6   	 51      �� 52      6%   �� 53      6%   .+�55      �� $��Segoe UI)�6h   $��15(�6~   $
��Bold"�6�   
���   �$��Gộp��6�    $  MaterialDesignRaisedAccentButton#��[ 6�   $��5,5,5,5q�6�   $��0��6
  ��6   �� *XacNhanGopBan+��67   ��  �� ElementName$ Wgopban��6  �� 56      -   5         ��Name$ btnthoat��56      $��Segoe UI)�6>   $��15(�6T   $
��Bold"�6b   
���   �$��Thoát��6�   #��[ 6�   $��5,5,5,5q�6�   $��1��6�   6�   57      58      5:      