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
        [BindProperty]
        public Galpon galpon {get;set;}
        public GalponModel(IRepositorioGalpon repoGalpon)
        {
            _repoGalpon = repoGalpon;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                galpon = _repoGalpon.GetGalpon(id.Value);
            }else{
                galpon = new Galpon();
            }
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
                    _repoGalpon.AddGalpon(galpon);
                    
                }
                return RedirectToPage("Galpon");
                
            } else
            {
               return Page();
            }
           
        }
    }
}
