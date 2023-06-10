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
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=root;Database=tramigodb;", serverVersion);
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.CreatedAt).ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        builder.Entity<User>().Property(c => c.Username).IsRequired().HasMaxLength(60);
        //
        //
        builder.Entity<Procedure>().ToTable("Procedures");
        builder.Entity<Procedure>().HasKey(p => p.Id);
        builder.Entity<Procedure>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Procedure>().Property(p => p.CreatedAt).ValueGeneratedOnAdd();
        builder.Entity<Procedure>().Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate();
//       
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Receipt>().ToTable("Receipts");
        builder.Entity<Receipt>().HasKey(p => p.Id);
        builder.Entity<Receipt>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Receipt>().Property(p => p.CreatedAt).ValueGeneratedOnAdd();
        builder.Entity<Receipt>().Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate();
//       builder.Entity<Payment>().ToTable("Payments");
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.CreatedAt).ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate();

    }
}