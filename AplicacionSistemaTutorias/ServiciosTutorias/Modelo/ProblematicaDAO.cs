using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo {
    public class ProblematicaDAO {
        public static DataClassesTutoriasDBDataContext getConnection() {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

        public static List<Problematica> obtenerProblematicas(int idTutoria) {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<Problematica> problematicasBD = new List<Problematica>();

            var problematicas = from problematicaQuery in conexionBD.Problematica
                                join reporteTutoriaQuery in conexionBD.ReporteTutoriaAcademica
                                on problematicaQuery.idReporteTutoriaAcademica equals reporteTutoriaQuery.idReporteTutoriaAcademica
                                where reporteTutoriaQuery.idTutoriaAcademica == idTutoria
                                select new { problematicaQuery };

            foreach(var problematica in problematicas) {
                Problematica problematicaA = new Problematica {
                    idProblematica = problematica.problematicaQuery.idProblematica,
                    descripcion = problematica.problematicaQuery.descripcion,
                    numeroIncidencias = problematica.problematicaQuery.numeroIncidencias,
                    idReporteTutoriaAcademica = problematica.problematicaQuery.idReporteTutoriaAcademica,
                    idClasificacionProblematica = problematica.problematicaQuery.idClasificacionProblematica,
                    idSolucionProblematica = problematica.problematicaQuery.idSolucionProblematica,
                    idExperienciaEducativa = problematica.problematicaQuery.idExperienciaEducativa
                };

                problematicasBD.Add(problematicaA);
            }
            return problematicasBD.ToList();
        }
    }
}