using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Infrastructure.Persistence.Configurations
{
    public class SneakerConfigurations : IEntityTypeConfiguration<Sneaker>
    {
        public void Configure(EntityTypeBuilder<Sneaker> builder)
        {
            builder.ToTable("Sneakers");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => SneakerId.Create(value));

            builder.Property(s => s.Name)
                .HasMaxLength(200);

            builder.OwnsOne(s => s.Price, pb => pb.Property(p => p.Amount)
                    .HasColumnType("decimal(20,2)"));

            builder.Property(s => s.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.OwnsOne(s => s.Brand, bb => bb.Property(b => b.Name)
                .HasColumnName("Brand_Name"));
        }
    }
}
