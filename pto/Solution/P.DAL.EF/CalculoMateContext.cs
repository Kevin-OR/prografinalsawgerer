using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P.DAL.DO.Objects;

namespace P.DAL.EF
{
    public partial class CalculoMateContext : DbContext
    {
        public CalculoMateContext()
        {
        }

        public CalculoMateContext(DbContextOptions<CalculoMateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CalculoMateri> CalculoMateri { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ListCal> ListCal { get; set; }
        public virtual DbSet<Materiales> Materiales { get; set; }
        public virtual DbSet<MediPared> MediPared { get; set; }
        public virtual DbSet<MediParedes> MediParedes { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculoMateri>(entity =>
            {
                entity.HasKey(e => e.IdCalMateri)
                    .HasName("PK__CalculoM__52C73114E837CD5B");

                entity.Property(e => e.IdCalMateri).HasColumnName("idCalMateri");

                entity.Property(e => e.IdCalculo).HasColumnName("idCalculo");

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");

                entity.Property(e => e.IdMedParedes).HasColumnName("idMedParedes");

                entity.Property(e => e.TotalCalculo)
                    .HasColumnName("totalCalculo")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdCalculoNavigation)
                    .WithMany(p => p.CalculoMateri)
                    .HasForeignKey(d => d.IdCalculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idCalculo");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.CalculoMateri)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idMaterial");

                entity.HasOne(d => d.IdMedParedesNavigation)
                    .WithMany(p => p.CalculoMateri)
                    .HasForeignKey(d => d.IdMedParedes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idMedParedess");
            });

            modelBuilder.Entity<Canton>(entity =>
            {
                entity.HasKey(e => e.CodigoCanton)
                    .HasName("PK__Canton__45E861BDE09F433A");

                entity.Property(e => e.CodigoCanton).HasColumnName("codigo_canton");

                entity.Property(e => e.CodigoProvincia).HasColumnName("codigo_provincia");

                entity.Property(e => e.NombreCanton)
                    .IsRequired()
                    .HasColumnName("nombre_canton")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoProvinciaNavigation)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.CodigoProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANTON_PROVINCIA");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdClie)
                    .HasName("PK__Cliente__3766D498C4660E29");

                entity.Property(e => e.IdClie).ValueGeneratedNever();

                entity.Property(e => e.CodigoCanton).HasColumnName("codigo_canton");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PriApellido)
                    .IsRequired()
                    .HasColumnName("priApellido")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SeguApellido)
                    .IsRequired()
                    .HasColumnName("seguApellido")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoCantonNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.CodigoCanton)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Canton");
            });

            modelBuilder.Entity<ListCal>(entity =>
            {
                entity.HasKey(e => e.IdCalculo)
                    .HasName("PK__ListCal__77CAC708D6D6F2F3");

                entity.Property(e => e.IdCalculo).HasColumnName("idCalculo");

                entity.Property(e => e.NombreCalculo)
                    .IsRequired()
                    .HasColumnName("nombre_Calculo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClieNavigation)
                    .WithMany(p => p.ListCal)
                    .HasForeignKey(d => d.IdClie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdClie");

                entity.HasOne(d => d.IdPerNavigation)
                    .WithMany(p => p.ListCal)
                    .HasForeignKey(d => d.IdPer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Idper");
            });

            modelBuilder.Entity<Materiales>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK__Material__6AC7E3EB397681C0");

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");

                entity.Property(e => e.CantiMetro).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NombreMaterial)
                    .IsRequired()
                    .HasColumnName("nombre_Material")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MediPared>(entity =>
            {
                entity.HasKey(e => e.IdMedPared)
                    .HasName("PK__MediPare__22C19CF9DA7B5F0E");

                entity.Property(e => e.IdMedPared).HasColumnName("idMedPared");

                entity.Property(e => e.Alto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Ancho).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdMedParedes).HasColumnName("idMedParedes");

                entity.Property(e => e.MetroCuadrado).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdMedParedesNavigation)
                    .WithMany(p => p.MediPared)
                    .HasForeignKey(d => d.IdMedParedes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idMedParedes");
            });

            modelBuilder.Entity<MediParedes>(entity =>
            {
                entity.HasKey(e => e.IdMedParedes)
                    .HasName("PK__MediPare__08EAE0332CE36E1D");

                entity.Property(e => e.IdMedParedes).HasColumnName("idMedParedes");

                entity.Property(e => e.TotalAlto)
                    .HasColumnName("totalAlto")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalAncho)
                    .HasColumnName("totalAncho")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalMetroCuadrado)
                    .HasColumnName("totalMetroCuadrado")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPer)
                    .HasName("PK__Persona__2ACE59B535BB48CD");

                entity.Property(e => e.IdPer).ValueGeneratedNever();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PriApellido)
                    .IsRequired()
                    .HasColumnName("priApellido")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SeguApellido)
                    .IsRequired()
                    .HasColumnName("seguApellido")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.CodigoProvincia)
                    .HasName("PK__Provinci__265D811C08038C19");

                entity.Property(e => e.CodigoProvincia).HasColumnName("codigo_provincia");

                entity.Property(e => e.NombreProvincia)
                    .IsRequired()
                    .HasColumnName("nombre_provincia")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
