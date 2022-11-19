using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Scientometrie_API.Models;

public partial class ScientometrieDbContext : DbContext
{
    public ScientometrieDbContext()
    {
    }

    public ScientometrieDbContext(DbContextOptions<ScientometrieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afiliere> Afiliere { get; set; }

    public virtual DbSet<AfiliereAutor> AfiliereAutor { get; set; }

    public virtual DbSet<Articol> Articol { get; set; }

    public virtual DbSet<Autor> Autor { get; set; }

    public virtual DbSet<AutorArticol> AutorArticol { get; set; }

    public virtual DbSet<Citare> Citare { get; set; }

    public virtual DbSet<Publicatie> Publicatie { get; set; }

    public virtual DbSet<TipIndexare> TipIndexare { get; set; }

    public virtual DbSet<TipPublicatie> TipPublicatie { get; set; }

    public virtual DbSet<Utilizator> Utilizator { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Afiliere>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Afiliere");

            entity.ToTable("Afiliere");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.NumeInstitutie).HasMaxLength(150);
        });

        modelBuilder.Entity<AfiliereAutor>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_AfiliereAutor");
            
            entity.ToTable("AfiliereAutor");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.IDAfiliere).HasColumnName("IDAfiliere");
            entity.Property(e => e.IDAutor).HasColumnName("IDAutor");

            entity.HasOne(d => d.IDAfiliereNavigation).WithMany(p => p.AfiliereAutor)
                .HasForeignKey(d => d.IDAfiliere)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AfiliereAutor_Afiliere");

            entity.HasOne(d => d.IDAutorNavigation).WithMany(p => p.AfiliereAutor)
                .HasForeignKey(d => d.IDAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AfiliereAutor_Autor");
        });

        modelBuilder.Entity<Articol>(entity =>
        {
            entity.ToTable("Articol");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.IDPublicatie).HasColumnName("IDPublicatie");
            entity.Property(e => e.IDUtilizator).HasColumnName("IDUtilizator");
            entity.Property(e => e.Titlu).HasMaxLength(100);
            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Doi)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("DOI");

            entity.Property(e => e.Numar)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Pagina)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Volum)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Wos)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("WOS");

            entity.HasOne(d => d.IDPublicatieNavigation).WithMany(p => p.Articol)
                .HasForeignKey(d => d.IDPublicatie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articol_Publicatie");

            entity.HasOne(d => d.IDUtilizatorNavigation).WithMany(p => p.Articol)
                .HasForeignKey(d => d.IDUtilizator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articol_Utilizator");
        });

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Autor");

            entity.ToTable("Autor");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Contact).HasMaxLength(200);
            entity.Property(e => e.Nume).HasMaxLength(50);
            entity.Property(e => e.Prenume).HasMaxLength(50);
            entity.Property(e => e.UEFID)
                .HasMaxLength(50)
                .HasColumnName("UEFID");
        });

        modelBuilder.Entity<AutorArticol>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_AutorArticol");

            entity.ToTable("AutorArticol");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.IDArticol).HasColumnName("IDArticol");
            entity.Property(e => e.IDAutor).HasColumnName("IDAutor");

            entity.HasOne(d => d.IDArticolNavigation).WithMany(p => p.AutorArticol)
                .HasForeignKey(d => d.IDArticol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AutorArticol_Articol");

            entity.HasOne(d => d.IDAutorNavigation).WithMany(p => p.AutorArticol)
                .HasForeignKey(d => d.IDAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AutorArticol_Autor");
        });

        modelBuilder.Entity<Citare>(entity =>
        {
            entity.ToTable("Citare");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Doi)
                .HasMaxLength(50)
                .HasColumnName("DOI");
            entity.Property(e => e.IDArticol).HasColumnName("IDArticol");

            entity.HasOne(d => d.IDArticolNavigation).WithMany(p => p.Citare)
                .HasForeignKey(d => d.IDArticol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citare_Articol");
        });

        modelBuilder.Entity<Publicatie>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Publicatie");

            entity.ToTable("Publicatie");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.IDTipIndexare).HasColumnName("IDTipIndexare");
            entity.Property(e => e.IDTipPublicatie).HasColumnName("IDTipPublicatie");
            entity.Property(e => e.Nume)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.IDTipIndexareNavigation).WithMany(p => p.Publicatie)
                .HasForeignKey(d => d.IDTipIndexare)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicatie_TipIndexare");

            entity.HasOne(d => d.IDTipPublicatieNavigation).WithMany(p => p.Publicatie)
                .HasForeignKey(d => d.IDTipPublicatie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicatie_TipPublicatie");
        });

        modelBuilder.Entity<TipIndexare>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_TipIndexare");

            entity.ToTable("TipIndexare");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Tip).HasMaxLength(50);
        });

        modelBuilder.Entity<TipPublicatie>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_TipPublicatie");

            entity.ToTable("TipPublicatie");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Tip).HasMaxLength(50);
        });

        modelBuilder.Entity<Utilizator>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Utilizator");

            entity.ToTable("Utilizator");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Cod)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NumeUtilizator).HasMaxLength(100);
            entity.Property(e => e.Parola).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
