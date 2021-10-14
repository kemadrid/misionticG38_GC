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
        
        private readonly IRepositorioGalpon _repoGalpon;
        private readonly IRepositorioPersona _repoPersona;

        public IEnumerable<Persona> veterinarios{get; set;}
        [BindProperty]
        public int veterinarioSelected{get; set;}
        
        [BindProperty]
        public Galpon galpon {get;set;}
        public GalponModel(IRepositorioGalpon repoGalpon, IRepositorioPersona repoPersona)
        {
            _repoGalpon = repoGalpon;
            _repoPersona = repoPersona;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                galpon = _repoGalpon.GetGalpon(id.Value);
            }else{
                galpon = new Galpon();
                galpon.FechaIngAnimales = DateTime.Now;
                galpon.FechaSalAnimales = DateTime.Now;
            }
            //cargar la lista de veterinarios
            veterinarios = _repoPersona.traerTodosConFiltro(tipoUsuario.VETERINARIO);
            
            return Page(); 
             
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (galpon.Id>0)
                {
                    galpon = _repoGalpon.UpdateGalpon(galpon);
                }else{
                  galpon = _repoGalpon.AddGalpon(galpon);
                    
                }

                //validemos el veterinario seleccionado y asignarlo
                Persona veterinario = null;
                if(veterinarioSelected != -1){
                    veterinario = _repoPersona.buscarPorId(veterinarioSelected);
                    if(veterinario!=null){
                        galpon.Veterinario = veterinario;
                         _repoGalpon.UpdateGalpon(galpon);
                    }
                }
                
                //asignar veterinario al galpon
                return RedirectToPage("Galpon");
                
            } else
            {
               return Page();
            }
           
        }
    }
}
