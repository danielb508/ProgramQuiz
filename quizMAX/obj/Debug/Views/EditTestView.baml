   M S B A M L   `   `   `  ����B  >quizMAX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:quizMAX.ViewsquizMAX.Views  5           quizMAX.Views.EditTestView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:quizMAX.Views     5      .��5	      �   � ColumnDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   �� 5   
   $��1��6   �� 5   
   $��0��6   .+�5      �� $��10q�6   $��22(�6$   ��62   ��  �� Path$ AvailableTestsLabel��� 5      -   5         ��Name$ Tests��5      $��50,15q�6&   $��18(�65    �� DisplayMemberPath$ Title��6�    �� SelectedItem 6C   �� $ SelectedTest� �� Mode$ OneWayToSource=�6�   5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ 
EditTestOn��5      $��20q�6)   $��5q�65   $��18(�6B   ��6Q   �� $ EditTestButton�{�6y   �� $ EditTestButtonIsEnabled��� 5      -   5        $ 
DeleteTest��5      $��20q�6)   $��5q�65   $��18(�6B   ��6P   �� $ DeleteTestButton�{�6z   �� $ DeleteTestButtonIsEnabled��� 5      -   5        $ 
CreateTest��5      $��20q�6)   $��5q�65   $��18(�6B   ��6Q   �� $ CreateTestButton�5      5       5!      