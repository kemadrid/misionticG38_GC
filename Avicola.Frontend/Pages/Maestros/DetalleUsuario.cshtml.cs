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
    public class DetalleUsuarioModel : PageModel
    {
        public Persona detallePer {get; set;}
        private readonly IRepositorioGeneral repoPer;

        public DetalleUsuarioModel(IRepositorioGeneral repoPer){
            this.repoPer = repoPer;
        }
        public IActionResult OnGet(int idusuario)
        {
            detallePer = repoPer.buscarPorIdPersona(idusuario);
            if(detallePer == null){
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}
