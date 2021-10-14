using Microsoft.EntityFrameworkCore;
using Avicola.Dominio;

namespace Avicola.Persistencia
{
    public class AppContext : DbContext 
    {
        // el nombre de este atributo corresponde al nombre de la tabla
        public DbSet<Variable> dbset_variables {get; set;}
        public DbSet<Persona> dbset_personas {get; set;}
        public DbSet<Galpon> Galpones {get;set;}
        public DbSet<HistoricoIndicador> dbset_historicos{get; set;}
        public DbSet<HistoricoIndicador_Variable> dbset_historicosxvariables{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                                 //optionsBuilder.UseSqlServer(@"Initial Catalog=granjaAvicolaDb; Data Source=DESKTOP-QRLUO62\SQLEXPRESS; Integrated Security=true"); 
               optionsBuilder.UseSqlServer("Data Source = KM-HP\\SQLEXPRESS; Initial Catalog = granjaAvicolaDb;User ID= sa ;Password= adminbd;");
            }
        }
    }
}