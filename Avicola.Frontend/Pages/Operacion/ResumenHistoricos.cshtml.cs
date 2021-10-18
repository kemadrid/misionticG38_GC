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
    public class ResumenHistoricosModel : PageModel
    {
        private readonly IRepositorioGeneral repoGeneral;
        public IEnumerable<HistoricoIndicador> historicos {get; set;}
        public ResumenHistoricosModel(IRepositorioGeneral repoGeneral){
            this.repoGeneral = repoGeneral;
        }
        public void OnGet()
        {
            historicos = repoGeneral.traerTodosHistorico();
        }
    }
}
