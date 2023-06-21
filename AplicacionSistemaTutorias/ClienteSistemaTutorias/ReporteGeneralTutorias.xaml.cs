using ClienteSistemaTutorias.Modelo;
using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClienteSistemaTutorias {
    /// <summary>
    /// Lógica de interacción para ReporteGeneralTutorias.xaml
    /// </summary>
    public partial class ReporteGeneralTutorias : Window {
        public ReporteGeneralTutorias(int idTutoria) {
            InitializeComponent();
            ReporteGeneral reporteG = new ReporteGeneral(idTutoria);
            dgExperiencias.ItemsSource = reporteG.experienciasBD;
            dgProblematicas.ItemsSource = reporteG.problematicasBD;
            dgTutores.ItemsSource = reporteG.tutoresBD;
            dgComentario.ItemsSource = reporteG.comentariosBD;

            Service1Client service1 = new Service1Client();
            lbAsistencia.Content = service1.obtenerAsistenciaPorTutoria(idTutoria);
        }

        private void clicRegresar(object sender, RoutedEventArgs e) {
            ConsultarReporteGeneral consultarReporteGeneral = new ConsultarReporteGeneral();
            consultarReporteGeneral.Show();
            this.Close();
        }
    }
}
