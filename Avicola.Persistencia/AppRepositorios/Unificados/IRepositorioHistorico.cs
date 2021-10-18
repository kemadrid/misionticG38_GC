using System.Collections.Generic;
using Avicola.Dominio;
namespace Avicola.Persistencia
{
    public interface IRepositorioHistorico
    {
        IEnumerable<HistoricoIndicador> traerTodos();
        IEnumerable<HistoricoIndicador> traerTodosConFiltro(Galpon galpon);
        HistoricoIndicador anadir(HistoricoIndicador eq);
        HistoricoIndicador_Variable anadirVariableHistorico(HistoricoIndicador_Variable eq);
        HistoricoIndicador_Variable modificarVariableHistorico(HistoricoIndicador_Variable eq);
        IEnumerable<HistoricoIndicador_Variable> traerTodosConFiltro(HistoricoIndicador historico);
        HistoricoIndicador modificar(HistoricoIndicador eq);
        void eliminar(int id);
        HistoricoIndicador buscarPorId(int id);
        HistoricoIndicador modificarObjetos(HistoricoIndicador eq);
    }
}