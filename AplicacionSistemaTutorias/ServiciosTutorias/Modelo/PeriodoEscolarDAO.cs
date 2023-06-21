using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo {
    public class PeriodoEscolarDAO {
        public static DataClassesTutoriasDBDataContext getConnection() {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

        public static List<PeriodoEscolar> obtenerPeriodoEscolarSinTutoria() {
            DataClassesTutoriasDBDataContext conexionBD= getConnection();

            IQueryable<PeriodoEscolar> periodosBD = from periodosQuery in conexionBD.PeriodoEscolar where periodosQuery.fechasTutorias == false select periodosQuery;
            return periodosBD.ToList();
        }

        public static List<PeriodoEscolar> obtenerPeriodosEscolares() {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<PeriodoEscolar> periodosBD = new List<PeriodoEscolar>();

            var periodos = from periodosQuery in conexionBD.PeriodoEscolar select new {periodosQuery};
            
            foreach(var periodo in periodos) {
                PeriodoEscolar periodoEscolar = new PeriodoEscolar {
                    idPeriodoEscolar = periodo.periodosQuery.idPeriodoEscolar,
                    titulo = periodo.periodosQuery.titulo,
                    FechaInicio = periodo.periodosQuery.FechaInicio,
                    FechaFin = periodo.periodosQuery.FechaFin,
                    fechasTutorias = periodo.periodosQuery.fechasTutorias
                };

                periodosBD.Add(periodoEscolar);
            }
            return periodosBD.ToList();
        }

        public static bool actualizarFechaTutoriaPeriodo(int idPeriodo) {
            try {
                DataClassesTutoriasDBDataContext conexionBD = getConnection();

                var periodo = (from periodoQuery in conexionBD.PeriodoEscolar where periodoQuery.idPeriodoEscolar == idPeriodo select periodoQuery).FirstOrDefault();
                if(periodo != null) {
                    periodo.fechasTutorias = true;

                    conexionBD.SubmitChanges();
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                return false;
            }
        }

        public static MensajeGenerico registrarPeriodoNuevo(string titulo, DateTime fechaInicio, DateTime fechaFin) {
            try {
                DataClassesTutoriasDBDataContext conexionBD = getConnection();

                var periodoNuevo = new PeriodoEscolar {
                    titulo = titulo,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    fechasTutorias = false
                };

                conexionBD.PeriodoEscolar.InsertOnSubmit(periodoNuevo);
                conexionBD.SubmitChanges();

                return new MensajeGenerico() {
                    error = false,
                    mensajeGenerico = "El periodo se ha registrado con éxito."
                };
            }catch (Exception ex) {
                return new MensajeGenerico() {
                    error = true,
                    mensajeGenerico = "Hubo un error. Inténtelo más tarde."
                };
            }
        }
    }
}