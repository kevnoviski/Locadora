using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Locadora.Model;
#nullable disable

namespace Locadora.Data
{
    public partial class LocadoraContext : DbContext
    {
        public LocadoraContext()
        {
        }

        public LocadoraContext(DbContextOptions<LocadoraContext> options)
            : base(options)
        {
        }
        /*DATABASE FIRST*/
        public virtual DbSet<Filme> Filmes { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Locacao> Locacaos { get; set; }
        public virtual DbSet<LocacaoFilme> LocacaoFilmes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.ToTable("FILME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.Dtcriacao).HasColumnName("DTCRIACAO");

                entity.Property(e => e.Idgenero).HasColumnName("IDGENERO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.HasOne(d => d.IdgeneroNavigation)
                    .WithMany(p => p.Filmes)
                    .HasForeignKey(d => d.Idgenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FILME__IDGENERO__3A81B327");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("GENERO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME");
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.ToTable("LOCACAO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Dtlocacao).HasColumnName("DTLOCACAO");
            });

            modelBuilder.Entity<LocacaoFilme>(entity =>
            {
                entity.ToTable("LOCACAO_FILME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdFilme).HasColumnName("ID_FILME");

                entity.Property(e => e.IdLocacao).HasColumnName("ID_LOCACAO");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.LocacaoFilmes)
                    .HasForeignKey(d => d.IdFilme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCACAO_F__ID_FI__403A8C7D");

                entity.HasOne(d => d.IdLocacaoNavigation)
                    .WithMany(p => p.LocacaoFilmes)
                    .HasForeignKey(d => d.IdLocacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCACAO_F__ID_LO__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
