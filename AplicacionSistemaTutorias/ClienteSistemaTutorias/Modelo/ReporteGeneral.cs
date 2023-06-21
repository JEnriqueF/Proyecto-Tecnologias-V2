using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo {
    internal class ReporteGeneral {
        public ObservableCollection<Materia> experienciasBD { get; set; }
        public ObservableCollection<Problematica> problematicasBD { get; set; }
        public ObservableCollection<Academico> tutoresBD { get; set; }
        public ObservableCollection<ComentarioGeneral> comentariosBD { get; set; }
        int idTutoria;

        public ReporteGeneral(int idTutoria) {
            experienciasBD = new ObservableCollection<Materia>();
            problematicasBD = new ObservableCollection<Problematica>();
            tutoresBD = new ObservableCollection<Academico>();
            comentariosBD = new ObservableCollection<ComentarioGeneral>();
            this.idTutoria = idTutoria;
            llenarTablas();
        }
        private async void llenarTablas() {
            var conexionServicios = new Service1Client();

            if (conexionServicios != null) {
                Materia[] experienciaService = await conexionServicios.obtenerEEEnProblematicasAsync(idTutoria);

                foreach (Materia experienciaEducativa in experienciaService) {
                    experienciasBD.Add(experienciaEducativa);
                }
            }

            if (conexionServicios != null) {
                Problematica[] problematicaService = await conexionServicios.obtenerProblematicasPorTutoriaAsync(idTutoria);

                foreach (Problematica problematica in problematicaService) {
                    problematicasBD.Add(problematica);
                }
            }

            if (conexionServicios != null) {
                Academico[] academicoService = await conexionServicios.obtenerTutoresDeComentariosAsync(idTutoria);

                foreach (Academico academico in academicoService) {
                    tutoresBD.Add(academico);
                }
            }

            if (conexionServicios != null) {
                ComentarioGeneral[] comentarioService = await conexionServicios.obtenerComentariosGeneralesAsync(idTutoria);

                foreach (ComentarioGeneral comentario in comentarioService) {
                    comentariosBD.Add(comentario);
                }
            }
        }

    }
}