using System;
using Avicola.Dominio;
using Avicola.Persistencia;

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
        }
    }
}
