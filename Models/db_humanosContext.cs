using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_Dotnet.Models
{
    public partial class db_humanosContext : DbContext
    {
        public db_humanosContext()
        {
        }

        public db_humanosContext(DbContextOptions<db_humanosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Humano> Humanos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Humano>(entity =>
            {
                entity.ToTable("humano");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Sexo).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
