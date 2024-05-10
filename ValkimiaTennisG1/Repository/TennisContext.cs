using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using static ValkimiaTennisG1.Models.Entities.Player;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Enums;
using static ValkimiaTennisG1.Models.Entities.Match;
using static ValkimiaTennisG1.Models.Entities.Gender;
using static ValkimiaTennisG1.Models.Entities.Tournament;

namespace ValkimiaTennisG1.Repository
{
    public class TennisContext : DbContext
    {

        public DbSet<Player> Player { get; set; }
        public DbSet<Match> Match { get; set; }   
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
        //public DbSet<MatchPlayer> MatchPlayer { get; set; }


        public TennisContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Seed de la tabla Gender con los valores del Enum
            builder.Entity<Gender>().HasData(
                new Gender { Id = 1, GenderType = GenderType.Man },
                new Gender { Id = 2, GenderType = GenderType.Woman }
            );
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //builder.ApplyConfiguration(new PlayerConfig());
            //builder.ApplyConfiguration(new MatchConfig());
            //builder.ApplyConfiguration(new GenderConfig());
            //builder.ApplyConfiguration(new TournamentConfig());

            //builder.ApplyConfiguration(new AulaConfig());

            // por cada entidad que tengas en tu carpeta Models. Y tengan un Config de EntiyFramework.
            // Vamos a tener que hacer el builder.ApplyConfiguration()
        }

    }
}
