using System.Collections.Generic;
using Avicola.Dominio;
using System.Data;
namespace Avicola.Persistencia
{
    public interface IRepositorioGeneral
    {
        //OPERACIONES PARA GALPON
         IEnumerable<Galpon> GetAllGalpones();

        Galpon AddGalpon(Galpon galpon);

        Galpon UpdateGalpon(Galpon galpon);

        void DeleteGalpon(int idGalpon);

        Galpon GetGalpon(int idGalpon);
        
        IEnumerable<Galpon> GetGalponesPorVeterinario(int idVet);
        Galpon AsignarVeterinario(Galpon galpon);


        //REPOSITORIO PERSONAS
        IEnumerable<Persona> traerTodosPersona();
        IEnumerable<Persona> traerTodosConFiltroPersona(tipoUsuario tipo_filtro);
        Persona anadirPersona(Persona eq);
        Persona modificarPersona(Persona eq);
        void eliminarPersona(int id);
        Persona buscarPorIdPersona(int id);

        //REPOSITORIO VARIABLE
        IEnumerable<Variable> traerTodosVariable();
        Variable anadirVariable(Variable eq);
        Variable modificarVariable(Variable eq);
        void eliminarVariable(int id);
        Variable buscarPorIdVariable(int id);

        //REPOSITORIO HISTORICO
        IEnumerable<HistoricoIndicador> traerTodosHistorico();
        IEnumerable<HistoricoIndicador> traerTodosConFiltroHistorico(Galpon galpon);
        HistoricoIndicador anadirHistorico(HistoricoIndicador eq);
        HistoricoIndicador_Variable anadirVariableHistorico(HistoricoIndicador_Variable eq);
        HistoricoIndicador_Variable modificarVariableHistorico(HistoricoIndicador_Variable eq);
        IEnumerable<HistoricoIndicador_Variable> traerTodosConFiltroHistorico(HistoricoIndicador historico);
        HistoricoIndicador modificarHistorico(HistoricoIndicador eq);
        void eliminarHistorico(int id);
        HistoricoIndicador buscarPorIdHistorico(int id);
        HistoricoIndicador modificarObjetosHistorico(HistoricoIndicador eq);


        //REPOSITORIO HISTORICO VARIABLE
         IEnumerable<HistoricoIndicador_Variable> traerTodosHistoVar();
        IEnumerable<HistoricoIndicador_Variable> traerTodosConFiltroHistoVar(int histo);
        HistoricoIndicador_Variable anadirHistoVar(HistoricoIndicador_Variable eq);
        HistoricoIndicador_Variable modificarHistoVar(HistoricoIndicador_Variable eq, int histo, int vari);
        void eliminarHistoVar(int id);
        HistoricoIndicador_Variable buscarPorIdHistoVar(int id);
        HistoricoIndicador_Variable modificarObjetosHistoVar(HistoricoIndicador_Variable eq);
        HistoricoIndicador_Variable AsignarObjetosHistoVar(int idHiVa, int idHis, int idVar);
    }
}