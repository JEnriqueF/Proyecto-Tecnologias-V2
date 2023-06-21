using ClienteSistemaTutorias.Modelo;
using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System.Collections.ObjectModel;
using System.Windows;

namespace ClienteSistemaTutorias {
    public partial class ConsultarReporteGeneral : Window {
        private Academico academicoLogeado;
        public ObservableCollection<PeriodoEscolar> periodosEscolares { get; set; }

        public ConsultarReporteGeneral() {
            InitializeComponent();
            ConsultaReporteGeneralVM consultarReporte = new ConsultaReporteGeneralVM();
            dgReportes.ItemsSource = consultarReporte.tutoriasBD;
        }
        
        private void clicConsultarReporte(object sender, RoutedEventArgs e) {
            if(dgReportes.SelectedItem is null) {
                MessageBox.Show("Debes elegir la fecha de una tutoría.");
                return;
            }

            TutoriaAcademica tutoria = dgReportes.SelectedItem as TutoriaAcademica;
            ReporteGeneralTutorias reporteGeneral = new ReporteGeneralTutorias(tutoria.idTutoriaAcademica);
            reporteGeneral.Show();
            this.Close();
        }

        private void clicCerrar(object sender, RoutedEventArgs e) {
            MenuCoordinador menuCoordinador = new MenuCoordinador(academicoLogeado);
            menuCoordinador.Show();
            this.Close();
        }
    }
}
