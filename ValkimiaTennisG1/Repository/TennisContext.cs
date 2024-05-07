using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ValkimiaTennisG1.Repository
{
    public class TennisContext : DbContext
    {
        public TennisContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //builder.ApplyConfiguration(new AlumnoConfig());

            //builder.ApplyConfiguration(new AulaConfig());

            // por cada entidad que tengas en tu carpeta Models. Y tengan un Config de EntiyFramework.
            // Vamos a tener que hacer el builder.ApplyConfiguration()
        }

    }
}
