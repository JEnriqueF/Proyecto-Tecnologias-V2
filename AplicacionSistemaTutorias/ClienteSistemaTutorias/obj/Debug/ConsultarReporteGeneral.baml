   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ClienteSistemaTutoriasClienteSistemaTutorias  5   	   4    .ClienteSistemaTutorias.ConsultarReporteGeneral   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ClienteSistemaTutorias     5   	     � Title$  ConsultarReporteGeneral��5   	   $	��450��6)   $	��800��66   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgReportes��5
         AutoGenerateColumns .     CanUserAddRows .  $��300,105,300,78q�6Z      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Fecha de tutoría��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6x      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *fechaSesion+	 �� StringFormat$	 
dd/MM/yyyy��6�   5      �� 5   
   -   5        $��Cerrar��5      $
��Left=�6"   $��607,379,0,0q�6=   $	��Top=�6R   $��64��6j   6u   �� 5   
   $%��Reportes generales de tutorías��6   $��Center=�69   $��0,43,0,0q�6V   $	��Top=�6h   $
��Bold"�6�   $��20(�6�   �� 5   
   -   5        $��	Consultar��5      $
��Left=�6%   $��687,379,0,0q�6@   $	��Top=�6U   $��67��6m   6x   5      5      