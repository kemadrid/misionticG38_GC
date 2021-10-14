using Avicola.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Avicola.Persistencia
{
    public class RepositorioHistorico_Variable : IRepositorioHistorico_Variable
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

        IEnumerable<HistoricoIndicador_Variable> IRepositorioHistorico_Variable.traerTodos(){
           return conexionBD.dbset_historicosxvariables;
        }

        HistoricoIndicador_Variable IRepositorioHistorico_Variable.anadir(HistoricoIndicador_Variable eq){
           var historico =  conexionBD.dbset_historicosxvariables.Add(eq);
           conexionBD.SaveChanges();
           return historico.Entity;
        }
        
        void IRepositorioHistorico_Variable.eliminar(int id_histo){
            HistoricoIndicador_Variable buscado = conexionBD.dbset_historicosxvariables.FirstOrDefault(h => h.Id == id_histo);
            if(buscado == null){
                return ;
            }
            conexionBD.dbset_historicosxvariables.Remove(buscado);
            conexionBD.SaveChanges();
            
        }

        HistoricoIndicador_Variable IRepositorioHistorico_Variable.modificar(HistoricoIndicador_Variable eq){
            HistoricoIndicador_Variable buscado = conexionBD.dbset_historicosxvariables.FirstOrDefault(h => h.Id == eq.Id);
            if(buscado != null){
                buscado.HistoricoIndicador = eq.HistoricoIndicador;
                buscado.Variable = eq.Variable;
                buscado.valor_float = eq.valor_float;
                buscado.valor_string = eq.valor_string;
                conexionBD.Update(buscado);
                conexionBD.SaveChanges();
            }
            return buscado;

            
        }
        
        HistoricoIndicador_Variable IRepositorioHistorico_Variable.buscarPorId(int id){
            HistoricoIndicador_Variable buscado = conexionBD.dbset_historicosxvariables.FirstOrDefault(h => h.Id == id);
            return buscado;
        }

        IEnumerable<HistoricoIndicador_Variable> IRepositorioHistorico_Variable.traerTodosConFiltro(HistoricoIndicador histo){
            return conexionBD.dbset_historicosxvariables.Where(h => h.HistoricoIndicador.Id == histo.Id).ToList();
        }
    }
}