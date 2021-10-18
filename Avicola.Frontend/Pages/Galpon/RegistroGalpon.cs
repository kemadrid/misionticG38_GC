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
    public class RegistroGalponModel : PageModel
    {
        private readonly IRepositorioGeneral _repoGalpon;
        //[BindProperty]
        public Galpon galpon {get;set;}
        public RegistroGalponModel(IRepositorioGeneral repoGalpon)
        {
            _repoGalpon = repoGalpon;
        }

        public void OnGet()
        {
            galpon = new Galpon();
        }

        public IActionResult OnPost(Galpon galpon)
        {
            if (ModelState.IsValid)
            {
                _repoGalpon.AddGalpon(galpon);
                return RedirectToPage("RegistroGalpon");
            } else
            {
                return Page();
            }
        }
    }
}