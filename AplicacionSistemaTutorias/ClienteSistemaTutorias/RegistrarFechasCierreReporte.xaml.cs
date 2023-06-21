using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Windows;

namespace ClienteSistemaTutorias {
    /// <summary>
    /// Lógica de interacción para RegistrarFechasCierreReporte.xaml
    /// </summary>
    public partial class RegistrarFechasCierreReporte : Window {
        private DateTime primeraTutoria, segundaTutoria, terceraTutoria, fechaFin;
        private int idPeriodoSeleccionado;
        private Academico academicoLogeado;

        public RegistrarFechasCierreReporte(DateTime primeraTutoria, DateTime segundaTutoria, DateTime terceraTutoria, DateTime fechaFin, int idPeriodo, 
            string periodoEscolar, Academico academicoLogeado) {
            InitializeComponent();

            this.primeraTutoria = primeraTutoria;
            this.segundaTutoria = segundaTutoria;
            this.terceraTutoria = terceraTutoria;
            this.idPeriodoSeleccionado = idPeriodo;
            this.fechaFin = fechaFin;
            lbPeriodoEscolar.Content = periodoEscolar;
            lbPrimeraTutoria.Content = primeraTutoria;
            lbSegundaTutoria.Content = segundaTutoria;
            lbTerceraTutoria.Content= terceraTutoria;
            this.academicoLogeado = academicoLogeado;
        }

        private void clicGuardar(object sender, RoutedEventArgs e) {
            if(dpPrimeraEntrega.SelectedDate is null || dpSegundaEntrega.SelectedDate is null || dpTerceraEntrega.SelectedDate is null) {
                MessageBox.Show("Debe elegir las 3 fechas antes de continuar.");
                return;
            }

            if( !(dpPrimeraEntrega.SelectedDate > primeraTutoria && dpPrimeraEntrega.SelectedDate < segundaTutoria) ) {
                MessageBox.Show("La primera fecha de entrega no es válida. Verifique e inténtelo de nuevo.");
                return;
            }

            if( !(dpSegundaEntrega.SelectedDate > segundaTutoria && dpSegundaEntrega.SelectedDate < terceraTutoria) ) {
                MessageBox.Show("La segunda fecha de entrega no es válida. Verifique e inténtelo de nuevo.");
                return;
            }

            if( !(dpTerceraEntrega.SelectedDate > terceraTutoria && dpTerceraEntrega.SelectedDate < fechaFin) ) {
                MessageBox.Show("La tercera fecha de entrega no es válida. Verifique e inténtelo de nuevo.");
                return;
            }

            Service1Client fechasCliente = new Service1Client();
            MensajeGenerico mensaje = fechasCliente.registrarFechasTutorias(primeraTutoria, segundaTutoria, terceraTutoria, (DateTime) dpPrimeraEntrega.SelectedDate,
                (DateTime) dpSegundaEntrega.SelectedDate, (DateTime) dpTerceraEntrega.SelectedDate, idPeriodoSeleccionado);

            if (!mensaje.error) {
                Service1Client actualizacionPeriodo = new Service1Client();
                bool periodoActualizado = actualizacionPeriodo.actualizarTutoriasEnPeriodo(idPeriodoSeleccionado);

                if (periodoActualizado == true) {
                    MessageBox.Show("Fechas de tutorías guardadas");

                    MenuCoordinador menuCoordinador = new MenuCoordinador(academicoLogeado);
                    menuCoordinador.Show();
                    this.Close();
                } else {
                    MessageBox.Show("No se pudo actualizar el periodo escolar");
                }
            } else {
                MessageBox.Show("No se pudieron guardar las fechas de tutorías");
            }
        }

        private void clicCancelar(object sender, RoutedEventArgs e) {
            RegistrarFechasTutorias registrarFechasTutorias = new RegistrarFechasTutorias(academicoLogeado, idPeriodoSeleccionado, primeraTutoria.ToShortDateString(), 
                segundaTutoria.ToShortDateString(), terceraTutoria.ToShortDateString());

            registrarFechasTutorias.Show();
            this.Close();
        }
    }
}