   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ClienteSistemaTutoriasClienteSistemaTutorias  5   	   5    /ClienteSistemaTutorias.ConsultarHorarioTutorias   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ClienteSistemaTutorias     5   	     � Title$  ConsultarHorarioTutorias��5   	   $	��450��6*   $	��800��67   .��5	      � .+�5
   
   �� -   5         ��Name$ cbTutoriasActuales��5
       �� ItemStringFormat$ 
dd/MM/yyyy��6/    �� DisplayMemberPath$ fechaSesion��6N    �� SelectedValuePath$ idTutoriaAcademica��6n   $
��Left=�6�   $��	72,80,0,0q�6�   $	��Top=�6�   $	��189��6	  �� 5   
   $��
Tutorías:��6   $
��Left=�6$   $��
103,42,0,0q�6?   $	��Top=�6S   �� 5   
   $��Tutores:��6   $
��Left=�6#   $��
382,42,0,0q�6>   $	��Top=�6R   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgHorario��5         AutoGenerateColumns .     CanUserAddRows .  $��562,148,71,68q�6Y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Hora��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6T      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *horaTutoria1+6^   5      �� 5   
   -   5        $ 	cbTutores��5      $ idAcademico��6&   $��Center=�6t   $��0,80,0,0q�6�   $	��Top=�6�   $	��188��6�   ��5      �� 5      .R�5      �� �� 5      �6   �� *nombre+ �� 5      $� ��6    �� 5      �6   �� *apellidoPaterno+ �� 5      $� ��6    �� 5      �6   �� *apellidoMaterno+5      5      5      �� 5   
   -   5        $��Regresar��5      $
��Left=�6$   $��656,383,0,0q�6?   $	��Top=�6T   $��73��6l   6w   �� 5    
   -   5        $��Buscar��5       $
��Left=�6"   $��
540,80,0,0q�6=   $	��Top=�6Q   $��74��6i   6t     5!   
   -   5        $ dgTutorados��5!       .   .  $��72,148,260,68q�6[    5"        5#      $	 Nombre del alumno��6%   $
 * 6[    .  6@   �� *nombre+6e     5$      $	 Apellido paterno��6%   $
 * 6c    .  6?   �� *apellidoPaterno+6m     5%      $	 Apellido materno��6%   $
 * 6c    .  6?   �� *apellidoMaterno+6m   5'      5)      5*      