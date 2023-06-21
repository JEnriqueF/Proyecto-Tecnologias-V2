using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ClienteSistemaTutorias {
    public partial class RegistrarFechasTutorias : Window {
        private Academico academicoLogeado;
        public ObservableCollection<PeriodoEscolar> periodosEscolares { get; set; }
        private int idPeriodoSeleccionado;
        private PeriodoEscolar periodoSeleccionado = null;

        public RegistrarFechasTutorias(Academico academicoLogeado, int idPeriodoEscolar, string primeraTutoria, string segundaTutoria, string terceraTutoria) {
            InitializeComponent();
            iniciarComboboxPeriodo();

            this.academicoLogeado = academicoLogeado;
            cbPeriodos.SelectedValue = idPeriodoEscolar;

            if(primeraTutoria != DateTime.Now.ToShortDateString()) {
                DateTime fecha;

                DateTime.TryParseExact(primeraTutoria, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
                dpPrimeraTutoria.SelectedDate = fecha;

                DateTime.TryParseExact(segundaTutoria, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
                dpSegundaTutoria.SelectedDate = fecha;

                DateTime.TryParseExact(terceraTutoria, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
                dpTerceraTutoria.SelectedDate = fecha;
            }
        }

        private void clicAceptar(object sender, RoutedEventArgs e) {
            if(cbPeriodos.SelectedItem is null) {
                MessageBox.Show("Debe elegir primero un periodo escolar.");
                return;
            }

            if(dpPrimeraTutoria.SelectedDate is null || dpSegundaTutoria.SelectedDate is null || dpTerceraTutoria.SelectedDate is null) {
                MessageBox.Show("Debe elegir las 3 fechas antes de continuar.");
                return;
            }

            if(dpPrimeraTutoria.SelectedDate < periodoSeleccionado.FechaInicio || dpPrimeraTutoria.SelectedDate > periodoSeleccionado.FechaFin 
                || dpPrimeraTutoria.SelectedDate > dpSegundaTutoria.SelectedDate || dpPrimeraTutoria.SelectedDate > dpTerceraTutoria.SelectedDate) {

                MessageBox.Show("La primera fecha de sesión de tutoría no es válida. Verifique e inténtelo de nuevo.");
                return;
            }

            if(dpSegundaTutoria.SelectedDate < periodoSeleccionado.FechaInicio || dpSegundaTutoria.SelectedDate > periodoSeleccionado.FechaFin
                || dpSegundaTutoria.SelectedDate > dpTerceraTutoria.SelectedDate) {

                MessageBox.Show("La segunda fecha de sesión de tutoría no es válida. Verifique e inténtelo de nuevo.");
                return;
            }

            if(dpTerceraTutoria.SelectedDate < periodoSeleccionado.FechaInicio || dpTerceraTutoria.SelectedDate > periodoSeleccionado.FechaFin) {
                MessageBox.Show("La tercera fecha de sesión de tutoría no es válida. Verifique e inténtelo de nuevo.");
                return;
            }

            RegistrarFechasCierreReporte cierreReporte = new RegistrarFechasCierreReporte( (DateTime) dpPrimeraTutoria.SelectedDate, 
                (DateTime) dpSegundaTutoria.SelectedDate, (DateTime) dpTerceraTutoria.SelectedDate, (DateTime) periodoSeleccionado.FechaFin, 
                (int) cbPeriodos.SelectedValue, periodoSeleccionado.titulo, academicoLogeado);

            cierreReporte.Show();
            this.Close();
        }

        private void clicCancelar(object sender, RoutedEventArgs e) {
            MenuCoordinador menuCoordinador = new MenuCoordinador(academicoLogeado);
            menuCoordinador.Show();
            this.Close();
        }

        public async void iniciarComboboxPeriodo() {
            periodosEscolares = new ObservableCollection<PeriodoEscolar>();
            var conexionServicios = new Service1Client();

            if (conexionServicios != null) {
                PeriodoEscolar[] periodosE = await conexionServicios.obtenerPeriodosEscolaresSinTutoriasAsync();

                foreach (PeriodoEscolar periodos in periodosE) {
                    periodosEscolares.Add(periodos);
                }
            } else {
                new MensajeGenerico {
                    error = true,
                    mensajeGenerico = "Error con la conexión al servicio. Inténtelo más tarde."
                };
            }
            cbPeriodos.ItemsSource = periodosEscolares;
        }

        private void cbPeriodoEscolar_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            periodoSeleccionado = cbPeriodos.SelectedItem as PeriodoEscolar;
            idPeriodoSeleccionado = periodoSeleccionado.idPeriodoEscolar;
        }
    }
}