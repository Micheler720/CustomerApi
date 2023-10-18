using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Customers.Api.Models;

namespace Customers.Api.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id)
                .HasName("id_customer");
            
            builder.Property(p => p.Age)
                .HasColumnType("int")
                .HasColumnName("age");
            
            builder.Property(p => p.Name)
                .HasColumnType("varchar(150)")
                .HasColumnName("name");
            
            // 1 : N => Client : Address
            builder.HasMany(c => c.Address)
                .WithOne()
                .HasForeignKey("customer_id");   

            builder.ToTable("customers");            
            
        }
    }
}