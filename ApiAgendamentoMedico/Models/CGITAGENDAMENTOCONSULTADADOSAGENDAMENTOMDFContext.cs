using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiAgendamentoMedico.Models
{
    public partial class CGITAGENDAMENTOCONSULTADADOSAGENDAMENTOMDFContext : DbContext
    {
        public CGITAGENDAMENTOCONSULTADADOSAGENDAMENTOMDFContext()
        {
        }

        public CGITAGENDAMENTOCONSULTADADOSAGENDAMENTOMDFContext(DbContextOptions<CGITAGENDAMENTOCONSULTADADOSAGENDAMENTOMDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\git\\AgendamentoConsulta\\Dados\\Agendamento.mdf;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataHoraFinalConsulta).HasColumnType("datetime");

                entity.Property(e => e.DataHoraInicialConsulta).HasColumnType("datetime");

                entity.Property(e => e.Observacoes).HasColumnType("text");

                entity.HasOne(d => d.PacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Paciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__Pacien__25869641");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nascimento).HasMaxLength(10);

                entity.Property(e => e.Nome).HasMaxLength(10);
            });
        }
    }
}
