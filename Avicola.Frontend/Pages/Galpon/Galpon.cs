using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Avicola.Dominio;
using Avicola.Persistencia;


namespace Avicola.FrontEnd.Pages
{
    public class GalponModel : PageModel
    {
        
        private readonly IRepositorioGeneral repoGeneral;

        public IEnumerable<Persona> veterinarios{get; set;}
        [BindProperty]
        public int veterinarioSelected{get; set;}
        
        [BindProperty]
        public Galpon galpon {get;set;}
        public GalponModel(IRepositorioGeneral repoGeneral)
        {
            this.repoGeneral = repoGeneral;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                galpon = repoGeneral.GetGalpon(id.Value);
                if(galpon != null && galpon.Veterinario!=null){
                veterinarioSelected = galpon.Veterinario.Id;
                }
            }else{
                galpon = new Galpon();
                galpon.FechaIngAnimales = DateTime.Now;
                galpon.FechaSalAnimales = DateTime.Now;
            }
            //cargar la lista de veterinarios
            veterinarios = repoGeneral.traerTodosConFiltroPersona(tipoUsuario.VETERINARIO);
            
            return Page(); 
             
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (galpon.Id==0)
                {
                  galpon = repoGeneral.AddGalpon(galpon);
                }
                //validemos el veterinario seleccionado y asignarlo
                Persona veterinario = null;
                if(veterinarioSelected != -1){
                    veterinario = repoGeneral.buscarPorIdPersona(veterinarioSelected);
                    if(veterinario!=null){
                        galpon.Veterinario = veterinario;
                        repoGeneral.UpdateGalpon(galpon);
                    }
                }
                //asignar veterinario al galpon
                return RedirectToPage("ConsultaGalpon");
            } else
            {
               return Page();
            }
           
        }
    }
}
