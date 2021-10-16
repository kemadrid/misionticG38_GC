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
        private readonly IRepositorioVariable repoVar;

        [BindProperty]
        public Variable nuevaVar { get; set; }


        public EditVarModel(IRepositorioVariable repoVar)
        {
            this.repoVar = repoVar;
        }
        public void OnGet()
        {
            /*
            if (idvar.HasValue)
            {
                nuevaVar = repoVar.buscarPorId(idvar.Value);
            }
            else
            {
                nuevaVar = new Variable();
            }
            return Page();
            */
            nuevaVar = new Variable();
        }

        public IActionResult OnPost()
        {
            if (nuevaVar.Id > 0)
            {
                Variable update = repoVar.modificar(nuevaVar);   
            }else{
                Variable nueva = repoVar.anadir(nuevaVar);
                
            }
            return RedirectToPage("Var");
        }
    }
}
