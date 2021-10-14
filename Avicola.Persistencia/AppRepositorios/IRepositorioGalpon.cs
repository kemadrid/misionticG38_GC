using System.Collections.Generic;
using Avicola.Dominio;
using System.Data;
namespace Avicola.Persistencia
{
    public interface IRepositorioGalpon
    {
        IEnumerable<Galpon> GetAllGalpones();

        Galpon AddGalpon(Galpon galpon);

        Galpon UpdateGalpon(Galpon galpon);

        void DeleteGalpon(int idGalpon);

        Galpon GetGalpon(int idGalpon);
        
        IEnumerable<Galpon> GetGalponesPorVeterinario(int idVet);
    }
}