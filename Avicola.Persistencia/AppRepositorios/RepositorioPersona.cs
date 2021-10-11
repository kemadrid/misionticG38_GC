using Avicola.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Avicola.Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {
        /*
        private readonly AppContext conexionBD;
        ///<summary>
        
        ///</summary>
        ///<param name="appContext"></param>//
        
        public RepositorioPersona(AppContext conexionBD){
            this.conexionBD = conexionBD;
        }
            */
        private readonly AppContext conexionBD = new AppContext();

        IEnumerable<Persona> IRepositorioPersona.traerTodos(){
           return conexionBD.dbset_personas;
        }

        Persona IRepositorioPersona.anadir(Persona eq){
           var PersonaGuardado =  conexionBD.dbset_personas.Add(eq);
           conexionBD.SaveChanges();
           return PersonaGuardado.Entity;
        }
        
        void IRepositorioPersona.eliminar(int id_Persona){
            Persona buscado = conexionBD.dbset_personas.FirstOrDefault(Persona => Persona.Id == id_Persona);
            if(buscado == null){
                return ;
            }
            conexionBD.dbset_personas.Remove(buscado);
            conexionBD.SaveChanges();
            
        }

        Persona IRepositorioPersona.modificar(Persona eq){
            Persona buscado = conexionBD.dbset_personas.FirstOrDefault(Persona => Persona.Id == eq.Id);
            if(buscado != null){
                buscado.Nombre = eq.Nombre;
                buscado.Apellido = eq.Apellido;
                buscado.Cedula = eq.Cedula;
                buscado.Email = eq.Email;
                buscado.Telefono = eq.Telefono;
                buscado.tipo = eq.tipo;
                conexionBD.Update(buscado);
                conexionBD.SaveChanges();
            }
            return buscado;

            
        }
        
        Persona IRepositorioPersona.buscarPorId(int id){
            Persona buscado = conexionBD.dbset_personas.FirstOrDefault(Persona => Persona.Id == id);
            return buscado;
        }
    }
}