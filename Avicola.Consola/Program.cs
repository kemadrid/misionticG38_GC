using System;
using Avicola.Dominio;
using Avicola.Persistencia;
using System.Collections.Generic;

namespace Avicola.Consola
{
    class Program
    {
        private static IRepositorioVariable _repoVariable = new RepositorioVariable();        
        private static IRepositorioPersona _repoPersona = new RepositorioPersona();        
        private static IRepositorioGalpon _repoGalpon = new RepositorioGalpon();        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //mostrarVeterinario();
            //galpones_x_vete(3);
            DateTime fecha = DateTime.Now;
            DateTime fecha2 = default(DateTime);
            Console.WriteLine(fecha);
            Console.WriteLine(fecha2);
        }

        private static void mostrarVeterinario(){
            IEnumerable<Galpon> todos = _repoGalpon.GetAllGalpones();
            foreach (Galpon item in todos)
            {
                Console.WriteLine(item.Nombre);
                Console.WriteLine(item.Veterinario.Nombre);
            }
        }
        private static void galpones_x_vete(int id){
            IEnumerable<Galpon> todos = _repoGalpon.GetGalponesPorVeterinario(id);
            foreach (Galpon item in todos)
            {
                Console.WriteLine(item.Nombre);
                Console.WriteLine(item.Veterinario.Nombre);
            }
        }
    }
}
