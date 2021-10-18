using System.Collections.Generic;
using Avicola.Dominio;
namespace Avicola.Persistencia
{
    public interface IRepositorioVariable
    {
        IEnumerable<Variable> traerTodos();
        Variable anadir(Variable eq);
        Variable modificar(Variable eq);
        void eliminar(int id);
        Variable buscarPorId(int id);
    }
}