using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo {
    public class HorarioTutoriaDAO {
        public static DataClassesTutoriasDBDataContext getConnection() {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

        public static List<HoraTutoria> obtenerHorario(int idAcademico, int idTutoriaAcademica) {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<HoraTutoria> horarioBD = new List<HoraTutoria>();

            var horario = from horarioQuery in conexionBD.HoraTutoria 
                            join tutoradoQuery in conexionBD.Tutorado on horarioQuery.idTutorado equals tutoradoQuery.idTutorado
                            where horarioQuery.idTutorAcademico == idAcademico && horarioQuery.idTutoriaAcademica == idTutoriaAcademica
                            select new {horarioQuery};

            foreach(var horarios  in horario) {
                HoraTutoria hora = new HoraTutoria {
                    idHoraTutoria = horarios.horarioQuery.idHoraTutoria,
                    horaTutoria1 = horarios.horarioQuery.horaTutoria1,
                    idTutoriaAcademica = horarios.horarioQuery.idTutoriaAcademica,
                    idTutorAcademico = horarios.horarioQuery.idTutorAcademico,
                    idTutorado = horarios.horarioQuery.idTutorado
                };

                horarioBD.Add(hora);
            }
            return horarioBD.ToList();
        }
    }

    
}