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
        private readonly IRepositorioPersona repoPer;

        public BorrarUsuarioModel(IRepositorioPersona repoPer){
            this.repoPer = repoPer;
        }

        public IActionResult OnGet(int idusuario)
        {
            detallePer = repoPer.buscarPorId(idusuario);
            return Page();
        }

        public IActionResult OnPost(){
            Console.WriteLine("id a borrar " + detallePer.Id);
            repoPer.eliminar(detallePer.Id);
            return RedirectToPage("Usuario");   
        }
    }
}
