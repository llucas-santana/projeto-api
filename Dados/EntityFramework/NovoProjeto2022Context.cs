using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dados.EntityFramework
{
    public partial class NovoProjeto2022Context : DbContext
    {
        public NovoProjeto2022Context()
        {
        }

        public NovoProjeto2022Context(DbContextOptions<NovoProjeto2022Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Filme> Filmes { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Ingresso> Ingressos { get; set; } = null!;
        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<Sala> Salas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Venda> Vendas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-6ATLCAO9;Initial Catalog=NovoProjeto2022;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Login).HasMaxLength(21);

                entity.Property(e => e.Senha).HasMaxLength(21);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Pessoa");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.Nome).HasMaxLength(80);
            });

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.ToTable("Filme");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao).HasMaxLength(400);

                entity.Property(e => e.Imagem).HasMaxLength(500);

                entity.Property(e => e.Nome).HasMaxLength(80);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Filmes)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Filme_Empresa");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionario");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Pessoa");
            });

            modelBuilder.Entity<Ingresso>(entity =>
            {
                entity.ToTable("Ingresso");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataInicio).HasColumnType("datetime");

                entity.Property(e => e.Valor).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.Ingressos)
                    .HasForeignKey(d => d.IdFilme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingresso_Filme");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Ingressos)
                    .HasForeignKey(d => d.IdSala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingresso_Sala");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa");

                entity.Property(e => e.Cpf).HasMaxLength(11);

                entity.Property(e => e.Nome).HasMaxLength(80);
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Sala");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nome).HasMaxLength(60);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Login).HasMaxLength(25);

                entity.Property(e => e.Papel)
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.Senha).HasMaxLength(25);

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Funcionario");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.Property(e => e.DataVenda).HasColumnType("datetime");

                entity.Property(e => e.ValorPago).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venda_Cliente");

                entity.HasOne(d => d.IdIngressoNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdIngresso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venda_Ingresso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
