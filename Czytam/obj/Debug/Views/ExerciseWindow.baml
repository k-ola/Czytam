   M S B A M L   `   `   `  ����A  =Czytam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Czytam.ViewsCzytam.Views  5   	   !    Czytam.Views.ExerciseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Czytam.Views     5   	     � Icon$  /Resources/Images/man.png��5   	    � Title$ 
Ćwiczenie��5	   	   $	��800��6   $
��1000��6+    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�6.    � 
ResizeMode$ 	CanResize=�6F   .��5      �    generalGrid#��[  6   .+�5   
   �� -   5         ��Name$ exerciseNumberLabel��5   4     
titleLabel#��[ 6   64   � 5   
   -   5         �Name$  syllablesButtonsStackPanel��5   -    � Orientation$ 
Horizontal=�6   $��Stretch=�6Q   $	��110��6o   $	��Top=�5   "   $
��auto��6:   $��120,190,120,0q�6G   �� 5   
   -   5         ��Name$ nextExerciseButton��5   =     nextExerciseButton#��[ 6   $y�Hidden=�6z   �� 5   
   -   5          
backButton#��[ 5      $��Zakończ��6N   �� 5   
   -   5        $ nextLessonButton��5   ;     nextLessonButton#��[ 6   $y�Hidden=�6U   6i   �� 5      -   5        	 ��Name$"	 exerciseDescriptionTextBlock��5      $��center=�6>   $
��auto��6[   $
��Wrap=�6i   $	��Top=�6}   $��	0,300,0,0q�6�   $	��700��6�   
 �� TextAlignment$
 center=�6�   $��Nyala)�6�   $��24(�6�   �� 5      -   5        $	 syllablesTextBox��5      $��Center=�62   $
��Wrap=�6O   $1��+Tu pojawią się sylaby, które wybrałeś.��6c   $	��Top=�6�   $��80��6�   $
 Center=�6�   
������ J� Opacity$	 0.8Q�6�    �� Padding$ 10,25,10,15q�6�   $��	0,490,0,0q�6  $��Nyala)�6  $��28(�6*  $	��500��68  �� 5      -   5        $ checkButton��5   :     checkButton#��[ 6   6O   �� 5   
   -	   5        $ deleteButton��5   7     deleteButton#��[ 6   $y�Hidden=�6h   {�.  6|   �� 5   
   -
   5         ��Name$! wordsSoundButtonsStackPanel��5   .    �� Orientation$ 
Horizontal=�6   $��center=�6S   $��62��6p   $��	0,420,0,0q�6|   $	��Top=�6�   $
��auto��6�   5       5!      