using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ValkimiaTennisG1.Models.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string CourtType { get; set; }
        public int Winner { get; set; }
        public ICollection<Match> Matches { get; set; }

        public class TournamentConfig : IEntityTypeConfiguration<Tournament>
        {
            public void Configure(EntityTypeBuilder<Tournament> builder)
            {
                builder.ToTable("Tournament");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                builder.Property(x => x.Location).HasColumnName("Location").HasMaxLength(50).IsRequired();
                builder.Property(x => x.CourtType).HasColumnName("CourtType").HasMaxLength(20).IsRequired();
                builder.Property(x => x.Winner).HasColumnName("Winner").IsRequired();
            }
        }

    }
}
