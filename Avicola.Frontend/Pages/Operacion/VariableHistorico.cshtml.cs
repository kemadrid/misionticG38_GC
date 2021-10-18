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
    public class VariableHistoricoModel : PageModel
    {
        private readonly IRepositorioGeneral repoGeneral;
        
        public IEnumerable<Variable> variables_opciones { get; set; }

        [BindProperty]
        public int idVar_selected { get; set; }

        [BindProperty]
        public HistoricoIndicador_Variable objeto { get; set; }

        //id para identificar el historico al que le estan insertando las variables
        [BindProperty]
        public int id_historico { get; set; }
        public VariableHistoricoModel(IRepositorioGeneral repoGeneral)
        {
            this.repoGeneral = repoGeneral;

            Console.WriteLine("ctor ");
            variables_opciones = repoGeneral.traerTodosVariable();
            objeto = new HistoricoIndicador_Variable();
        }
        public IActionResult OnGet(int idHist)
        {

            id_historico = idHist;
            return Page();
        }
        public IActionResult OnPost()
        {
            Console.WriteLine("var selected " + idVar_selected);

            if (idVar_selected != -1)
            {
                if (ModelState.IsValid)
                {
                    HistoricoIndicador historico = repoGeneral.buscarPorIdHistorico(id_historico);
                    Variable variable_utilizada = repoGeneral.buscarPorIdVariable(idVar_selected);

                    //guardar el objeto
                    objeto = repoGeneral.anadirVariableHistorico(objeto);
                    //setearle los campos nuevos y actualizarlo
                    
                    if (objeto.Id>0)
                    {
                        //repoHistoVar.AsignarObjetos(aux.Id, id_historico, idVar_selected);
                        objeto.HistoricoIndicador = historico;
                        objeto.Variable = variable_utilizada;
                        objeto = repoGeneral.modificarVariableHistorico(objeto);
                        return RedirectToPage("DetalleHistorico", new { idhist = id_historico });
                        //return RedirectToPage("ResumenHistoricos");
                    }
                    else { return Page(); }
                }else { return Page(); }
            }
            else
            {
                return Page();
            }

        }
    }
}
