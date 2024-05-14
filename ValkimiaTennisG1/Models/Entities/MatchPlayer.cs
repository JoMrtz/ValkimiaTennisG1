using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ValkimiaTennisG1.Models.Entities
{
    public class MatchPlayer
    {

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public bool Winner { get; set; }
    }
    public class MatchPlayerConfig : IEntityTypeConfiguration<MatchPlayer>
    {
        public void Configure(EntityTypeBuilder<MatchPlayer> builder)
        {
            builder.ToTable("MatchPlayer");

            builder.HasKey(mp => new { mp.MatchId, mp.PlayerId });

            builder.HasOne(mp => mp.Match)
               .WithMany(m => m.MatchPlayers)
               .HasForeignKey(mp => mp.MatchId);

            builder.HasOne(mp => mp.Player)
                   .WithMany(p => p.MatchPlayers)
                   .HasForeignKey(mp => mp.PlayerId);

            builder.Property(mp => mp.Winner).IsRequired();
            // No es necesario definir la relación aquí
        }
    }
}
