using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo {
    internal class ConsultaUsuarioVM {
        public ObservableCollection<HoraTutoria> horariosBD { get; set; }
        public ObservableCollection<Tutorado> tutoradosBD { get; set; }

        public ConsultaUsuarioVM(int idAcademico, int idTutoriaAcademica) {
            horariosBD = new ObservableCollection<HoraTutoria>();
            tutoradosBD = new ObservableCollection<Tutorado>();
            llenarTabla(idAcademico, idTutoriaAcademica);
        }

        private async void llenarTabla(int idAcademico, int idTutoriaAcademica) {
            var conexionServicios = new Service1Client();

            if (conexionServicios != null) {
                Tutorado[] tutoradoService = await conexionServicios.obtenerTuturadosDeHorariosTutoriasAsync(idAcademico, idTutoriaAcademica);

                foreach (Tutorado tutorado in tutoradoService) {
                    tutoradosBD.Add(tutorado);
                }
            }

            if (conexionServicios != null) {
                HoraTutoria[] horarioService = await conexionServicios.obtenerHorariosTutoriasAsync(idAcademico, idTutoriaAcademica);

                foreach (HoraTutoria horario in horarioService) {
                    horariosBD.Add(horario);
                }
            }
        }
    }
}
