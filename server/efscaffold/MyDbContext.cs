using efscaffold.Entities;
using Microsoft.EntityFrameworkCore;

namespace efscaffold;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("todo_pkey");

            entity.ToTable("todo", "todosystem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isdone).HasColumnName("isdone");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
