using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dados.Models
{
    public partial class ContextoAgendamento : DbContext
    {
        public ContextoAgendamento()
        {
        }

        public ContextoAgendamento(DbContextOptions<ContextoAgendamento> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\git\\agendamento-consulta\\Dados\\Agendamento.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.Property(e => e.DataHoraFinalConsulta).HasColumnType("datetime");

                entity.Property(e => e.DataHoraInicialConsulta).HasColumnType("datetime");

                entity.Property(e => e.Observacoes).HasColumnType("text");

                entity.HasOne(d => d.PacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Paciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__Pacien__160F4887");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.Nascimento).HasMaxLength(12);

                entity.Property(e => e.Nome).HasColumnType("text");
            });
        }
    }
}
