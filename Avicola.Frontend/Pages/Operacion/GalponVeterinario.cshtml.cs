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
    public class GalponVeterinarioModel : PageModel
    {   

        private readonly IRepositorioGeneral repoGeneral;
        public int idVet{get; set;}

        public IEnumerable<Persona> veterinarios{get; set;}
        public IEnumerable<Galpon> galpones{get; set;}

        public GalponVeterinarioModel(IRepositorioGeneral repoG){
            this.repoGeneral = repoG;
        }
        public IActionResult OnGet(int? idVet)
        {   
            veterinarios = repoGeneral.traerTodosConFiltroPersona(tipoUsuario.VETERINARIO);
            if(idVet.HasValue){
                //mostrar los datos
                galpones = repoGeneral.GetGalponesPorVeterinario(idVet.Value);
            }
            return Page();
        }

        public IActionResult OnPost(){
            if(idVet!= -1){
                Console.WriteLine("Envio este " + idVet);
                return RedirectToPage("GalponVeterinario",idVet);
            }else{
                return Page();
            }
        }
    }
}
