using FundhouseFx.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FundhouseFx.Data.Configuration
{
    internal sealed class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("currencies");
            
            builder.HasKey(e => e.CurrencyId);
            builder.Property(e => e.CurrencyId)
                .HasColumnName("currency_id");

            builder.Property(e => e.CurrencyName)
                .HasColumnName("currency_name")
                .IsRequired();

            builder.Property(e => e.CurrencyIsoCode)
                .HasColumnName("currency_iso_code")
                .IsRequired();

            builder.Property(e => e.CurrencySymbol)
                .HasColumnName("currency_symbol")
                .IsRequired();
        }
    }
}