using Microsoft.EntityFrameworkCore;
using vemdezap.Domain.Entities;

namespace vemdezap.Infra;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=vemdezap;Username=postgres;Password=senha");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
        modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(150).IsRequired();
        modelBuilder.Entity<Usuario>().Property(x => x.Sobrenome).HasMaxLength(150).IsRequired();
        modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(150).IsRequired();
        modelBuilder.Entity<Usuario>().Property(x => x.Ativo).IsRequired();
        modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(8).IsRequired();
        modelBuilder.Entity<Usuario>().Property(x => x.DataCadastro).IsRequired();
    }

    public DbSet<Usuario> Usuarios { get; set; }
}
