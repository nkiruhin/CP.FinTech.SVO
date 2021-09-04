using CP.FinTech.SVO.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace CP.FinTech.SVO.Infrastructure.Data.Config
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            var converter = new ValueConverter<string[], string>(
    x => string.Join(";", x),
    x => x.Split(';', System.StringSplitOptions.RemoveEmptyEntries));


            builder.Property(e => e.WalletAddress)
                    .HasConversion(converter);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
