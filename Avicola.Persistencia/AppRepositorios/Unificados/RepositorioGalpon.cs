using System.Collections.Generic;
using System.Linq;
using Avicola.Dominio;
using System;
using Microsoft.EntityFrameworkCore;

namespace Avicola.Persistencia
{
    public class RepositorioGalpon : IRepositorioGalpon
    {
        private AppContext _appContext = new AppContext();

       //public RepositorioGalpon(AppContext appContext)
       //{
       //    _appContext=appContext;
       //}

       Galpon IRepositorioGalpon.AddGalpon(Galpon galpon)
       {
           var galponAdicionado = _appContext.Galpones.Add(galpon);
           _appContext.SaveChanges();
           return galponAdicionado.Entity;
       }


       void IRepositorioGalpon.DeleteGalpon(int idGalpon)
       {
           var galponEncontrado = _appContext.Galpones.FirstOrDefault(g => g.Id==idGalpon);
           if(galponEncontrado==null)
           return;

           _appContext.Galpones.Remove(galponEncontrado);
           _appContext.SaveChanges();

       }

        IEnumerable<Galpon> IRepositorioGalpon.GetAllGalpones()
       {    
           return _appContext.Galpones.Include("Veterinario").ToList();
       }

       IEnumerable<Galpon> IRepositorioGalpon.GetGalponesPorVeterinario(int idVet){
           var galpones = _appContext.Galpones.Include("Veterinario")
           .Where(g => g.Veterinario.Id == idVet).ToList();
           return galpones;
       }

       Galpon IRepositorioGalpon.GetGalpon(int idGalpon)
       {
            return _appContext.Galpones.Where(g => g.Id==idGalpon).FirstOrDefault();
       }

       Galpon IRepositorioGalpon.UpdateGalpon(Galpon galpon)
       {
           var galponEncontrado = _appContext.Galpones.Find(galpon.Id);
           if(galponEncontrado!= null)
           {
               galponEncontrado.Nombre = galpon.Nombre;
               galponEncontrado.Ubicacion = galpon.Ubicacion;
               galponEncontrado.Latitud = galpon.Latitud;
               galponEncontrado.Longitud = galpon.Longitud;
               galponEncontrado.CantidadAnimales = galpon.CantidadAnimales;
               galponEncontrado.FechaIngAnimales = galpon.FechaIngAnimales;
               galponEncontrado.FechaSalAnimales = galpon.FechaSalAnimales;
               //galponEncontrado.Auxiliar = galpon.Auxiliar;
               galponEncontrado.Veterinario = galpon.Veterinario;
               _appContext.SaveChanges();
           }
           return galponEncontrado;
       }
       Galpon IRepositorioGalpon.AsignarVeterinario(Galpon galpon){
           /* FORMA 2 actualización parcial
           _appContext.Galpones.Attach(galpon);
           _appContext.Entry(galpon).Property(x => x.Veterinario).IsModified = true;
            _appContext.SaveChanges();
           return galpon;
           */

           /*forma3, objeto externo actualizado*/
           _appContext.Entry(galpon).State = EntityState.Modified; 
           _appContext.SaveChanges();
           return galpon;
       }
    }
}