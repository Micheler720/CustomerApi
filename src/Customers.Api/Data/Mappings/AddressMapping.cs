using Customers.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Api.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(pa => pa.Id)
                .HasName("id_address");

            builder.Property(pa => pa.City)
                .HasColumnType("varchar(150)")
                .HasColumnName("city");

            builder.Property(pa => pa.Country)
                .HasColumnType("varchar(50)")
                .HasColumnName("country");

            builder.Property(pa => pa.Street)
                .HasColumnType("varchar(80)")
                .HasColumnName("street");

            builder.Property(pa => pa.State)
                .HasColumnType("varchar(2)")
                .HasColumnName("state");

            builder.Property(pa => pa.PostalCode)
                .HasColumnType("varchar(9)")
                .HasColumnName("postal_code");

            
            builder.ToTable("addresses"); 

        }
    }
}