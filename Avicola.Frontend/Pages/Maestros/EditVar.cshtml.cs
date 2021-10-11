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
    public class EditVarModel : PageModel
    {
         [BindProperty]
        public Variable nuevaVar{get; set;}

        private readonly IRepositorioVariable repoVar;
        public EditVarModel(IRepositorioVariable repoVar){
            this.repoVar = repoVar;
        }
        public void OnGet()
        {
            nuevaVar = new Variable();
        }

        public IActionResult OnPost(){
            if(nuevaVar.Nombre != null){
               Variable nueva =  repoVar.anadir(nuevaVar);
                return RedirectToPage("Var");
            }
            return Page();
        }
    }
}
