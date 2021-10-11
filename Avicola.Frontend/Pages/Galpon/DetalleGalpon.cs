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
    public class DetalleGalponModel : PageModel
    {
        private readonly IRepositorioGalpon _repoGalpon;
        public Galpon galpon {get;set;}
        public DetalleGalponModel(IRepositorioGalpon repoGalpon)
        {
            _repoGalpon = repoGalpon;
        }

        public IActionResult OnGet(int id)
        {
            galpon = _repoGalpon.GetGalpon(id);
            if (galpon == null)
            {
                return NotFound();
            } else
            {
                return Page();
            }
        }
    }
}