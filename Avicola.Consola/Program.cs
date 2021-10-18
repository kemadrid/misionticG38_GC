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

        private static IRepositorioHistorico _repoHisto = new RepositorioHistorico();   
        private static IRepositorioHistorico_Variable _repoHistoVar = new RepositorioHistorico_Variable();
        
        private static IRepositorioGeneral repoGeneral = new RepositorioGeneral();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Galpon p = new Galpon();

            Console.WriteLine("type " + p.GetType());
            
        }
        
    }
}
