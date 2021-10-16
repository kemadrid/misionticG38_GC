using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avicola.Frontend.Pages
{
    
    public class pruebasModel : PageModel
    {   
        [BindProperty]
        public List<string> lista{get; set;}
        public pruebasModel(){
            lista = new List<string>();
            lista.Add("ele1");
            lista.Add("ele2");
        }
        public void OnGet()
        {
            //lo inicia aqui  queda vacia por defecto al finalizar el onget
            
            
            Console.WriteLine("en get " + lista.Count);

        }

        public IActionResult OnPost(List<string> lista){
            Console.WriteLine("en onpost " + lista.Count);
            return Page();
        }
    }
}
