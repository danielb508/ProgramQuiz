   M S B A M L   `   `   `  ����B  >quizMAX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:quizMAX.ViewsquizMAX.Views  5      !    quizMAX.Views.LearnModeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:quizMAX.Views     5      .��5	      �   � ColumnDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   �� 5   
   $��1��6   �� 5   
   $��1��6   $��2��6   �� 5   
   $��0��6   $��Center=�6%   .+�5      �� $��10q�6   $��22(�6%   ��63   ��  �� Path$ AvailableTestsLabel��� 5      -   5         ��Name$ Tests��5      $��50, 15q�6%   $��18(�65    �� DisplayMemberPath$ Title��6�    �� SelectedItem 6C   �� $ SelectedTest� �� Mode$ OneWayToSource=�6�   5      �� 5   
   $��1��6   $��Center=�6%   .+�5       �� $��22(�6   $
��Wrap=�6'   �� 5!      �6   �� $ DescriptionLabel� �� 5"      �6   �� $ SelectedTest.Description�5#      �� 5$      $��22(�6   �� 5%      �6   �� $ NumberOfQuestionsLabel� �� 5&      �6   �� $ NumberOfQuestionsValue�5'      5(      �� 5*   
   $��1��6   $��2��6"   $��Center=�66   .+�5+      �� -   5         ��Name$ LearnModeOn��5+      $��10, 50q�6*   $��5q�6:   $��18(�6G   ��6U   �� $ StartLearningButton�{�6�   �� $ StartLearnButtonIsEnabled�5,      5-      5.      