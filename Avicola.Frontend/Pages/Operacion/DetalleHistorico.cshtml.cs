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
    public class DetalleHistoricoModel : PageModel
    {   
        private readonly IRepositorioHistorico repoHisto;
        private readonly IRepositorioHistorico_Variable repoHistoVar;
        public HistoricoIndicador historicoDetalle{get; set;}
        public string nombre_completo{get; set;}
        public IEnumerable<HistoricoIndicador_Variable> variables_historico{get; set;}
        public DetalleHistoricoModel(IRepositorioHistorico repoHisto, IRepositorioHistorico_Variable repoHistoVar){
            this.repoHisto = repoHisto;
            this.repoHistoVar = repoHistoVar;
        }
        public IActionResult OnGet(int idhist){
            
             historicoDetalle = repoHisto.buscarPorId(idhist);
             nombre_completo = historicoDetalle.Veterinario.Nombre + " "+ historicoDetalle.Veterinario.Apellido;
             variables_historico = repoHistoVar.traerTodosConFiltro(idhist);
             
             return Page();   
        }
    }
}
