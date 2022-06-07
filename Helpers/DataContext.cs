namespace Task5Back.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task5Back.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var Host = _configuration["DB_HOST"] ?? "localhost";
        var Port = _configuration["DB_PORT"] ?? "5432";
        var Database = _configuration["DB_NAME"] ?? "pg";
        var Username = _configuration["DB_USERNAME"] ?? "pg";
        var Password = _configuration["DB_PASSWORD"] ?? "12345678";

        options.UseNpgsql($"Host={Host}; Port={Port}; Database={Database}; Username={Username}; Password={Password}; Include Error Detail=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>()
            .Property(b => b.Created)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Message> Messages { get; set; }
}