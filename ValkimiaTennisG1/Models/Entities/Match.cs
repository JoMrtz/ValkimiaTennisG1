using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ValkimiaTennisG1.Models.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public ICollection<MatchPlayer> MatchPlayers { get; set; }



        public class MatchConfig : IEntityTypeConfiguration<Match>
        {
            public void Configure(EntityTypeBuilder<Match> builder)
            {
                builder.ToTable("Match");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.Date).HasColumnName("Date").IsRequired();

                builder.HasMany(m => m.MatchPlayers).WithOne(mp => mp.Match).HasForeignKey(mp => mp.MatchId);

                builder.HasOne(m => m.Tournament).WithMany(t => t.Matches).HasForeignKey(m => m.TournamentId).IsRequired();
            }
        }
    }
}
