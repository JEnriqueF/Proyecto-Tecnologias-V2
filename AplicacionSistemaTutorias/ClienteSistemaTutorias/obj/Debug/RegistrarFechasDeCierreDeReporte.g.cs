﻿#pragma checksum "..\..\RegistrarFechasDeCierreDeReporte.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "04B57D155BBBA7DF4F51BA7F4068B57C763A117071E88A5E34672260E1BB96D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ClienteSistemaTutorias;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ClienteSistemaTutorias {
    
    
    /// <summary>
    /// RegistrarFechasDeCierreDeReporte
    /// </summary>
    public partial class RegistrarFechasDeCierreDeReporte : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\RegistrarFechasDeCierreDeReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPeriodos;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\RegistrarFechasDeCierreDeReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpPrimeraEntrega;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RegistrarFechasDeCierreDeReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpSegundaEntrega;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RegistrarFechasDeCierreDeReporte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpTerceraEntrega;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClienteSistemaTutorias;component/registrarfechasdecierredereporte.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistrarFechasDeCierreDeReporte.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbPeriodos = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.dpPrimeraEntrega = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.dpSegundaEntrega = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.dpTerceraEntrega = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            
            #line 19 "..\..\RegistrarFechasDeCierreDeReporte.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicCancelar);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 20 "..\..\RegistrarFechasDeCierreDeReporte.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicAceptar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
