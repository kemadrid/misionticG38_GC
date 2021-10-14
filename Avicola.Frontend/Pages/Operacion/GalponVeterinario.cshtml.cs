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

        private readonly IRepositorioGalpon repoGalpon;
        private readonly IRepositorioPersona repoPersona;
        public int idVet{get; set;}

        public IEnumerable<Persona> veterinarios{get; set;}
        public IEnumerable<Galpon> galpones{get; set;}

        public GalponVeterinarioModel(IRepositorioGalpon repoG, IRepositorioPersona repoP){
            this.repoGalpon=repoG;
            this.repoPersona=repoP;
        }
        public IActionResult OnGet(int? idVet)
        {   
            veterinarios = repoPersona.traerTodosConFiltro(tipoUsuario.VETERINARIO);
            if(idVet.HasValue){
                //mostrar los datos
                galpones = repoGalpon.GetGalponesPorVeterinario(idVet.Value);
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
