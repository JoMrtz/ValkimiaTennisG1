using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValkimiaTennisG1.Enums;

namespace ValkimiaTennisG1.Models.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ability { get; set; }
        public int? Strength { get; set; }
        public int? Speed { get; set; }
        public int? ReactionTime { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public class PlayerConfig : IEntityTypeConfiguration<Player>
        { 
            public void Configure(EntityTypeBuilder<Player> builder)
            {
                builder.ToTable("Player");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                builder.Property(x => x.Ability).HasColumnName("Ability").HasMaxLength(2).IsRequired();
                builder.Property(x => x.Strength).HasColumnName("Strength").HasMaxLength(2);
                builder.Property(x => x.Speed).HasColumnName("Speed").HasMaxLength(2);
                builder.Property(x => x.ReactionTime).HasColumnName("ReactionTime").HasMaxLength(2);

                builder.HasOne(p => p.Gender).WithMany(g => g.Players).HasForeignKey(p =>p.GenderId);
            }
        }
    }
}
