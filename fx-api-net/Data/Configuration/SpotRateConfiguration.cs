using System;
using FundhouseFx.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FundhouseFx.Data.Configuration
{
    internal sealed class SpotRateConfiguration : IEntityTypeConfiguration<SpotRate>
    {
        public void Configure(EntityTypeBuilder<SpotRate> builder)
        {
            builder.ToTable("spot_rates");

            builder.HasKey(e => e.SpotRateId);

            builder.Property(e => e.SpotRateId)
                .HasColumnName("spot_rate_id");

            builder.Property(e => e.BaseCurrencyId)
                .HasColumnName("base_currency_id");

            builder.Property(e => e.QuoteCurrencyId)
                .HasColumnName("quote_currency_id");

            builder.Property(e => e.Timestamp)
                .HasColumnName("timestamp");

            builder.Property(e => e.Value)
                .HasColumnName("value");

            builder.HasOne(e => e.BaseCurrency)
                .WithMany()
                .HasForeignKey(e => e.BaseCurrencyId)
                .IsRequired();
            
            builder.HasOne(e => e.QuoteCurrency)
                .WithMany()
                .HasForeignKey(e => e.QuoteCurrencyId)
                .IsRequired();
        }
    }
}