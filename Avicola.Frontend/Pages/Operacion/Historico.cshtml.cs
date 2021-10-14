using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Avicola.Dominio;
using Avicola.Persistencia;

namespace Avicola.Frontend.Pages
{
    
    public class HistoricoModel : PageModel
    {   
        //repositorios
        private readonly IRepositorioPersona repoPer;
        private readonly IRepositorioGalpon repoGal;
        private readonly IRepositorioVariable repoVar;
        private readonly IRepositorioHistorico repoHisto;

        [BindProperty]
        //listas para seleccion de datos
        public IEnumerable<Galpon> galpones{get; set;}
        public IEnumerable<Persona> veterinarios{get; set;}
        public IEnumerable<Variable> variables_medicion{get; set;}

        //historico que se construye o diligencia en la vista
        
        
        public HistoricoIndicador historico{get; set;}
        
        //id del veterinario seleccionado en el select
        public int idVet_selected{get; set;}
        
        //id del galpon seleccionado en el select
        public int idGal_selected{get; set;}

        //lista de Variables para armar luego el historico
        public List<HistoricoIndicador_Variable> variables_guardar{get; set;}

        public HistoricoModel(IRepositorioGalpon repoG, IRepositorioPersona repoP, IRepositorioVariable repoV, IRepositorioHistorico repoH){
            this.repoPer = repoP;
            this.repoGal = repoG;
            this.repoVar = repoV;
            this.repoHisto = repoH;

            galpones = repoGal.GetAllGalpones();
            veterinarios = repoPer.traerTodosConFiltro(tipoUsuario.VETERINARIO);
            variables_medicion = repoVar.traerTodos();
            variables_guardar = new List<HistoricoIndicador_Variable>();

            historico = new HistoricoIndicador();
            historico.Fecha = DateTime.Now;
            historico.Variables = new List<HistoricoIndicador_Variable>();
            foreach(var v in variables_medicion){
                HistoricoIndicador_Variable hisV = new HistoricoIndicador_Variable();
                hisV.Variable = v;
                //variables_guardar.Add(hisV);
                historico.Variables.Add(hisV);
            }
            Console.WriteLine("onget vars " + variables_guardar.Count);
        }
        public void OnGet()
        {
            //lo que se pone aqui solo dura mientras se ve en la pagina, en el onpost ya no esta
            
            
        }

        public IActionResult OnPost(){
            Console.WriteLine("Puedo usar " + historico.Fecha);
            Console.WriteLine("Puedo usar vet" + idVet_selected);
            Console.WriteLine("Puedo usar gal" + idGal_selected);
            
            //Console.WriteLine("variables " + variables_guardar.Count);
            Console.WriteLine("variables " + historico.Variables.Count);
            foreach (var item in historico.Variables)
            {
                Console.WriteLine(item.valor_float);
                Console.WriteLine(item.valor_string);
                Console.WriteLine(item.HistoricoIndicador);
                Console.WriteLine(item.Variable.Nombre);
            }
            //repoHisto.anadir(historico);
          return Page();      
        }
    }
}

