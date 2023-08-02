using Microsoft.EntityFrameworkCore;

namespace Task1.Models;

public partial class Task1DataBaseContext : DbContext
{
    public Task1DataBaseContext()
    {
    }

    public Task1DataBaseContext(DbContextOptions<Task1DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Line> Lines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlServer("Server=DESKTOP-6H04H4Q;Database=Task1DataBase;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<File>(entity =>
        {
            _ = entity.Property(e => e.FileName).HasMaxLength(50);
        });

        _ = modelBuilder.Entity<Line>(entity =>
        {
            _ = entity.Property(e => e.Id).HasColumnName("id");
            _ = entity.Property(e => e.Date).HasColumnType("date");
            _ = entity.Property(e => e.EngLetters)
                .HasMaxLength(10)
                .IsFixedLength();
            _ = entity.Property(e => e.RuLetters).HasMaxLength(10);

            _ = entity.HasOne(d => d.File).WithMany(p => p.Lines)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lines_Files");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
