   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ClienteSistemaTutoriasClienteSistemaTutorias  5   	   4    .ClienteSistemaTutorias.RegistrarFechasTutorias   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ClienteSistemaTutorias     5   	     � Title$  RegistrarFechasTutorias��5   	   $	��450��6)   $	��800��66   .��5	      � .+�5
   
   �� $$��Fechas de sesión de tutorías��6   $��Center=�67   $��0,64,0,0q�6T   $	��Top=�6f   $
��Bold"�6~   $��22(�6�   �� 5   
   $��Periodo escolar:��6   $
��Left=�6+   $��251,152,0,0q�6F   $	��Top=�6[   �� 5   
   -   5         ��Name$ 
cbPeriodos��5       �� DisplayMemberPath$ titulo��6'    �� SelectedValuePath$ idPeriodoEscolar��6B    �� Text$ Selecciona un periodo��6�   $
��Left=�6�   $��355,156,0,0q�6�   $	��Top=�6�   $	��194��6  �� 5   
   $ ��Fecha de primera tutoría:��6   $
��Left=�64   $��
80,208,0,0q�6O   $	��Top=�6c   �� 5   
   $ ��Fecha de tercera tutoría:��6   $
��Left=�64   $��565,208,0,0q�6O   $	��Top=�6d   �� 5   
   $ ��Fecha de segunda tutoría:��6   $��Center=�64   $��	0,208,0,0q�6Q   $	��Top=�6d   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpPrimeraTutoria��5      $
��Left=�6/   $��
80,239,0,0q�6J   $	��Top=�6^     5   
   -   5        $ dpSegundaTutoria��5      $��Center=�6/   $��	0,234,0,0q�6L   $	��Top=�6_     5   
   -   5        $ dpTerceraTutoria��5      $
��Left=�6/   $��565,234,0,0q�6J   $	��Top=�6_   �� 5   
   -   5        $��Cancelar��5      $
��Left=�6$   $��552,365,0,0q�6?   $	��Top=�6T   $��69��6l   6w   �� 5   
   -   5        $��	Siguiente��5      $
��Left=�6%   $��639,365,0,0q�6@   $	��Top=�6U   $��66��6m   6x   5      5      