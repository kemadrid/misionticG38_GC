using System.ComponentModel.DataAnnotations;
namespace Avicola.Dominio
{
    public class Persona
    {
        
        public int Id {get;set;}
        
        [Required, StringLength(50)]
        public string Nombre {get;set;}
        
        [Required, StringLength(50)]
        public string Apellido {get;set;}
        
        [Required, StringLength(15)]
        public string Cedula {get;set;}

        [Required, StringLength(50)]
        public string Email {get;set;}
        
        [Required, StringLength(50)]
        public string Telefono {get;set;}
        
        public tipoUsuario tipo {get;set;}
    }
}