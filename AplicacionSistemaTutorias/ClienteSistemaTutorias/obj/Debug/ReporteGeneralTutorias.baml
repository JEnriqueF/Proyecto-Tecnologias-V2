   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ClienteSistemaTutoriasClienteSistemaTutorias  5   	   3    -ClienteSistemaTutorias.ReporteGeneralTutorias   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ClienteSistemaTutorias     5   	     � Title$  ReporteGeneralTutorias��5   	   $	��450��6(   $	��800��65   .��5	      � .+�5
   
   �� $,��&Problemáticas académicas detectadas:��6   $��Center=�6?   $��0,40,0,0q�6\   $	��Top=�6n   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgProblematicas��5         AutoGenerateColumns .     CanUserAddRows .  $��379,71,38,235q�6_      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Problemática académica��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6e      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *descripcion+6o     5      $ Número de incidencias��6%   $	 131 6j    .  6D   �� *numeroIncidencias+6v   5        5   
   -   5        $ dgExperiencias��5       .   .  $��38,71,426,235q�6^    5        5      $ Experiencia educativa��6%   $ * 6_    .  6D   �� *titulo+6i   5      �� 5   
   $��Comentarios generales:��6   $��Center=�61   $��	0,199,0,0q�6N   $	��Top=�6a   $
��Bold"�6y     5   
   -   5        $ 	dgTutores��5       .   .  $��38,230,426,62q�6Y   	 J� RenderTransformOrigin$	 0.5,0.5&�6p    5        5      $ Nombre tutor��6%   $ * 6V    . 
   CanUserResize
 .  6;   �� *nombre+6r     5      $ Apellido paterno��6%   $ * 6c    . 
 .  6?   �� *apellidoPaterno+6     5      $ Apellido materno��6%   $ * 6c    . 
 .  6?   �� *apellidoMaterno+6   5!        5"   
   -   5        $ dgComentario��5"       .   .  $��379,230,38,62q�6\   $	 0.5,0.5&�6s    5#        5$      $ Comentarios��6%   $ * 6Z    . 
 .  6:   �� *descripcion+6v   5&      �� 5'   
   -   5        $��Regresar��5'      $
��Left=�6$   $��697,388,0,0q�6?   $	��Top=�6T   $��65��6l   6w   �� 5(   
   $��Asistencia total:��6   $
��Left=�6,   $��	38,40,0,0q�6G   $	��Top=�6Z   $
��Bold"�6r   �� 5)   
   -   5         ��Name$ lbAsistencia��5)      $
��Left=�6E   $��
137,40,0,0q�6`   $	��Top=�6t   ��6&   �� *
asistencia+6t   5+      5,      