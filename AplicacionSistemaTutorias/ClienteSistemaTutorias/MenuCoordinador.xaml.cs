using ClienteSistemaTutorias.InformacionUsuarios;
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

namespace ClienteSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para MenuCoordinador.xaml
    /// </summary>
    public partial class MenuCoordinador : Window
    {
        Academico academicoEnUso = new Academico();
        public MenuCoordinador(Academico academicoLogeado)
        {
            InitializeComponent();
            recibirAcademico(academicoLogeado);
        }

        public void recibirAcademico(Academico academicoLogeado)
        {
            
            academicoEnUso = academicoLogeado;
        }

        private void clickBtnRegistrarComentariosgenerales(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnEditarComentariosGenerales(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnRegistrarHorarioDeSesion(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnConsultarHorario(object sender, RoutedEventArgs e)
        {
            ConsultarHorarioTutorias consultarHorario = new ConsultarHorarioTutorias(academicoEnUso);
            consultarHorario.Show();
            this.Close();
        }
        private void clickBtnRegistrarProblematicaAcademica(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnLlenarreporteTutoria(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarFechasDeSesion(object sender, RoutedEventArgs e)
        {
            RegistrarFechasTutorias registrarFechasTutorias = new RegistrarFechasTutorias(academicoEnUso, -1, DateTime.Now.ToShortDateString(), 
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());

            registrarFechasTutorias.Show();
            this.Close();
        }
        private void clickBtnConsultarReporteGeneral(object sender, RoutedEventArgs e)
        {
            ConsultarReporteGeneral consultarReporte = new ConsultarReporteGeneral();
            consultarReporte.Show();
            this.Close();
        }
        private void clickBtnRegistrarFechasDeCierre(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarProfesor(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnRegistrarPeriodoNuevo(object sender, RoutedEventArgs e) {
            PeriodoNuevo periodoNuevo = new PeriodoNuevo();
            periodoNuevo.Show();
            this.Close();
        }

        //clickBtnSalir
        private void clickBtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void clickBtnCerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();

        }
    }
}
