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
    public class VarModel : PageModel
    {
        public IEnumerable<Variable> variablesBD{get; set;}
        private readonly IRepositorioGeneral repoVar;

        public VarModel(IRepositorioGeneral repoVar){
            this.repoVar = repoVar;
        }
        public void OnGet()
        {
            variablesBD = repoVar.traerTodosVariable();
        }
    }
}
