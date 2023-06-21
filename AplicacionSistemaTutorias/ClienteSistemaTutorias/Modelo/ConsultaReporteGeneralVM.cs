using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo {
    internal class ConsultaReporteGeneralVM {
        public ObservableCollection<TutoriaAcademica> tutoriasBD { get; set; }

        public ConsultaReporteGeneralVM() {
            tutoriasBD = new ObservableCollection<TutoriaAcademica>();
            llenarTabla();
        }

        private async void llenarTabla() {
            var conexionServicios = new Service1Client();

            if (conexionServicios != null) {
                TutoriaAcademica[] tutoriaService = await conexionServicios.obtenerTutoriasAnterioresFechaActualAsync();

                foreach (TutoriaAcademica tutoria in tutoriaService) {
                    tutoriasBD.Add(tutoria);
                }
            }
        }
    }
}
