using Domain.Entities;
using Domain.Primitives.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

/// <summary>
/// Класс конфигурации для Person
/// </summary>
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id");
        
        builder.OwnsOne(p => p.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .IsRequired()
                .HasColumnName("first_name");

            fullName.Property(f => f.LastName)
                .IsRequired()
                .HasColumnName("last_name");

            fullName.Property(f => f.MiddleName)
                .HasColumnName("middle_name");
        });

        builder.Property(p => p.Gender)
            .IsRequired()
            .HasDefaultValue(Gender.None)
            .HasColumnName("gender");

        builder.Property(p => p.BirthDate)
            .IsRequired()
            .HasColumnName("birth_date")
            .HasColumnType("timestamp");

        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasColumnName("phone_number");

        builder.Property(p => p.Telegram)
            .IsRequired()
            .HasColumnName("telegram");

        builder.HasMany(p => p.CustomFields)
            .WithMany();
    }
}