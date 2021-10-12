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
    public class ConsultaGalponModel : PageModel
    {
        private readonly IRepositorioGalpon _repoGalpon;
        public IEnumerable<Galpon> galpones {get;set;}
        public ConsultaGalponModel(IRepositorioGalpon repoGalpon)
        {
            _repoGalpon = repoGalpon;
        }

        /*public IActionResult OnGet(int id)
        {
            galpon = _repoGalpon.GetGalpon(id);
            if (galpon == null)
            {
                return NotFound();
            } 
        }*/
         public void OnGet()
        {
            galpones=_repoGalpon.GetAllGalpones();
            foreach (Galpon g in galpones)
            {
                if(g.Veterinario != null){
                    Console.WriteLine("vete " + g.Veterinario.Nombre);
                }
            }
        }
            
    }
}