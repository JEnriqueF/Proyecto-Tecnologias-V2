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
    public partial class PeriodoNuevo : Window {
        private Academico academicoLogeado;

        public PeriodoNuevo() {
            InitializeComponent();
        }

        private void clicGuardar(object sender, RoutedEventArgs e) {
            if(string.IsNullOrEmpty(tbTitulo.Text) ) {
                MessageBox.Show("Debe escribir un alias para identificar al periodo.");
                return;
            }

            if(dpFechaInicio.SelectedDate is null || dpFechaFin.SelectedDate is null) {
                MessageBox.Show("Debe elegir la fecha de inicio y la fecha de fin del periodo escolar.");
                return;
            }

            Service1Client registroPeriodo = new Service1Client();
            PeriodoEscolar[] periodosEscolares = registroPeriodo.obtenerPeriodosEscolares();

            foreach(PeriodoEscolar periodo in periodosEscolares) {
                if (dpFechaInicio.SelectedDate.Equals(periodo.FechaInicio) || (dpFechaInicio.SelectedDate > periodo.FechaInicio && dpFechaInicio.SelectedDate < periodo.FechaFin) ) {
                    MessageBox.Show("El periodo escolar ya fue registrado.");
                    return;
                }
            }
            MensajeGenerico mensaje = registroPeriodo.registrarPeriodoNuevo(tbTitulo.Text, (DateTime) dpFechaInicio.SelectedDate, (DateTime) dpFechaInicio.SelectedDate);

            if(mensaje.error == false) {
                MessageBox.Show("Periodo registrado.");
                MenuCoordinador menuCoordinador = new MenuCoordinador(academicoLogeado);
                menuCoordinador.Show();
                this.Close();
            } else {
                MessageBox.Show("No se pudo registrar el periodo. Inténtelo más tarde");
            }
        }

        private void clicCancelar(object sender, RoutedEventArgs e) {
            MenuCoordinador menuCoordinador = new MenuCoordinador(academicoLogeado);
            menuCoordinador.Show();
            this.Close();
        }
    }
}
