using System.Collections.Generic;
using Avicola.Dominio;
namespace Avicola.Persistencia
{
    public interface IRepositorioHistorico_Variable
    {
        IEnumerable<HistoricoIndicador_Variable> traerTodos();
        IEnumerable<HistoricoIndicador_Variable> traerTodosConFiltro(HistoricoIndicador histo);
        HistoricoIndicador_Variable anadir(HistoricoIndicador_Variable eq);
        HistoricoIndicador_Variable modificar(HistoricoIndicador_Variable eq);
        void eliminar(int id);
        HistoricoIndicador_Variable buscarPorId(int id);
    }
}