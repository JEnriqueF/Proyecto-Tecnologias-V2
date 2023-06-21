﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo
{
    public class AcademicoDAO
    {
        public static List<Academico> obtenerUsuarios() {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();

            IQueryable<Academico> usuariosBD = from usuarioQuery in conexionBD.Academico
                                               select usuarioQuery;
            return usuariosBD.ToList();
        }

        public static DataClassesTutoriasDBDataContext getConnection() {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

        public static List<Academico> obtenerTutores() {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<Academico> academicosBD = new List<Academico>();

            var tutores = from academicoQuery in conexionBD.Academico where academicoQuery.idRol != 4 select new {academicoQuery};

            foreach( var tuto in tutores ) {
                Academico tutoresBD = new Academico {
                    idAcademico = tuto.academicoQuery.idAcademico,
                    nombre = tuto.academicoQuery.nombre,
                    apellidoPaterno = tuto.academicoQuery.apellidoPaterno,
                    apellidoMaterno = tuto.academicoQuery.apellidoMaterno,
                    correoInstitucional = tuto.academicoQuery.correoInstitucional,
                    numPersonal = tuto.academicoQuery.numPersonal,
                    password = tuto.academicoQuery.password,
                    idRol = tuto.academicoQuery.idRol
                };

                academicosBD.Add( tutoresBD );
            }
            return academicosBD.ToList();
        }

        public Mensaje Login(string correo, string password)
        {
            DataClassesTutoriasDBDataContext conexionDB = getConnection();
            Mensaje mensajeLogeado = new Mensaje();
            Academico consulta = (from academicoConsulta in conexionDB.Academico
                                  where academicoConsulta.correoInstitucional == correo &&
                                  academicoConsulta.password == password
                                  select academicoConsulta).FirstOrDefault();
            if (consulta != null)
            {
                mensajeLogeado = new Mensaje()
                {
                    mensajeTexto = "Usuario encontrado",
                    error = false,
                    usuarioAutenticado = new Academico()
                    {
                        idAcademico = consulta.idAcademico,
                        nombre = consulta.nombre,
                        apellidoMaterno = consulta.apellidoMaterno,
                        apellidoPaterno = consulta.apellidoPaterno,
                        correoInstitucional = consulta.correoInstitucional,
                        password = consulta.password,
                        numPersonal = consulta.numPersonal,
                        idRol = consulta.idRol
                    }
                };
                return mensajeLogeado;
            }
            else
            {
                mensajeLogeado = new Mensaje()
                {
                    error = true,
                    mensajeTexto = "Usuario no encontrado"
                };
                return mensajeLogeado;
            }
        }
        
        public static List<Academico> obtenerTutoresDeComentarios(int idTutoria) {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<Academico> tutoresBD = new List<Academico>();

            var tutores = from comentarioQuery in conexionBD.ComentarioGeneral
                          
                          join reporteTutoriaQuery in conexionBD.ReporteTutoriaAcademica
                          on comentarioQuery.idReporteTutoriaAcademica equals reporteTutoriaQuery.idReporteTutoriaAcademica
                          
                          join tutorQuery in conexionBD.Academico
                          on reporteTutoriaQuery.idTutorAcademico equals tutorQuery.idAcademico
                          
                          where reporteTutoriaQuery.idTutoriaAcademica == idTutoria
                          select new { tutorQuery };

            foreach(var tutor in tutores) {
                Academico academico = new Academico {
                    idAcademico = tutor.tutorQuery.idAcademico,
                    nombre = tutor.tutorQuery.nombre,
                    apellidoPaterno = tutor.tutorQuery.apellidoPaterno,
                    apellidoMaterno = tutor.tutorQuery.apellidoMaterno,
                    correoInstitucional = tutor.tutorQuery.correoInstitucional,
                    numPersonal = tutor.tutorQuery.numPersonal,
                    password = tutor.tutorQuery.password,
                    idRol = tutor.tutorQuery.idRol
                };

                tutoresBD.Add(academico);
            }
            return tutoresBD.ToList();
        }

        public int registrarProfesor(Academico academicoNuevo) {
            try {
                DataClassesTutoriasDBDataContext conexionBD = getConnection();
                var idRolComprobacion = conexionBD.Rol.Single(r => r.idRol == academicoNuevo.idRol);
                var consultaRol = from consulta in conexionBD.Academico
                                  select consulta;

                int coordinadorExistente = 0;
                int jefeExistente = 0;
                int numeroregistrado = 0;
                foreach (var consulta in consultaRol) {
                    if (consulta.idRol == 1) {
                        jefeExistente++;
                    } else if (consulta.idRol == 2) {
                        coordinadorExistente++;
                    } else if (consulta.numPersonal == academicoNuevo.numPersonal) {
                        numeroregistrado++;
                    }
                }
                if (academicoNuevo.idRol == 1 && jefeExistente > 0) {
                    return 2;
                } else if (academicoNuevo.idRol == 2 && coordinadorExistente > 0) {
                    return 3;
                } else if (numeroregistrado > 0) {
                    return 4;
                } else {
                    var academico = new Academico() {
                        nombre = academicoNuevo.nombre,
                        apellidoPaterno = academicoNuevo.apellidoPaterno,
                        apellidoMaterno = academicoNuevo.apellidoMaterno,
                        numPersonal = academicoNuevo.numPersonal,
                        password = academicoNuevo.password,
                        idRol = idRolComprobacion.idRol,
                        correoInstitucional = academicoNuevo.correoInstitucional
                    };
                    conexionBD.Academico.InsertOnSubmit(academico);
                    conexionBD.SubmitChanges();
                    return 1;
                }
            } catch (Exception ex) {
                return 0;
            }
        }

        public List<Rol> recuperarRoles() {
            DataClassesTutoriasDBDataContext consultaDB = getConnection();
            List<Rol> roles = new List<Rol>();
            IQueryable<Rol> consultaRoles = from rolesConsulta in consultaDB.Rol
                                            select rolesConsulta;

            if (consultaRoles != null) {
                foreach (var agregar in consultaRoles) {
                    Rol rolesIterable = new Rol() {
                        idRol = agregar.idRol,
                        titulo = agregar.titulo
                    };
                    roles.Add(rolesIterable);
                }
                return roles;
            } else {
                return null;
            }
        }


    }
}