   M S B A M L   `   `   `  ����B  >quizMAX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:quizMAX.ViewsquizMAX.Views  5           quizMAX.Views.QuizModeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:quizMAX.Views     5      .��5	      �   � ColumnDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   �� 5   
   $��1��6   �� 5   
   $��2��6   �� 5   
   $��0��6   �� 5   
   $��1��6   �� 5   
   $��0��6   $��Center=�6%   .+�5      �� $��22(�6   $��10q�6&   ��62   ��  �� Path$ AvailableTestsLabel��� 5      -   5         ��Name$ Tests��5      $��50,15q�6%   $��18(�64    �� DisplayMemberPath$ Title��6�    �� SelectedItem 6B   �� $ SelectedTest� �� Mode$ OneWayToSource=�6�   5      �� 5"   
   $��1��6   $��Center=�6&   .+�5#      �� $��22(�6   $
��Wrap=�6&   �� 5$      �6   �� $ DescriptionLabel� �� 5%      �6   �� $ SelectedTest.Description�5&      �� 5'      $��22(�6   �� 5(      �6   �� $ NumberOfQuestionsLabel� �� 5)      �6   �� $ NumberOfQuestionsValue�5*      5+      �� 5.   
   $��0��6   $��1��6%   .+�5/      �� $��5,50,5,5q�6    �� Orientation$ 
Horizontal=�6+   .+�50      �� $��22(�6M   ��6   �� $  QuestionNumberForQuizLabel�6M   �� 51      -   5         ��Name$  QuestionNumberForQuizValue��51      $��22(�6>   $	��150��6L   ��6[   �� $* $QuestionNumberForQuizFieldBackground�{�6�   �� $) #QuestionNumberForQuizFieldIsEnabled�52      �� 53      $ 
Horizontal=�6   $��5q�62   .+�54      �� $
��Left=�6   $��22(�67   ��6E   �� $ PercentToPassLabel��� 55      -   5        $ PercentToPassValue��55      $��22(�66   $	��150��6D   ��6S   �� $" PercentToPassFieldBackground�{�6�   �� $! PercentToPassFieldIsEnabled�56      �� 57      $ 
Horizontal=�6   $��5q�62   .+�58      �� $��22(�6   ��6*   �� $ 	TimeLabel��� 59      -   5        $ 	TimeValue��59      $��22(�6-   $	��150��6;   ��6J   �� $ TimeFieldBackground�{�6z   �� $ TimeFieldIsEnabled�5:      5;      �� 5>   
   $��1��6   $��1��6%   $��Center=�62   .+�5?      �� -   5        	 ��Name$	 
QuizModeOn��5?      $��18(�6)   $��5q�67   ��6D   �� $ StartQuizButton�{�6m   �� $ StartQuizIsEnabled�5@      5A      5B      