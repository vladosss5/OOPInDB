using DatabaseInheritance.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DatabaseInheritance.Data;

public class DBContext  : DbContext
{
    public DBContext()
    {
        
    }
    
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = new NpgsqlConnectionStringBuilder
            {
                Host = "localhost",
                Database = "DatabaseInheritance1",
                Username = "postgres",
                Password = "mysecretpassword",
                Port = 9595
            }.ToString();

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the inheritance hierarchy
        modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("PersonType")
            .HasValue<Person>("Person")
            .HasValue<Client>("Client")
            .HasValue<Employee>("Employee");

        // Configure the base Person entity
        modelBuilder.Entity<Person>()
            .Property(p => p.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Person>()
            .Property(p => p.FName)
            .HasColumnName("f_name")
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.SName)
            .HasColumnName("s_name")
            .HasMaxLength(50);

        modelBuilder.Entity<Person>()
            .Property(p => p.LName)
            .HasColumnName("l_name")
            .HasMaxLength(50)
            .IsRequired();

        // Configure Client-specific properties
        modelBuilder.Entity<Client>()
            .Property(c => c.CountVisits)
            .HasColumnName("count_visits")
            .HasDefaultValue(0);

        // Configure Employee-specific properties
        modelBuilder.Entity<Employee>()
            .Property(e => e.Login)
            .HasColumnName("login")
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Password)
            .HasColumnName("password")
            .HasMaxLength(100)
            .IsRequired();
    }
}