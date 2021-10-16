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

        
        //listas para seleccion de datos
        public IEnumerable<Galpon> galpones{get; set;}
        public IEnumerable<Persona> veterinarios{get; set;}

        
        
        [BindProperty]
        public HistoricoIndicador historico{get; set;}
        
        //id del veterinario seleccionado en el select
        [BindProperty]
        public int idVet_selected{get; set;}
        
        //id del galpon seleccionado en el select
        [BindProperty]
        public int idGal_selected{get; set;}

        public HistoricoModel(IRepositorioGalpon repoG, IRepositorioPersona repoP, IRepositorioVariable repoV, IRepositorioHistorico repoH){
            this.repoPer = repoP;
            this.repoGal = repoG;
            this.repoVar = repoV;
            this.repoHisto = repoH;

            galpones = repoGal.GetAllGalpones();
            veterinarios = repoPer.traerTodosConFiltro(tipoUsuario.VETERINARIO);
        }
        public void OnGet()
        {
            //lo que se pone aqui solo dura mientras se ve en la pagina, en el onpost ya no esta
            historico = new HistoricoIndicador();
            historico.Fecha = DateTime.Now;
        }

        public IActionResult OnPost(){
            //seleccionaron Veterinario
            Console.WriteLine("onpost vet" + idVet_selected);
            Console.WriteLine("onpost gal" + idGal_selected);
            Persona vet = null;
            Galpon gal = null;
            if(idVet_selected != -1){
                vet = repoPer.buscarPorId(idVet_selected);
            }
            //Seleccionaron Galpon
            if(idGal_selected != -1){
                gal = repoGal.GetGalpon(idGal_selected);
            }else{
                return Page();
            }
            historico = repoHisto.anadir(historico);
            
            //setear el galpon y veterinario y luego actualizar
            if(historico.Id>0){
                if(gal != null){
                    historico.Galpon = gal;
                }
                if(vet != null){
                    historico.Veterinario = vet;
                }
                repoHisto.modificar(historico);
            }
            //actualizar el historico
            
            return RedirectToPage("DetalleHistorico", new {idhist=historico.Id});
        }
    }
}

