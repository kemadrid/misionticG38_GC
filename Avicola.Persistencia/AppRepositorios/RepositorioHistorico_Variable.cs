using Avicola.Dominio;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        HistoricoIndicador_Variable IRepositorioHistorico_Variable.modificar(HistoricoIndicador_Variable eq, int histo, int vari){
            HistoricoIndicador_Variable buscado = conexionBD.dbset_historicosxvariables.FirstOrDefault(h => h.Id == eq.Id);
            IRepositorioHistorico repoHisto = new RepositorioHistorico();
            HistoricoIndicador objHisto = repoHisto.buscarPorId(histo);

            IRepositorioVariable repoVari = new RepositorioVariable();
            Variable objVar = repoVari.buscarPorId(vari);

            if(buscado != null){
                buscado.valor_float = eq.valor_float;
                buscado.valor_string = eq.valor_string;
                buscado.HistoricoIndicador = objHisto;
                buscado.Variable = objVar;
                //conexionBD.Update(buscado);
                conexionBD.SaveChanges();
            }
            return buscado;
        }
        HistoricoIndicador_Variable IRepositorioHistorico_Variable.modificarObjetos(HistoricoIndicador_Variable eq){
                conexionBD.Entry(eq).State = EntityState.Modified;
                conexionBD.SaveChanges();
            return eq;
        }
         HistoricoIndicador_Variable IRepositorioHistorico_Variable.AsignarObjetos(int idHiVa, int idHis, int idVar){
                IRepositorioHistorico repoH = new RepositorioHistorico();
                HistoricoIndicador histor = repoH.buscarPorId(idHis);
                IRepositorioVariable repoV = new RepositorioVariable();
                Variable vari = repoV.buscarPorId(idVar);

                HistoricoIndicador_Variable hv = new HistoricoIndicador_Variable();
                hv.Id = idHiVa;
                hv.HistoricoIndicador = histor;
                hv.Variable = vari;
                conexionBD.Entry(hv).State = EntityState.Modified;
                conexionBD.SaveChanges();
            return hv;
        }
        
        HistoricoIndicador_Variable IRepositorioHistorico_Variable.buscarPorId(int id){
            var buscado =  conexionBD.dbset_historicosxvariables.Find(id);
            return buscado;
        }

        IEnumerable<HistoricoIndicador_Variable> IRepositorioHistorico_Variable.traerTodosConFiltro(int histo){
            var todos= conexionBD.dbset_historicosxvariables
            .Include("Variable")
            .Include("HistoricoIndicador")
            .Where(h => h.HistoricoIndicador.Id == histo)
            .ToList();
            return todos;
        }
    }
}