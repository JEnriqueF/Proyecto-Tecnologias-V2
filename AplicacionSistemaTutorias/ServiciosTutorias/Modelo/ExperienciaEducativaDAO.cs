using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo {
    public class ExperienciaEducativaDAO {
        public static DataClassesTutoriasDBDataContext getConnection() {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

        public static List<Materia> obtenerEEProblematicas(int idTutoria) {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<Materia> EEbd = new List<Materia>();

            var materia = from problematicaQuery in conexionBD.Problematica

                              join experienciaQuery in conexionBD.ExperienciaEducativa
                              on problematicaQuery.idExperienciaEducativa equals experienciaQuery.idExperienciaEducativa

                              join reporteTutoriaQuery in conexionBD.ReporteTutoriaAcademica
                              on problematicaQuery.idReporteTutoriaAcademica equals reporteTutoriaQuery.idReporteTutoriaAcademica

                              join materiaQuery in conexionBD.Materia
                              on experienciaQuery.idMateria equals materiaQuery.idMateria

                              where reporteTutoriaQuery.idTutoriaAcademica == idTutoria
                              select new { materiaQuery };

            foreach(var materias in materia) {
                Materia experienciaEducativa = new Materia {
                    idMateria = materias.materiaQuery.idMateria,
                    titulo = materias.materiaQuery.titulo
                };

                EEbd.Add(experienciaEducativa);
            }
            return EEbd.ToList();
        }
    }
}