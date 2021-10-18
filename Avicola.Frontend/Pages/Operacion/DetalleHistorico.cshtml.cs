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
        private readonly IRepositorioGeneral repoGeneral;
        public HistoricoIndicador historicoDetalle{get; set;}
        public string nombre_completo{get; set;}
        public IEnumerable<HistoricoIndicador_Variable> variables_historico{get; set;}
        public DetalleHistoricoModel(IRepositorioGeneral repoGeneral){
            this.repoGeneral = repoGeneral;
            
        }
        public IActionResult OnGet(int idhist){
            
             historicoDetalle = repoGeneral.buscarPorIdHistorico(idhist);
             nombre_completo = historicoDetalle.Veterinario.Nombre + " "+ historicoDetalle.Veterinario.Apellido;
             variables_historico = repoGeneral.traerTodosConFiltroHistoVar(idhist);
             
             return Page();   
        }
    }
}
