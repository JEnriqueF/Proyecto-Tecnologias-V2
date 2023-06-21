using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo {
    public class TutoradoDAO {
        public static DataClassesTutoriasDBDataContext getConnection() {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

        public static List<Tutorado> obtenerHorarioDeTutorados(int idAcademico, int idTutoriaAcademica) {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<Tutorado> tutoradoBD = new List<Tutorado>();

            var horario = from horarioQuery in conexionBD.HoraTutoria
                          join tutoradoQuery in conexionBD.Tutorado on horarioQuery.idTutorado equals tutoradoQuery.idTutorado
                          where horarioQuery.idTutorAcademico == idAcademico && horarioQuery.idTutoriaAcademica == idTutoriaAcademica
                          select new { tutoradoQuery };

            foreach (var horarios in horario) {
                Tutorado tutorado = new Tutorado {
                    idTutorado = horarios.tutoradoQuery.idTutorado,
                    nombre = horarios.tutoradoQuery.nombre,
                    apellidoPaterno = horarios.tutoradoQuery.apellidoPaterno,
                    apellidoMaterno = horarios.tutoradoQuery.apellidoMaterno,
                    correoInstitucional = horarios.tutoradoQuery.correoInstitucional,
                    matricula = horarios.tutoradoQuery.matricula,
                    password = horarios.tutoradoQuery.password,
                    correoPersonal = horarios.tutoradoQuery.correoPersonal,
                    idProgramaEducativo = horarios.tutoradoQuery.idProgramaEducativo,
                    idTutorAcademico = horarios.tutoradoQuery.idTutorAcademico
                };

                tutoradoBD.Add(tutorado);
            }
            return tutoradoBD.ToList();
        }
    }
}