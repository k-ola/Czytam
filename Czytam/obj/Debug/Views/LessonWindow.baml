   M S B A M L   `   `   `  ����A  =Czytam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Czytam.ViewsCzytam.Views  5   	       Czytam.Views.LessonWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Czytam.Views     5   	     � Icon$  /Resources/Images/man.png��5   	    � Title$ LessonWindow��5	   	   $	��800��6   $
��1000��6.    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�6.    � 
ResizeMode$ 	CanResize=�6F   .��5      �    generalGrid#��[  6   .+�5   
   �� $��Stretch=�6   $��Stretch=�63   $
��1000��6O   $	��800��6_   .@�5      �� -   5         ��Name$ descriptionTab��5   7     tabItem#��[ 6   $��Opis lekcji��6O   .��5      � #��[  6   .+�5      �� -   5         ��Name$% descriptionTabLessonNumberLabel��5   @     
titleLabel#��[ 6   6@   �� 5      -   5         ��Name$  lessonDescriptionTextBlock��5       $��Opis lekcji��6D   
������ J� Opacity$
 0.85Q�6k   $��Center=�6z   $	��Top=�6�   $��	0,160,0,0q�6�   $	��700��6�   $	��300��6�   	 �� TextAlignment$	 Center=�6�   $��Nyala)�6�   $��28(�6  
 �� Padding$
 40,60,40,60q�6  $
��Wrap=�6)  �� 5      -   5          backgroundButton#��[ 5      $��Przejdź do ćwiczeń��6G   $��80��6d   $	��220��6p   $��Center=�6|   $��	0,300,0,0q�6�   $��Nyala)�6�   $��26(�6�   $��Center=�6�   6�   �� 5      -   5          
backButton#��[ 5      $��Zakończ��6Z   5      5      �� 5      -   5        $ syllablesTab��5   7   #��[ 6   $��Sylaby��6M   .��5      � #��[  6   .+�5      �� -   5        $# syllablesTabLessonNumberLabel��5   @   #��[ 6   6@   �� 5      -   5         ��Name$ mainSyllablesStackPanel��5   !   $��Center=�6B   $
��auto��6_   $��	0,170,0,0q�6m   $	��Top=�6�   $
��auto��6�    �� Orientation$ Vertical=�6�   5      5      �� 5      -	   5        $ wordsTab��5   7   #��[ 6   $��Słowa��6I   .��5      � #��[  6   .+�5       �� -
   5        $ wordsTabLessonNumberLabel��5    @   #��[ 6   6@   �� 5!      -   5        $ mainWordsStackPanel��5!   !   $��center=�6>   $
��auto��6[   $��	0,170,0,0q�6i   $	��Top=�6|   $
��auto��6�   5"      5#      5$      5(      5)      