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
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //mostrarVeterinario();
            //galpones_x_vete(3);
            DateTime fecha = DateTime.Now;
            DateTime fecha2 = default(DateTime);
            Console.WriteLine(fecha);
            Console.WriteLine(fecha2);
            //creaHistorico();
            //modificarObjetosHistorico();
            anadirVariables();
        }
        private static void creaHistorico(){
            HistoricoIndicador  historico = new HistoricoIndicador();
             historico = _repoHisto.anadir(historico);

        }
        private static void modificarObjetosHistorico(){
            HistoricoIndicador historico = _repoHisto.buscarPorId(34);
            Variable var = _repoVariable.buscarPorId(3);
            Persona per = _repoPersona.buscarPorId(3);
            Galpon gal = _repoGalpon.GetGalpon(4); //4 5 6
            Console.WriteLine("existe " + historico.Id);
            Console.WriteLine("existe " + var.Id);
            Console.WriteLine("existe " + per.Id);
            Console.WriteLine("existe " + gal.Id);
            historico.Galpon = gal;
            historico.Veterinario = per;
            _repoHisto.modificar(historico);

        }
        private static void anadirVariables(){
            HistoricoIndicador historico = _repoHisto.buscarPorId(35);
            HistoricoIndicador historico2 = _repoHisto.buscarPorId(36);
            Variable var1 = _repoVariable.buscarPorId(1);
            Variable var2 = _repoVariable.buscarPorId(2);
            Variable var3 = _repoVariable.buscarPorId(3);
            
            HistoricoIndicador_Variable varh = new HistoricoIndicador_Variable();
            varh.valor_string ="45";
            varh = _repoHistoVar.anadir(varh);
            varh.HistoricoIndicador=historico;
            varh.Variable = var1;
            _repoHistoVar.modificar(varh);

HistoricoIndicador_Variable varh2 = new HistoricoIndicador_Variable();
            varh2.valor_string ="50";
            varh2 = _repoHistoVar.anadir(varh2);
            varh2.HistoricoIndicador=historico;
            varh2.Variable = var2;
            _repoHistoVar.modificar(varh2);

            HistoricoIndicador_Variable varh3 = new HistoricoIndicador_Variable();
            varh3.valor_string ="55";
            varh3 = _repoHistoVar.anadir(varh3);
            varh3.HistoricoIndicador=historico;
            varh3.Variable = var3;
            _repoHistoVar.modificar(varh3);

            //historico 36
            HistoricoIndicador_Variable varh4 = new HistoricoIndicador_Variable();
            varh4.valor_string ="45";
            varh4 = _repoHistoVar.anadir(varh4);
            varh4.HistoricoIndicador=historico2;
            varh4.Variable = var3;
            _repoHistoVar.modificar(varh);

HistoricoIndicador_Variable varh5 = new HistoricoIndicador_Variable();
            varh5.valor_string ="50";
            varh5 = _repoHistoVar.anadir(varh5);
            varh5.HistoricoIndicador=historico2;
            varh5.Variable = var2;
            _repoHistoVar.modificar(varh5);

            HistoricoIndicador_Variable varh6 = new HistoricoIndicador_Variable();
            varh6.valor_string ="55";
            varh6 = _repoHistoVar.anadir(varh6);
            varh6.HistoricoIndicador=historico2;
            varh6.Variable = var3;
            _repoHistoVar.modificar(varh6);
        Console.WriteLine("Termina inserts");
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
