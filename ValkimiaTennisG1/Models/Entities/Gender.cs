using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ValkimiaTennisG1.Enums;

namespace ValkimiaTennisG1.Models.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public GenderType GenderType { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public class GenderConfig : IEntityTypeConfiguration<Gender>
        {
            public void Configure(EntityTypeBuilder<Gender> builder)
            {
                builder.ToTable("Gender");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.GenderType).HasColumnName("GenderType").IsRequired();
                    
            }
        }
    }
}
