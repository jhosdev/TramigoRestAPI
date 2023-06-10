using Microsoft.EntityFrameworkCore;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure.Context;

public class TramigoApplicationContext : DbContext
{
    public TramigoApplicationContext()
    {
        
    }
    
    public TramigoApplicationContext(DbContextOptions<TramigoApplicationContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Procedure> Procedures { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {   //5.5.62-0ubuntu0.14.04.1
            var serverVersion = new MySqlServerVersion(new Version(5, 5, 62));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10624175;Pwd=J99zqiekPc;Database=sql10624175;", serverVersion);
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.CreatedAt).HasColumnType("TIMESTAMP").ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.UpdatedAt).HasColumnType("TIMESTAMP");
        builder.Entity<User>().Property(c => c.Username).IsRequired().HasMaxLength(60);
        //
        //
        builder.Entity<Procedure>().ToTable("Procedures");
        builder.Entity<Procedure>().HasKey(p => p.Id);
        builder.Entity<Procedure>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Procedure>().Property(p => p.CreatedAt).HasColumnType("TIMESTAMP").ValueGeneratedOnAdd();
        builder.Entity<Procedure>().Property(p => p.UpdatedAt).HasColumnType("TIMESTAMP");
//       
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Receipt>().ToTable("Receipts");
        builder.Entity<Receipt>().HasKey(p => p.Id);
        builder.Entity<Receipt>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Receipt>().Property(p => p.CreatedAt).HasColumnType("TIMESTAMP").ValueGeneratedOnAdd();
        builder.Entity<Receipt>().Property(p => p.UpdatedAt).HasColumnType("TIMESTAMP");
//       builder.Entity<Payment>().ToTable("Payments");
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.CreatedAt).HasColumnType("TIMESTAMP").ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.UpdatedAt).HasColumnType("TIMESTAMP");

    }
}