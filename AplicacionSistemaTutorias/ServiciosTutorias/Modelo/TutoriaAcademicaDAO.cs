using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosTutorias.Modelo {
    public class TutoriaAcademicaDAO {
        public static DataClassesTutoriasDBDataContext getConnection() {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

        public static MensajeGenerico guardarFechasTutorias(DateTime primeraSesion, DateTime segundaSesion, DateTime terceraSesion, DateTime primeraEntrega, 
                                                            DateTime segundaEntrega, DateTime terceraEntrega, int idPeriodo) {
            try {
                DataClassesTutoriasDBDataContext conexionBD = getConnection();

                var primeraTutoria = new TutoriaAcademica() {
                    fechaSesion = (DateTime?) primeraSesion,
                    fechaLimiteReporte = (DateTime?) primeraEntrega,
                    numeroSesion = 1,
                    idPeriodoEscolar = idPeriodo
                };

                var segundaTutoria = new TutoriaAcademica() {
                    fechaSesion = (DateTime?) segundaSesion,
                    fechaLimiteReporte = (DateTime?) segundaEntrega,
                    numeroSesion = 2,
                    idPeriodoEscolar = idPeriodo
                };

                var terceraTutoria = new TutoriaAcademica() {
                    fechaSesion = (DateTime?) terceraSesion,
                    fechaLimiteReporte = (DateTime?) terceraEntrega,
                    numeroSesion = 3,
                    idPeriodoEscolar = idPeriodo
                };

                conexionBD.TutoriaAcademica.InsertOnSubmit(primeraTutoria);
                conexionBD.TutoriaAcademica.InsertOnSubmit(segundaTutoria);
                conexionBD.TutoriaAcademica.InsertOnSubmit(terceraTutoria);
                conexionBD.SubmitChanges();

                return new MensajeGenerico() {
                    error = false,
                    mensajeGenerico = "Tutoria registrada"
                };
            }catch(Exception ex) {
                return new MensajeGenerico() {
                    error = true,
                    mensajeGenerico = "Hubo un error. Inténtelo más tarde"
                };
            }
            
        }

        public static List<TutoriaAcademica> obtenerTutoriasPeriodoActual() {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<TutoriaAcademica> tutoriasBD = new List<TutoriaAcademica>();

            var tutorias = from tutoriaQuery in conexionBD.TutoriaAcademica
                           join periodoQuery in conexionBD.PeriodoEscolar
                           on tutoriaQuery.idPeriodoEscolar equals periodoQuery.idPeriodoEscolar
                           where periodoQuery.FechaInicio <= DateTime.Now && periodoQuery.FechaFin >= DateTime.Now
                           select tutoriaQuery;

            foreach (var tutoria in tutorias) {
                TutoriaAcademica tutoriaAcademica = new TutoriaAcademica {
                    idTutoriaAcademica = tutoria.idTutoriaAcademica,
                    fechaSesion = tutoria.fechaSesion,
                    numeroSesion = tutoria.numeroSesion,
                    fechaLimiteReporte = tutoria.fechaLimiteReporte,
                    idPeriodoEscolar = tutoria.idPeriodoEscolar
                };

                tutoriasBD.Add(tutoriaAcademica);
            }
            return tutoriasBD.ToList();
        }

        public static List<TutoriaAcademica> obtenerTutoriasAnterioresFechaActual() {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<TutoriaAcademica> tutoriasBD = new List<TutoriaAcademica>();

            var tutoria = from tutoriaQuery in conexionBD.TutoriaAcademica where tutoriaQuery.fechaSesion <= DateTime.Now select new { tutoriaQuery };

            foreach(var tutoriaA in tutoria) {
                TutoriaAcademica tutoriaAcademica = new TutoriaAcademica {
                    idTutoriaAcademica = tutoriaA.tutoriaQuery.idTutoriaAcademica,
                    fechaSesion = tutoriaA.tutoriaQuery.fechaSesion,
                    numeroSesion = tutoriaA.tutoriaQuery.numeroSesion,
                    fechaLimiteReporte = tutoriaA.tutoriaQuery.fechaLimiteReporte,
                    idPeriodoEscolar = tutoriaA.tutoriaQuery.idPeriodoEscolar
                };

                tutoriasBD.Add(tutoriaAcademica);
            }
            return tutoriasBD.ToList();
        }

        public static int obtenerAsistenciaPorTutoria(int idTutoria) {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();

            var asistenciaBD = from asistenciaQuery in conexionBD.Asistencia where asistenciaQuery.idTutoriaAcademica == idTutoria select asistenciaQuery;
            int asistencias = asistenciaBD.Count();
            return asistencias;
        }
    }
}