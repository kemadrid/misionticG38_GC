using System;
using System.ComponentModel.DataAnnotations;
namespace Avicola.Dominio
{
    public class Variable
    {
        public int Id{get; set;}
        [Required]
        public string Nombre{get; set;}
        public Enum_TipoVariable Tipo{get; set;}
    }
}