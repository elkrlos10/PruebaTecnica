using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Models;

public partial class PruebaTecnicaContext : DbContext
{
    public PruebaTecnicaContext()
    {
    }

    public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contenedor> Contenedores { get; set; }

    public virtual DbSet<Naviera> Navieras { get; set; }

    public virtual DbSet<Terminal> Terminales { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Contenedor>(entity =>
        {
            entity.ToTable("contenedores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DigitoControl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("digito_control");
            entity.Property(e => e.Fechafabricacion)
                .HasColumnType("datetime")
                .HasColumnName("fechafabricacion");
            entity.Property(e => e.Idnaviera).HasColumnName("idnaviera");
            entity.Property(e => e.Numero)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Prefijo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("prefijo");
            entity.Property(e => e.Tara)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tara");
        });

        modelBuilder.Entity<Naviera>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("navieras");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Terminal>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("terminales");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.ViajesId).HasName("PK__viajes__E9E44FB2F101AB5D");

            entity.ToTable("viajes");

            entity.Property(e => e.ViajesId).HasColumnName("viajesID");
            entity.Property(e => e.Contenedor)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaViaje)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_viaje");
            entity.Property(e => e.Idnaviera).HasColumnName("idnaviera");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
