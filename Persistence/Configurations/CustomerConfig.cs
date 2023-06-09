using Domain.Entitties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        builder.Property(_ => _.FirstName).HasMaxLength(80).IsRequired();
        builder.Property(_ => _.LastName).HasMaxLength(80).IsRequired();
        builder.Property(_ => _.PhoneNumber).HasMaxLength(10).IsRequired();
        builder.Property(_ => _.Address).HasMaxLength(150).IsRequired();
        builder.Property(_ => _.Age);
        builder.Property(_ => _.CreatedBy).HasMaxLength(30);
        builder.Property(_ => _.LastModifiedBy).HasMaxLength(30);
        builder.Property(_ => _.DOB).IsRequired();
    }
}

