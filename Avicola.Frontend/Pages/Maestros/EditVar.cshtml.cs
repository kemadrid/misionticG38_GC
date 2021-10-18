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
        private readonly IRepositorioGeneral repoVar;

        [BindProperty]
        public Variable nuevaVar { get; set; }


        public EditVarModel(IRepositorioGeneral repoVar)
        {
            this.repoVar = repoVar;
        }
        public IActionResult OnGet(int? idvar)
        {
            
            if (idvar.HasValue)
            {
                nuevaVar = repoVar.buscarPorIdVariable(idvar.Value);
            }
            else
            {
                nuevaVar = new Variable();
            }
            return Page();
            
        }

        public IActionResult OnPost()
        {
            if (nuevaVar.Id > 0)
            {
                Variable update = repoVar.modificarVariable(nuevaVar);   
            }else{
                Variable nueva = repoVar.anadirVariable(nuevaVar);
                
            }
            return RedirectToPage("Var");
        }
    }
}
