using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Euro2024NewsManagement.DAL.Entities;

public partial class Euro2024NewsManagementDbContext : DbContext
{
    public Euro2024NewsManagementDbContext()
    {
    }

    public Euro2024NewsManagementDbContext(DbContextOptions<Euro2024NewsManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FootballNews> FootballNews { get; set; }

    public virtual DbSet<NewsType> NewsTypes { get; set; }

    public virtual DbSet<OrganizationAccount> OrganizationAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6N0TNJM;uid=sa;pwd=12345;database=Euro2024NewsManagementDB;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FootballNews>(entity =>
        {
            entity.HasKey(e => e.FootballNewsId).HasName("PK__Football__C9236D6FE0C6232B");

            entity.Property(e => e.FootballNewsId)
                .HasMaxLength(30)
                .HasColumnName("FootballNewsID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ManagerialChanges).HasMaxLength(300);
            entity.Property(e => e.MatchReports).HasMaxLength(400);
            entity.Property(e => e.NewsTitle).HasMaxLength(100);
            entity.Property(e => e.NewsTypeId)
                .HasMaxLength(30)
                .HasColumnName("NewsTypeID");
            entity.Property(e => e.ShortDescription).HasMaxLength(400);
            entity.Property(e => e.TacticalAnalysis).HasMaxLength(400);

            entity.HasOne(d => d.NewsType).WithMany(p => p.FootballNews)
                .HasForeignKey(d => d.NewsTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FootballN__NewsT__3C69FB99");
        });

        modelBuilder.Entity<NewsType>(entity =>
        {
            entity.HasKey(e => e.NewsTypeId).HasName("PK__NewsType__9013FE2AFFB88CF8");

            entity.ToTable("NewsType");

            entity.Property(e => e.NewsTypeId)
                .HasMaxLength(30)
                .HasColumnName("NewsTypeID");
            entity.Property(e => e.TypeDescription).HasMaxLength(400);
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<OrganizationAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Organiza__349DA58668EB7200");

            entity.ToTable("OrganizationAccount");

            entity.HasIndex(e => e.OrganizationEmail, "UQ__Organiza__575358C6C0089A40").IsUnique();

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.AccountPassword).HasMaxLength(50);
            entity.Property(e => e.OrganizationEmail).HasMaxLength(70);
            entity.Property(e => e.ShortDescription).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
