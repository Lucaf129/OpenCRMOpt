using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OpenCRMOptModels;

public partial class OptDbContext : DbContext
{
    public OptDbContext() //Server=.\SQL_TEST;Database=OptDB;User Id=sa;Password=My5eCr3t;TrustServerCertificate=True
    {
    }

    public OptDbContext(DbContextOptions<OptDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lotti> Lottis { get; set; }

    public virtual DbSet<Macchine> Macchines { get; set; }

    public virtual DbSet<ModelliLotti> ModelliLottis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=127.0.0.1\\SQL_TEST;Initial Catalog=OptDB;User Id=sa;Password=My5eCr3t;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lotti>(entity =>
        {
            entity.HasKey(e => e.LottoId);

            entity.ToTable("Lotti");

            entity.Property(e => e.LottoId).HasColumnName("LottoID");

            entity.HasOne(d => d.ModelloNavigation).WithMany(p => p.Lottis)
                .HasForeignKey(d => d.Modello)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lotti_Modelli");
        });

        modelBuilder.Entity<Macchine>(entity =>
        {
            entity.ToTable("Macchine");

            entity.Property(e => e.MacchineId).HasColumnName("MacchineID");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ModelliLotti>(entity =>
        {
            entity.HasKey(e => e.ModelloId);

            entity.ToTable("ModelliLotti");

            entity.Property(e => e.ModelloId).HasColumnName("ModelloID");
            entity.Property(e => e.MacchineCompatibili).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
