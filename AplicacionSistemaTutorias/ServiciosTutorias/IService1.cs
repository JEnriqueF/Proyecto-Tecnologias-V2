using ServiciosTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosTutorias {
    
    [ServiceContract]
    public interface IService1 {

        [OperationContract]
        Mensaje Login(string correo, string password);

        [OperationContract]
        List<PeriodoEscolar> obtenerPeriodosEscolaresSinTutorias();

        [OperationContract]
        MensajeGenerico registrarFechasTutorias(DateTime primeraSesion, DateTime segundaSesion, DateTime terceraSesion, DateTime primeraEntrega, DateTime segundaEntrega, 
            DateTime terceraEntrega, int idPeriodo);

        [OperationContract]
        bool actualizarTutoriasEnPeriodo(int idPeriodo);

        [OperationContract]
        List<Academico> obtenerTutores();

        [OperationContract]
        List<TutoriaAcademica> obtenerTutoriasPeriodoReciente();

        [OperationContract]
        List<HoraTutoria> obtenerHorariosTutorias(int idTutorAcademico, int idTutoriaAcademica);

        [OperationContract]
        List<Tutorado> obtenerTuturadosDeHorariosTutorias(int idTutorAcademico, int idTutoriaAcademica);

        [OperationContract]
        List<TutoriaAcademica> obtenerTutoriasAnterioresFechaActual();

        [OperationContract]
        List<Materia> obtenerEEEnProblematicas(int idTutoria);

        [OperationContract]
        List<Problematica> obtenerProblematicasPorTutoria(int idTutoria);

        [OperationContract]
        List<Academico> obtenerTutoresDeComentarios(int idTutoria);

        [OperationContract]
        List<ComentarioGeneral> obtenerComentariosGenerales(int idTutoria);

        [OperationContract]
        MensajeGenerico registrarPeriodoNuevo(string titulo, DateTime fechaInicio, DateTime fechaFin);

        [OperationContract]
        List<PeriodoEscolar> obtenerPeriodosEscolares();

        [OperationContract]
        int obtenerAsistenciaPorTutoria(int idTutoria);
    }
}