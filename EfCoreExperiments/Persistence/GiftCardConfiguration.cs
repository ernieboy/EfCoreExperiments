using EfCoreExperiments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EfCoreExperiments.Persistence
{
    public class GiftCardConfiguration : IEntityTypeConfiguration<GiftCard>
    {
        public void Configure(EntityTypeBuilder<GiftCard> builder)
        {
            builder.ToTable("GiftCards");
            builder.HasKey(k => k.Id);

            builder.OwnsOne(p => p.ExpiryDate).Property(p => p.Date).HasColumnName("GiftCardExpiryDate");
        }
    }
}
