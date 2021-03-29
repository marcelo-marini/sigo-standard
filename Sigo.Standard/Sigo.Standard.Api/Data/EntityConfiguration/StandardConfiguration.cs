using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sigo.Standard.Api.Data.EntityConfiguration
{
    class StandardConfiguration : IEntityTypeConfiguration<Domain.Standard>
    {
        public void Configure(EntityTypeBuilder<Domain.Standard> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(400).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.UpdatedAt).IsRequired();
            builder.Property(c => c.Url).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Type).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Owner).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Code).HasMaxLength(20).IsRequired();
        }
    }
}