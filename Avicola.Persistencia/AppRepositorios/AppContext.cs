using Microsoft.EntityFrameworkCore;
using Avicola.Dominio;

namespace Avicola.Persistencia
{
    public class AppContext : DbContext 
    {
        public DbSet<Variable> dbset_variables {get; set;}
        public DbSet<Persona> dbset_personas {get; set;}
        public DbSet<Galpon> Galpones {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                                 //optionsBuilder.UseSqlServer(@"Initial Catalog=granjaAvicolaDb; Data Source=DESKTOP-QRLUO62\SQLEXPRESS; Integrated Security=true"); 
               optionsBuilder.UseSqlServer(@"Initial Catalog=AvicolaDb; Data Source=DESKTOP-QRLUO62\SQLEXPRESS; Integrated Security=true");
            }
        }
    }
}