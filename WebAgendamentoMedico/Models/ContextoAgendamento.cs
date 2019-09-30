using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAgendamentoMedico.Models
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
            ///Alerta gambiarra
            ///Como o banco e um .mdf a string de conexão deve ter seu caminho, tive problemas para pegar o caminho em outra solução

            if (!optionsBuilder.IsConfigured)
            {
#if DEBUG
                var caminho = Path.Combine(Environment.CurrentDirectory, "bin", "Debug", "netcoreapp2.1", "Agendamento.mdf");
#elif RELEASE
                var caminho = Path.Combine(Environment.CurrentDirectory, "bin", "Release", "netcoreapp2.1", "Agendamento.mdf");
#endif

                //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rusley.santos\\Desktop\\projeto\\AgendamentoConsulta\\Dados\\Agendamento.mdf;Integrated Security=True");
                optionsBuilder.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={caminho};Integrated Security=True");
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
