   M S B A M L   `   `   `  ����B  >quizMAX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:quizMAX.ViewsquizMAX.Views  5   	   "    quizMAX.Views.LearnPopUpView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:quizMAX.Views     5   	   $	��450��5   1   $	��800��6>     � WindowStartupLocation$  CenterScreen=�6J    � Title 6	   ��  �� Path$ LearnWindowTitle�.��5	      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6!   �� 5   
   $��2��6   $��0��6!   �� 5   
   $��1��6   $��1��6!   �� 5   
   $��2��6   $��3��6   �� 5   
   $��3��6   $��3��6   �� 5   
   $��0��6   $��0��6$   $��15q�61   $��20(�6=   �� 5       �6   �� $ QuestionLabel� �� 5!      �6   �� $* $LearnMechanism.CurrentQuestionNumber� �� 5"      $�/��6    �� 5#      �6   �� $&  LearnMechanism.AllQuestionNumber�5$      �� 5'   
   $��1��6   $��1��6$   $��18(�61    �� TextAlignment$ Center=�6?   �� 5(      �6   �� $1 +LearnMechanism.CurrentQuestion.QuestionText�5)      �� 5,   
   $��2��6   $��0��6$   $��5q�61   $��20(�6<    �� Padding$ 10q�6J   ��6W   �� $ FeedbackColor��� 5-      �6   �� $ ResultLabel� �� 5.      �6   �� $  LearnMechanism.ResultValue� �� 5/      $�/��6    �� 50      �6   �� $&  LearnMechanism.AllQuestionNumber�51      �� 54   
   $��1��6   $��2��6%   .+�55      �� -   5         ��Name$, &LearnMechanism_CurrentQuestion_Answers��55      $��0, 30q�6F   $��18(�6U    �� SelectionMode$ Multiple=�6�   	 �� DisplayMemberPath$	 Answer��6�   $��Stretch=�6�   {�6c   �� $ AnswersIsEnabled���56      �� 57      
 �� 
TargetType"
 ��6    �� BasedOn# [B��6>   .�58      ��  �� Property �@��
IsSelected �� Value 67   �� *
IsSelected+ �� Mode$ TwoWay=�59      5;      5<      �� 5>   
   $��1��6   $��3��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5?      �� -   5         ��Name$ Confirm��5?      $��5q�6&   $��5q�61   $��18(�6>   {�6L   �� $ ConfirmButtonIsEnabled���6~   �� $ ConfirmButton��� 5@      -   5        $ NextQuestion��5@      $��5q�6+   $��5q�66   $��18(�6C   {�6Q   �� $! NextQuestionButtonIsEnabled���6�   �� $ NextQuestionButton�5A      5B      5C      