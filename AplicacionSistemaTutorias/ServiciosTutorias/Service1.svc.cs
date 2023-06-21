using ServiciosTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosTutorias {
    
    public class Service1 : IService1 {
        
        public Mensaje Login(string correo, string password)
        {
            AcademicoDAO academicoDAO = new AcademicoDAO();
            return academicoDAO.Login(correo, password);
        }
        
        public List<PeriodoEscolar> obtenerPeriodosEscolaresSinTutorias() {
            List<PeriodoEscolar> periodoEscolar = PeriodoEscolarDAO.obtenerPeriodoEscolarSinTutoria();
            return periodoEscolar;
        }

        public MensajeGenerico registrarFechasTutorias(DateTime primeraSesion, DateTime segundaSesion, DateTime terceraSesion, DateTime primeraEntrega, 
                                                        DateTime segundaEntrega, DateTime terceraEntrega, int idPeriodo) {

            return TutoriaAcademicaDAO.guardarFechasTutorias(primeraSesion, segundaSesion, terceraSesion, primeraEntrega, segundaEntrega, terceraEntrega, idPeriodo);
        }

        public bool actualizarTutoriasEnPeriodo(int idPeriodo) {
            return PeriodoEscolarDAO.actualizarFechaTutoriaPeriodo(idPeriodo);
        }

        public List<Academico> obtenerTutores() {
            List<Academico> academicos = AcademicoDAO.obtenerTutores();
            return academicos;
        }

        public List<TutoriaAcademica> obtenerTutoriasPeriodoReciente() {
            List<TutoriaAcademica> tutorias = TutoriaAcademicaDAO.obtenerTutoriasPeriodoActual();
            return tutorias;
        }

        public List<HoraTutoria> obtenerHorariosTutorias(int idTutorAcademico, int idTutoriaAcademica) {
            List<HoraTutoria> horario = HorarioTutoriaDAO.obtenerHorario(idTutorAcademico, idTutoriaAcademica);
            return horario;
        }

        public List<Tutorado> obtenerTuturadosDeHorariosTutorias(int idTutorAcademico, int idTutoriaAcademica) {
            List<Tutorado> tutorado = TutoradoDAO.obtenerHorarioDeTutorados(idTutorAcademico, idTutoriaAcademica);
            return tutorado;
        }

        public List<TutoriaAcademica> obtenerTutoriasAnterioresFechaActual() {
            List<TutoriaAcademica> tutoria = TutoriaAcademicaDAO.obtenerTutoriasAnterioresFechaActual();
            return tutoria;
        }

        public List<Materia> obtenerEEEnProblematicas(int idTutoria) {
            List<Materia> experiencia = ExperienciaEducativaDAO.obtenerEEProblematicas(idTutoria);
            return experiencia;
        }

        public List<Problematica> obtenerProblematicasPorTutoria(int idTutoria) {
            List<Problematica> problematica = ProblematicaDAO.obtenerProblematicas(idTutoria);
            return problematica;
        }

        public List<Academico> obtenerTutoresDeComentarios(int idTutoria) {
            List<Academico> tutor = AcademicoDAO.obtenerTutoresDeComentarios(idTutoria);
            return tutor;
        }

        public List<ComentarioGeneral> obtenerComentariosGenerales(int idTutoria) {
            List<ComentarioGeneral> comentario = ComentarioGeneralDAO.obtenerComentariosGenerales(idTutoria);
            return comentario;
        }

        public MensajeGenerico registrarPeriodoNuevo(string titulo, DateTime fechaInicio, DateTime fechaFin) {
            return PeriodoEscolarDAO.registrarPeriodoNuevo(titulo, fechaInicio, fechaFin);
        }

        public List<PeriodoEscolar> obtenerPeriodosEscolares() {
            List<PeriodoEscolar> periodos = PeriodoEscolarDAO.obtenerPeriodosEscolares();
            return periodos;
        }

        public int obtenerAsistenciaPorTutoria(int idTutoria) {
            return TutoriaAcademicaDAO.obtenerAsistenciaPorTutoria(idTutoria);
        }
    }
}