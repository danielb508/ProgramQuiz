   M S B A M L   `   `   `  ����B  >quizMAX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:quizMAX.ViewsquizMAX.Views  5   	   ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21fP=clr-namespace:Caliburn.Micro;assembly=Caliburn.Micro.PlatformCaliburn.Micro 5   	   %    quizMAX.Views.EditTestPopUpView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:quizMAX.Views     5   	   Mcal=clr-namespace:Caliburn.Micro;assembly=Caliburn.Micro.Platform     5   	   $	��450��5	   .   $	��900��6;     � WindowStartupLocation$  CenterScreen=�6G    � Title 6	   ��  �� Path$ EditTestTitle�.��5
      �� $��Visible=�6   .��5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   �� 5      $��1��6   �� 5      $��1��6   $��2��6"   �� 5      $��0��6   $��20q�6)   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�66   .+�5      �� $��22(�6    $
��Wrap=�6.   ��6B   �� $ 
TitleLabel��� 5      -   5         ��Name$ 
TitleValue��5      $��18(�62   $	��300��6@    �� TextWrapping$
 Wrap=�6L   5       �� 5!      $ 
Horizontal=�6   $��5q�66   .+�5"      �� $��22(�6    $
��Wrap=�6.   ��6B   �� $ DescriptionLabel��� 5#      -   5        $ DescriptionValue��5#      $��18(�68   $	��200��6F   $	��250��6V   $
 Wrap=�6b   5$      5%      �� 5(      $��1��6   .+�5)      �� $��10q�6   $��22(�6(   ��66   �� $ QuestionsInTestLabel��� 5*      -   5         ��Name$ 	Questions��5*      $��18(�6-   	 �� SelectionMode$	 Multiple=�6<   
 �� DisplayMemberPath$
 QuestionText��6U   $��Stretch=�6v     Caliburn.Micro.Message   Attach$< 6[Event SelectionChanged] = [Action SelectionChanged()]��6�   ��5+      �� 5,       �� 
TargetType" ��6     �� BasedOn# [B��6B   .�5-      ��  �� Property �@��
IsSelected �� Value 6;   �� *
IsSelected+ �� Mode$ TwoWay=�5.      50      51      �� 54      $��1��6   $��Center=�6&   .+�55      �� -   5         ��Name$ Confirm��55      $��5q�6*   $��18(�66   ��6D   �� $ ConfirmEditionButton�{�6r   �� $# ConfirmEditionButtonIsEnabled�56      57      58      59      