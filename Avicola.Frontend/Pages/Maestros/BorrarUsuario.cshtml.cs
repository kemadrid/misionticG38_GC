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
    public class BorrarUsuarioModel : PageModel
    {
        [BindProperty]
        public Persona detallePer{get; set;}
        private readonly IRepositorioGeneral repoPer;

        public BorrarUsuarioModel(IRepositorioGeneral repoPer){
            this.repoPer = repoPer;
        }

        public IActionResult OnGet(int idusuario)
        {
            detallePer = repoPer.buscarPorIdPersona(idusuario);
            return Page();
        }

        public IActionResult OnPost(){
            Console.WriteLine("id a borrar " + detallePer.Id);
            repoPer.eliminarPersona(detallePer.Id);
            return RedirectToPage("Usuario");   
        }
    }
}
