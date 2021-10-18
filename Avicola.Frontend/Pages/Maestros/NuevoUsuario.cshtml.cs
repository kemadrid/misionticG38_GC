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
    public class NuevoUsuarioModel : PageModel
    {
        [BindProperty]
        public Persona nuevaPer{get; set;}

        
        private readonly IRepositorioGeneral repoPer;
        public NuevoUsuarioModel(IRepositorioGeneral repoPer){
            this.repoPer = repoPer;
        }
        public IActionResult OnGet(int? idusuario)
        {
            if(idusuario.HasValue){
                //editar
                nuevaPer = repoPer.buscarPorIdPersona(idusuario.Value);
                Console.WriteLine("id parametro " + idusuario.Value);
                
            }else{
                nuevaPer = new Persona();
            }
            
            Console.WriteLine("id ONGET " + nuevaPer.Id);
            return Page();

        }

        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            if(nuevaPer.Id>0){
                //editando
              nuevaPer =  repoPer.modificarPersona(nuevaPer);
            }
            else{
            repoPer.anadirPersona(nuevaPer);
            }
            return RedirectToPage("Usuario");
        }
    }
}
