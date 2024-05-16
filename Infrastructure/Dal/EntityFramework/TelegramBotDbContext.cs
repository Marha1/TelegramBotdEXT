using Domain.Entities;
using Infrastructure.Dal.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.EntityFramework;

/// <summary>
/// Класс контекста
/// </summary>
public class TelegramBotDbContext : DbContext
{
    public DbSet<Person> Persons { get; init; }
    public DbSet<CustomField<string>> CustomFields { get; init; }

    public TelegramBotDbContext(DbContextOptions<TelegramBotDbContext> options, IConfiguration configuration)
        : base(options)
    {
    }
    
    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new CustomFieldConfiguration());
    }
}
