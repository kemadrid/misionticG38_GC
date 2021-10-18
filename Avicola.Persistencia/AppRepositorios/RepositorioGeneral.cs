using System.Collections.Generic;
using Avicola.Dominio;
using System.Data;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;


namespace Avicola.Persistencia
{
    public class RepositorioGeneral : IRepositorioGeneral
    {
        
         private readonly AppContext conexionBD = new AppContext();

        //IMPLEMENTACION DE GALPON
        Galpon IRepositorioGeneral.AddGalpon(Galpon galpon)
       {
           var galponAdicionado = conexionBD.Galpones.Add(galpon);
           conexionBD.SaveChanges();
           return galponAdicionado.Entity;
       }


       void IRepositorioGeneral.DeleteGalpon(int idGalpon)
       {
           var galponEncontrado = conexionBD.Galpones.FirstOrDefault(g => g.Id==idGalpon);
           if(galponEncontrado==null)
           return;

           conexionBD.Galpones.Remove(galponEncontrado);
           conexionBD.SaveChanges();

       }

        IEnumerable<Galpon> IRepositorioGeneral.GetAllGalpones()
       {    
           return conexionBD.Galpones.Include("Veterinario").ToList();
       }

       IEnumerable<Galpon> IRepositorioGeneral.GetGalponesPorVeterinario(int idVet){
           var galpones = conexionBD.Galpones.Include("Veterinario")
           .Where(g => g.Veterinario.Id == idVet).ToList();
           return galpones;
       }

       Galpon IRepositorioGeneral.GetGalpon(int idGalpon)
       {
            return conexionBD.Galpones.Where(g => g.Id==idGalpon).FirstOrDefault();
       }

       Galpon IRepositorioGeneral.UpdateGalpon(Galpon galpon)
       {
           var galponEncontrado = conexionBD.Galpones.Find(galpon.Id);
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
               conexionBD.SaveChanges();
           }
           return galponEncontrado;
       }
       Galpon IRepositorioGeneral.AsignarVeterinario(Galpon galpon){
           /* FORMA 2 actualización parcial
           conexionBD.Galpones.Attach(galpon);
           conexionBD.Entry(galpon).Property(x => x.Veterinario).IsModified = true;
            conexionBD.SaveChanges();
           return galpon;
           */

           /*forma3, objeto externo actualizado*/
           conexionBD.Entry(galpon).State = EntityState.Modified; 
           conexionBD.SaveChanges();
           return galpon;
       }

       
       
       
       //IMPLEMENTACION DE PERSONA
       IEnumerable<Persona> IRepositorioGeneral.traerTodosPersona(){
           return conexionBD.dbset_personas;
        }

        Persona IRepositorioGeneral.anadirPersona(Persona eq){
           var PersonaGuardado =  conexionBD.dbset_personas.Add(eq);
           conexionBD.SaveChanges();
           return PersonaGuardado.Entity;
        }
        
        void IRepositorioGeneral.eliminarPersona(int id_Persona){
            Persona buscado = conexionBD.dbset_personas.FirstOrDefault(Persona => Persona.Id == id_Persona);
            if(buscado == null){
                return ;
            }
            conexionBD.dbset_personas.Remove(buscado);
            conexionBD.SaveChanges();
            
        }

        Persona IRepositorioGeneral.modificarPersona(Persona eq){
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
        
        Persona IRepositorioGeneral.buscarPorIdPersona(int id){
            Persona buscado = conexionBD.dbset_personas.FirstOrDefault(Persona => Persona.Id == id);
            return buscado;
        }

        IEnumerable<Persona> IRepositorioGeneral.traerTodosConFiltroPersona(tipoUsuario tipo_filtro){
            return conexionBD.dbset_personas.Where(p => p.tipo == tipo_filtro).ToList();
        }


        
        
        //IMPLEMENTACION REPOSITORIO VARIABLE
        IEnumerable<Variable> IRepositorioGeneral.traerTodosVariable(){
           return conexionBD.dbset_variables;
        }

        Variable IRepositorioGeneral.anadirVariable(Variable eq){
           var VariableGuardado =  conexionBD.dbset_variables.Add(eq);
           conexionBD.SaveChanges();
           return VariableGuardado.Entity;
        }
        
        void IRepositorioGeneral.eliminarVariable(int id_Variable){
            Variable buscado = conexionBD.dbset_variables.FirstOrDefault(Variable => Variable.Id == id_Variable);
            if(buscado == null){
                return ;
            }
            conexionBD.dbset_variables.Remove(buscado);
            conexionBD.SaveChanges();
        }

        Variable IRepositorioGeneral.modificarVariable(Variable eq){
            Variable buscado = conexionBD.dbset_variables.FirstOrDefault(Variable => Variable.Id == eq.Id);
            if(buscado != null){
                buscado.Nombre = eq.Nombre;
                buscado.Tipo = eq.Tipo;
                conexionBD.Update(buscado);
                conexionBD.SaveChanges();
            }
            return buscado;
        }
        
        Variable IRepositorioGeneral.buscarPorIdVariable(int id){
            Variable buscado = conexionBD.dbset_variables.FirstOrDefault(Variable => Variable.Id == id);
            return buscado;
        }





        //IMPLEMENTACION REPOSITORIO HISTORICO
        
        IEnumerable<HistoricoIndicador> IRepositorioGeneral.traerTodosHistorico(){
           return conexionBD.dbset_historicos.Include(h => h.Veterinario).Include(h=>h.Galpon).ToList();
        }

        HistoricoIndicador IRepositorioGeneral.anadirHistorico(HistoricoIndicador eq){
           var historico =  conexionBD.dbset_historicos.Add(eq);
           conexionBD.SaveChanges();

           //desacoplar
           conexionBD.Entry(eq).State = EntityState.Detached;
              
           return historico.Entity;
        }
        
HistoricoIndicador_Variable IRepositorioGeneral.anadirVariableHistorico(HistoricoIndicador_Variable eq){
    var historicovariable = conexionBD.dbset_historicosxvariables.Add(eq);
    conexionBD.SaveChanges();
    return historicovariable.Entity;
}
        HistoricoIndicador_Variable IRepositorioGeneral.modificarVariableHistorico(HistoricoIndicador_Variable eq){
             HistoricoIndicador_Variable buscado = conexionBD.dbset_historicosxvariables.FirstOrDefault(h => h.Id == eq.Id);
            if(buscado != null){
                buscado.HistoricoIndicador = eq.HistoricoIndicador;
                buscado.Variable = eq.Variable;
                conexionBD.SaveChanges();
            }
            return buscado;

        }
       IEnumerable<HistoricoIndicador_Variable> IRepositorioGeneral.traerTodosConFiltroHistorico(HistoricoIndicador historico){
            var result = conexionBD.dbset_historicosxvariables
            .Include("Variable")
            .Include("HistoricoIndicador")
            .Where(h => h.HistoricoIndicador.Id ==historico.Id).ToList();
            return result;
        }

        void IRepositorioGeneral.eliminarHistorico(int id_histo){
            HistoricoIndicador buscado = conexionBD.dbset_historicos.FirstOrDefault(h => h.Id == id_histo);
            if(buscado == null){
                return ;
            }
            conexionBD.dbset_historicos.Remove(buscado);
            conexionBD.SaveChanges();
            
        }

        HistoricoIndicador IRepositorioGeneral.modificarHistorico(HistoricoIndicador eq){
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
        
        HistoricoIndicador IRepositorioGeneral.modificarObjetosHistorico(HistoricoIndicador eq){
            conexionBD.Entry(eq).State = EntityState.Modified; 
            conexionBD.SaveChanges();
            return eq;
        }
        HistoricoIndicador IRepositorioGeneral.buscarPorIdHistorico(int id){
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

        IEnumerable<HistoricoIndicador> IRepositorioGeneral.traerTodosConFiltroHistorico(Galpon galpon){
            return conexionBD.dbset_historicos.Where(h => h.Galpon.Id == galpon.Id).ToList();
        }





    //IMPLEMENTACION REPOSITORIO HISTORICO VARIABLE

        IEnumerable<HistoricoIndicador_Variable> IRepositorioGeneral.traerTodosHistoVar(){
           return conexionBD.dbset_historicosxvariables;
        }

        HistoricoIndicador_Variable IRepositorioGeneral.anadirHistoVar(HistoricoIndicador_Variable eq){
           var historico =  conexionBD.dbset_historicosxvariables.Add(eq);
           conexionBD.SaveChanges();
           return historico.Entity;
        }
        
        void IRepositorioGeneral.eliminarHistoVar(int id_histo){
            HistoricoIndicador_Variable buscado = conexionBD.dbset_historicosxvariables.FirstOrDefault(h => h.Id == id_histo);
            if(buscado == null){
                return ;
            }
            conexionBD.dbset_historicosxvariables.Remove(buscado);
            conexionBD.SaveChanges();
            
        }

        HistoricoIndicador_Variable IRepositorioGeneral.modificarHistoVar(HistoricoIndicador_Variable eq, int histo, int vari){
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
        HistoricoIndicador_Variable IRepositorioGeneral.modificarObjetosHistoVar(HistoricoIndicador_Variable eq){
                conexionBD.Entry(eq).State = EntityState.Modified;
                conexionBD.SaveChanges();
            return eq;
        }
         HistoricoIndicador_Variable IRepositorioGeneral.AsignarObjetosHistoVar(int idHiVa, int idHis, int idVar){
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
        
        HistoricoIndicador_Variable IRepositorioGeneral.buscarPorIdHistoVar(int id){
            var buscado =  conexionBD.dbset_historicosxvariables.Find(id);
            return buscado;
        }

        IEnumerable<HistoricoIndicador_Variable> IRepositorioGeneral.traerTodosConFiltroHistoVar(int histo){
            var todos= conexionBD.dbset_historicosxvariables
            .Include("Variable")
            .Include("HistoricoIndicador")
            .Where(h => h.HistoricoIndicador.Id == histo)
            .ToList();
            return todos;
        }


    }
}