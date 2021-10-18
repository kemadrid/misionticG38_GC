using System.Collections.Generic;
using Avicola.Dominio;
namespace Avicola.Persistencia
{
    public interface IRepositorioPersona
    {
        IEnumerable<Persona> traerTodos();
        IEnumerable<Persona> traerTodosConFiltro(tipoUsuario tipo_filtro);
        Persona anadir(Persona eq);
        Persona modificar(Persona eq);
        void eliminar(int id);
        Persona buscarPorId(int id);
    }
}