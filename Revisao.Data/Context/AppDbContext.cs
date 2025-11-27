using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Revisao.Domain.Entities;

namespace Revisao.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Crianca> Crianca {get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("RevisaoH1CartaPapaiNoel");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Crianca>(entity =>
            {
                entity.ToTable("Crianca");
                entity.HasKey(e => e.CriancaID);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Rua).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Bairro).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Cidade).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);
                entity.Property(e => e.CEP).IsRequired().HasMaxLength(9);
                entity.Property(e => e.Idade).IsRequired();
                entity.Property(e => e.TextoCarta).IsRequired().HasMaxLength(500);
            });
        }
    }
}
