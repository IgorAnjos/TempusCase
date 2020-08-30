using BusinessTempus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataTempus.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(c => c.DateOfBirth)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.FamilyIncome)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.ToTable("Customers");
        }
    }
}