﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo {
    public class ComentarioGeneralDAO {
        public static DataClassesTutoriasDBDataContext getConnection() {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

        public static List<ComentarioGeneral> obtenerComentariosGenerales(int idTutoria) {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<ComentarioGeneral> comentariosBD = new List<ComentarioGeneral>();

            var comentarios = from comentarioQuery in conexionBD.ComentarioGeneral
                              join reporteTutoriaQuery in conexionBD.ReporteTutoriaAcademica
                              on comentarioQuery.idReporteTutoriaAcademica equals reporteTutoriaQuery.idReporteTutoriaAcademica
                              where reporteTutoriaQuery.idTutoriaAcademica == idTutoria
                              select new { comentarioQuery };

            foreach(var comentario in comentarios) {
                ComentarioGeneral comentarioGeneral = new ComentarioGeneral {
                    idComentarioGeneral = comentario.comentarioQuery.idComentarioGeneral,
                    descripcion = comentario.comentarioQuery.descripcion,
                    idReporteTutoriaAcademica = comentario.comentarioQuery.idReporteTutoriaAcademica
                };

                comentariosBD.Add(comentarioGeneral);
            }
            return comentariosBD.ToList();
        }

        public List<ConsultaComentarios> obtenerComentarios(int idTutor) {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            DateTime fechaActual = DateTime.Now;


            List<ConsultaComentarios> comentarios = new List<ConsultaComentarios>();
            IQueryable<ConsultaComentarios> consultarComentarios = from comentariosConsulta in conexionBD.ConsultaComentarios
                                                                   where comentariosConsulta.fechaLimiteReporte > fechaActual &&
                                                                   comentariosConsulta.descripcion != null &&
                                                                   comentariosConsulta.idTutorAcademico == idTutor
                                                                   select comentariosConsulta;
            if (consultarComentarios != null) {
                foreach (var agregar in consultarComentarios) {
                    ConsultaComentarios comentariosIterable = new ConsultaComentarios() {
                        idComentarioGeneral = agregar.idComentarioGeneral,
                        descripcion = agregar.descripcion,
                        nombre = agregar.nombre,
                        fechaSesion = agregar.fechaSesion,
                        numeroSesion = agregar.numeroSesion,
                        fechaLimiteReporte = agregar.fechaLimiteReporte
                    };
                    comentarios.Add(comentariosIterable);
                }
                return comentarios;
            } else {
                return null;
            }
        }

        public Boolean realizarCambiosComentarios(ComentarioGeneral comentarioGeneral) {
            try {
                DataClassesTutoriasDBDataContext conexionBD = getConnection();
                var consulta = (from ConsultaComentarios in conexionBD.ComentarioGeneral
                                where ConsultaComentarios.idComentarioGeneral == comentarioGeneral.idComentarioGeneral
                                select ConsultaComentarios).FirstOrDefault();
                if (consulta != null) {
                    consulta.descripcion = comentarioGeneral.descripcion;
                    conexionBD.SubmitChanges();
                    return true;
                } else {
                    return false;
                }
            } catch {
                return false;
            }
        }
    }
}