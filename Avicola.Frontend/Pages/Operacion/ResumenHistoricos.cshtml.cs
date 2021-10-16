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
        private readonly IRepositorioHistorico repoHisto;
        public IEnumerable<HistoricoIndicador> historicos;
        public ResumenHistoricosModel(IRepositorioHistorico repoHisto){
            this.repoHisto = repoHisto;
        }
        public void OnGet()
        {
            historicos = repoHisto.traerTodos();
        }
    }
}
