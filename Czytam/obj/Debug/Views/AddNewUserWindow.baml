   M S B A M L   `   `   `  ����A  =Czytam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Czytam.ViewsCzytam.Views  5   	   #    Czytam.Views.AddNewUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Czytam.Views     5   	     � Icon$  /Resources/Images/man.png��5   	    � Title$ Dodaj nowego Czytelnika��5	   	   $	��800��6)   $
��1000��69    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�6.    � 
ResizeMode$ 	CanResize=�6F   .��5      �    generalGrid#��[  6   .+�5   
   ��   
titleLabel#��[ 6   $��Dodaj nowego Czytelnika��64   �� 5      -   5         ��Name$ firstNameTextBox��5      $��Center=�61   $��60��6N   $��
0,-270,0,0q�6Z    �� TextWrapping$
 Wrap=�6n   $��Center=�6�   $	��400��6�   $��Nyala)�6�   $��30(�6�   
�������6�   �� 5      $��Imię��6   $��center=�6#   $��Center=�6@   $��-350,-185,0,0q�6[   $��Nyala)�6r   $��20(�6�   $��Italic$�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dateOfBirthDatePicker��5      $��Center=�65   $��60��6R   $��	0,-40,0,0q�6^   $��Center=�6q   $	��400��6�   $��Nyala)�6�   $��24(�6�      SelectedDateFormat$
 Long=�6�   
�������6�   �� 5   
   $��Data urodzenia��6   $��center=�6)   $��Center=�6F   $��-270,40,0,0q�6a   $��Nyala)�6v   $��20(�6�   $��Italic$�6�   �� 5   
   -   5          backgroundButton#��[ 5      $��Zapisz��6Z   $��Center=�6k   $��
0,0,0,-200q�6�   $��Center=�6�   $	��150��6�   $��50��6�   $��Nyala)�6�   $��22(�6�   �� 5   
   -   5          
backButton#��[ 5      65   5      5      