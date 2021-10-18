using Avicola.Dominio;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Avicola.Persistencia
{
    public class RepositorioHistorico : IRepositorioHistorico
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

        IEnumerable<HistoricoIndicador> IRepositorioHistorico.traerTodos(){
           return conexionBD.dbset_historicos.Include(h => h.Veterinario).Include(h=>h.Galpon).ToList();
        }

        HistoricoIndicador IRepositorioHistorico.anadir(HistoricoIndicador eq){
           var historico =  conexionBD.dbset_historicos.Add(eq);
           conexionBD.SaveChanges();

           //desacoplar
           conexionBD.Entry(eq).State = EntityState.Detached;
              
           return historico.Entity;
        }
        
HistoricoIndicador_Variable IRepositorioHistorico.anadirVariableHistorico(HistoricoIndicador_Variable eq){
    var historicovariable = conexionBD.dbset_historicosxvariables.Add(eq);
    conexionBD.SaveChanges();
    return historicovariable.Entity;
}
        HistoricoIndicador_Variable IRepositorioHistorico.modificarVariableHistorico(HistoricoIndicador_Variable eq){
             HistoricoIndicador_Variable buscado = conexionBD.dbset_historicosxvariables.FirstOrDefault(h => h.Id == eq.Id);
            if(buscado != null){
                buscado.HistoricoIndicador = eq.HistoricoIndicador;
                buscado.Variable = eq.Variable;
                conexionBD.SaveChanges();
            }
            return buscado;

        }
       IEnumerable<HistoricoIndicador_Variable> IRepositorioHistorico.traerTodosConFiltro(HistoricoIndicador historico){
            var result = conexionBD.dbset_historicosxvariables
            .Include("Variable")
            .Include("HistoricoIndicador")
            .Where(h => h.HistoricoIndicador.Id ==historico.Id).ToList();
            return result;
        }

        void IRepositorioHistorico.eliminar(int id_histo){
            HistoricoIndicador buscado = conexionBD.dbset_historicos.FirstOrDefault(h => h.Id == id_histo);
            if(buscado == null){
                return ;
            }
            conexionBD.dbset_historicos.Remove(buscado);
            conexionBD.SaveChanges();
            
        }

        HistoricoIndicador IRepositorioHistorico.modificar(HistoricoIndicador eq){
            HistoricoIndicador buscado = conexionBD.dbset_historicos.Find(eq.Id);
            if(buscado != null){
                buscado.Fecha = eq.Fecha;
                buscado.Veterinario = eq.Veterinario;
                buscado.Galpon = eq.Galpon;
                conexionBD.SaveChanges();

                conexionBD.Entry(eq).State = EntityState.Detached;
                conexionBD.Entry(eq.Veterinario).State = EntityState.Detached;
                conexionBD.Entry(eq.Galpon).State = EntityState.Detached;
            }
            return buscado;
        }
        
        HistoricoIndicador IRepositorioHistorico.modificarObjetos(HistoricoIndicador eq){
            conexionBD.Entry(eq).State = EntityState.Modified; 
            conexionBD.SaveChanges();
            return eq;
        }
        HistoricoIndicador IRepositorioHistorico.buscarPorId(int id){
            //acá se usa una carga multiple de relaciones con Include
            //Este objeto tiene una lista llamada Variables, que es de objetos
            //HistoricoIndicador_Variable, internamente tiene relación con Variable
            //por eso se usa ThenInclude para poder mostrar el nombre de la variable que se guardo
            HistoricoIndicador buscado = conexionBD.dbset_historicos.
            Where(h => h.Id == id)
            .Include(v => v.Veterinario)
            .Include(g => g.Galpon)
            /* se quitó para hacer la consulta individualmente en el Model
            .Include(va => va.Variables)
            .ThenInclude(na => na.Variable)
            */
            .FirstOrDefault();

            return buscado;
        }

        IEnumerable<HistoricoIndicador> IRepositorioHistorico.traerTodosConFiltro(Galpon galpon){
            return conexionBD.dbset_historicos.Where(h => h.Galpon.Id == galpon.Id).ToList();
        }
    }
}