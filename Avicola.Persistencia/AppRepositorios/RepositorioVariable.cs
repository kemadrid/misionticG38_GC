using Avicola.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Avicola.Persistencia
{
    public class RepositorioVariable : IRepositorioVariable
    {
        /*
        private readonly AppContext conexionBD;
        ///<summary>
        
        ///</summary>
        ///<param name="appContext"></param>//
        
        public RepositorioVariable(AppContext conexionBD){
            this.conexionBD = conexionBD;
        }
            */
        private readonly AppContext conexionBD = new AppContext();

        IEnumerable<Variable> IRepositorioVariable.traerTodos(){
           return conexionBD.dbset_variables;
        }

        Variable IRepositorioVariable.anadir(Variable eq){
           var VariableGuardado =  conexionBD.dbset_variables.Add(eq);
           conexionBD.SaveChanges();
           return VariableGuardado.Entity;
        }
        
        void IRepositorioVariable.eliminar(int id_Variable){
            Variable buscado = conexionBD.dbset_variables.FirstOrDefault(Variable => Variable.Id == id_Variable);
            if(buscado == null){
                return ;
            }
            conexionBD.dbset_variables.Remove(buscado);
            conexionBD.SaveChanges();
        }

        Variable IRepositorioVariable.modificar(Variable eq){
            Variable buscado = conexionBD.dbset_variables.FirstOrDefault(Variable => Variable.Id == eq.Id);
            if(buscado != null){
                buscado.Nombre = eq.Nombre;
                buscado.Tipo = eq.Tipo;
                conexionBD.Update(buscado);
                conexionBD.SaveChanges();
            }
            return buscado;
        }
        
        Variable IRepositorioVariable.buscarPorId(int id){
            Variable buscado = conexionBD.dbset_variables.FirstOrDefault(Variable => Variable.Id == id);
            return buscado;
        }
    }
}