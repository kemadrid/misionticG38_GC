using Avicola.Dominio;
using System.Collections.Generic;
using System.Linq;

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
           return conexionBD.dbset_historicos;
        }

        HistoricoIndicador IRepositorioHistorico.anadir(HistoricoIndicador eq){
           var historico =  conexionBD.dbset_historicos.Add(eq);
           conexionBD.SaveChanges();
           return historico.Entity;
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
            HistoricoIndicador buscado = conexionBD.dbset_historicos.FirstOrDefault(h => h.Id == eq.Id);
            if(buscado != null){
                buscado.Fecha = eq.Fecha;
                buscado.Galpon = eq.Galpon;
                buscado.Veterinario = eq.Veterinario;
                buscado.Variables = eq.Variables;
                conexionBD.Update(buscado);
                conexionBD.SaveChanges();
            }
            return buscado;

            
        }
        
        HistoricoIndicador IRepositorioHistorico.buscarPorId(int id){
            HistoricoIndicador buscado = conexionBD.dbset_historicos.FirstOrDefault(h => h.Id == id);
            return buscado;
        }

        IEnumerable<HistoricoIndicador> IRepositorioHistorico.traerTodosConFiltro(Galpon galpon){
            return conexionBD.dbset_historicos.Where(h => h.Galpon.Id == galpon.Id).ToList();
        }
    }
}