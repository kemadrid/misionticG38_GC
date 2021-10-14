using System;
using System.ComponentModel.DataAnnotations;

namespace Avicola.Dominio
{
    public class Galpon
    {
        public int Id {get;set;}
        [Required, StringLength(50)]
        public string Nombre {get;set;}

        [Required, StringLength(50)]
        public string Ubicacion {get;set;}

        [Required]
        //[RegularExpression("[0-9],[0-9]",ErrorMessage = "Este campo solo admite numeros")]
        public float CantidadAnimales {get;set;}

        [Required]
        public DateTime FechaIngAnimales {get;set;}

        [Required]
        public DateTime FechaSalAnimales {get;set;}

        [Required]
        //[RegularExpression("[0-9]",ErrorMessage = "Este campo solo admite numeros")]
        public float Latitud {get;set;}

        [Required]
        //[RegularExpression("[0-9]",ErrorMessage = "Este campo solo admite numeros")]
        public float Longitud {get;set;}

        //[Required]
        //[RegularExpression("[0-9]",ErrorMessage = "Este campo solo admite numeros")]
        public Persona Operario{get;set;}

        //[Required]
        //[RegularExpression("[0-9]",ErrorMessage = "Este campo solo admite numeros")]
        public Persona Veterinario {get;set;}

        
        //public Persona Auxiliar{get;set;}
        
    }

}