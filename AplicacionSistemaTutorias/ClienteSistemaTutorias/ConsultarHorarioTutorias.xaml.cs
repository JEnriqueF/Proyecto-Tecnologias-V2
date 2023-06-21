using ClienteSistemaTutorias.Modelo;
using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ClienteSistemaTutorias {
    public partial class ConsultarHorarioTutorias : Window {
        private Academico academicoEnUso;
        public ObservableCollection<TutoriaAcademica> tutorias { get; set; }
        public ObservableCollection<Academico> academicos { get; set; }
        public ObservableCollection<HoraTutoria> horarios { get; set; }
        public ObservableCollection<Tutorado> tutorados { get; set; }
        int idTutoriaSeleccionada, idTutorSeleccionado;

        public ConsultarHorarioTutorias(Academico academico) {
            InitializeComponent();
            iniciarComboboxTutorias();
            iniciarComboboxTutores();
            academicoEnUso = academico;
        }

        private void clicBuscar(object sender, RoutedEventArgs e) {
            if(cbTutoriasActuales.SelectedItem is null) {
                MessageBox.Show("Debe elegir una tutoría.");
                return;
            }

            if(cbTutores.SelectedItem is null) {
                MessageBox.Show("Debe elegir un tutor.");
                return;
            }

            ConsultaUsuarioVM consultaUsuarioVM = new ConsultaUsuarioVM((int)cbTutores.SelectedValue, (int)cbTutoriasActuales.SelectedValue);
            dgTutorados.ItemsSource = consultaUsuarioVM.tutoradosBD;
            dgHorario.ItemsSource = consultaUsuarioVM.horariosBD;
        }

        private void clicRegresar(object sender, RoutedEventArgs e) {
            if (academicoEnUso.idRol == 1) {
                MenuJefe menuJefe = new MenuJefe(academicoEnUso);
                menuJefe.Show();
                this.Close();
            } else if (academicoEnUso.idRol == 2) {
                MenuCoordinador menuCoordinador = new MenuCoordinador(academicoEnUso);
                menuCoordinador.Show();
                this.Close();
            } else if (academicoEnUso.idRol == 3) {
                MenuTutor menuTutor = new MenuTutor(academicoEnUso);
                menuTutor.Show();
                this.Close();
            }
        }

        public async void iniciarComboboxTutorias() {
            tutorias = new ObservableCollection<TutoriaAcademica>();
            var conexionServicios = new Service1Client();

            if (conexionServicios != null) {
                TutoriaAcademica[] tutoriasA = await conexionServicios.obtenerTutoriasPeriodoRecienteAsync();

                foreach (TutoriaAcademica tutorias in tutoriasA) {
                    this.tutorias.Add(tutorias);
                }
            } else {
                MessageBox.Show("No se pudieron obtener las tutorias.");
            }
            cbTutoriasActuales.ItemsSource = tutorias;
        }

        private void cbTutoria_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            TutoriaAcademica tutoriaSeleccionada = cbTutoriasActuales.SelectedItem as TutoriaAcademica;
            idTutoriaSeleccionada = tutoriaSeleccionada.idTutoriaAcademica;
        }

        public async void iniciarComboboxTutores() {
            academicos = new ObservableCollection<Academico>();
            var conexionServicios = new Service1Client();

            if (conexionServicios != null) {
                Academico[] academicos = await conexionServicios.obtenerTutoresAsync();

                foreach (Academico academico in academicos) {
                    this.academicos.Add(academico);
                }
            } else {
                MessageBox.Show("No se pudieron obtener las tutorias.");
            }
            cbTutores.ItemsSource = academicos;
        }

        private void cbTutores_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Academico tutorSeleccionado = cbTutores.SelectedItem as Academico;
            idTutorSeleccionado = tutorSeleccionado.idAcademico;
        }
    }
}
