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
    public class UsuarioModel : PageModel
    {
        public IEnumerable<Persona> personasBD{get; set;}
        private readonly IRepositorioGeneral repoPer;

        public UsuarioModel(IRepositorioGeneral repoPer){
            this.repoPer = repoPer;
        }
        public void OnGet()
        {
           personasBD = repoPer.traerTodosPersona(); 
        }
    }
}
