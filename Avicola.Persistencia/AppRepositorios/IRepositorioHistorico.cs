using System.Collections.Generic;
using Avicola.Dominio;
namespace Avicola.Persistencia
{
    public interface IRepositorioHistorico
    {
        IEnumerable<HistoricoIndicador> traerTodos();
        IEnumerable<HistoricoIndicador> traerTodosConFiltro(Galpon galpon);
        HistoricoIndicador anadir(HistoricoIndicador eq);
        HistoricoIndicador modificar(HistoricoIndicador eq);
        void eliminar(int id);
        HistoricoIndicador buscarPorId(int id);
    }
}