using System.Collections.Generic;
using Avicola.Dominio;
namespace Avicola.Persistencia
{
    public interface IRepositorioPersona
    {
        IEnumerable<Persona> traerTodos();
        Persona anadir(Persona eq);
        Persona modificar(Persona eq);
        void eliminar(int id);
        Persona buscarPorId(int id);
    }
}