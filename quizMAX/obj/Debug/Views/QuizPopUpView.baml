   M S B A M L   `   `   `  ����B  >quizMAX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:quizMAX.ViewsquizMAX.Views  5   	   !    quizMAX.Views.QuizPopUpView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:quizMAX.Views     5   	   $	��450��5   8   $	��800��6E     � WindowStartupLocation$  CenterScreen=�6Q    � Title 6   ��  �� Path$ QuizWindowTitle�.��5	      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6!   �� 5   
   $��2��6   $��0��6!   �� 5   
   $��1��6   $��1��6!   �� 5   
   $��2��6   $��3��6   �� 5   
   $��3��6   $��3��6   �� 5   
   $��4��6   $��1��6   �� 5!   
   $��0��6   $��0��6$   $��20(�61   $��15q�6?   �� 5"      �6   �� $ QuestionLabel� �� 5#      �6   �� $) #QuizMechanism.CurrentQuestionNumber� �� 5$      $�/��6    �� 5%      �6   �� $% QuizMechanism.AllQuestionNumber�5&      �� 5)   
   $��1��6   $��1��6$   $��18(�61    �� TextAlignment$ Center=�6?   �� 5*      �6   �� $0 *QuizMechanism.CurrentQuestion.QuestionText�5+      �� 5.   
   $��2��6   $��0��6$   $��20(�61   $��15q�6?   �� 5/      �6   �� $ TimeLeftLabel� �� 50      �6   �� $ TimeLeftValue�51      �� 54   
   $��1��6   $��2��6%   .+�55      �� -   5         ��Name$+ %QuizMechanism_CurrentQuestion_Answers��55      $	��200��6E   $��18(�6U    �� SelectionMode$ Multiple=�6c    �� DisplayMemberPath$ Answer��6|   $��Stretch=�6�   ��56      �� 57      	 �� 
TargetType"	 ��6   
 �� BasedOn#
 [B��6>   .�58      ��  �� Property �@��
IsSelected �� Value 67   �� *
IsSelected+ �� Mode$ TwoWay=�59      5;      5<      �� 5?   
   $��1��6   $��3��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5@      �� -   5         ��Name$ PreviousQuestion��5@      $��18(�6/   $��5q�6=   $��5q�6I   {�6T   �� $% PreviousQuestionButtonIsEnabled���6�   �� $ PreviousQuestionButton��� 5A      -   5        $ NextQuestion��5A      $��18(�6+   $��5q�69   $��5q�6E   {�6P   �� $! NextQuestionButtonIsEnabled���6�   �� $ NextQuestionButton�5B      �� 5E   
   $��1��6   $��4��6%   $��Center=�62   .+�5F      �� -   5        $ EndQuiz��5F      $��18(�6&   $��5q�64   $��5q�6@   {�6K   �� $ EndQuizButtonIsEnabled���6}   �� $ EndQuizButton�5G      5H      5I      