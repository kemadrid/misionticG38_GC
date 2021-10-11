using System.Collections.Generic;
using System;
namespace Avicola.Dominio
{
    public class HistoricoIndicador
    {
        public int Id {get;set;}
        public DateTime Fecha {get;set;}
        public Galpon Galpon {get;set;}
        public Persona Veterinario {get;set;}
        public List<HistoricoIndicador_Variable> Variables{get; set;}

    }
}