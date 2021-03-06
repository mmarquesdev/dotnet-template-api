using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExemploApi.Domain.Entities;

namespace ExemploApi.Infra.Mappings
{
    public class ExampleMappings : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.ToTable("examples");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("uuid").HasColumnName("id").IsRequired();

            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasColumnName("created_at").IsRequired();
            builder.Property(x => x.DeletedAt).HasColumnType("timestamp with time zone").HasColumnName("deleted_at");
        }
    }
}
