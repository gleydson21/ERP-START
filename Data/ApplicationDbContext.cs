using FisioCard.Models;
using FisioCard.Models;
using Microsoft.EntityFrameworkCore;

namespace FisioCard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<HistoricoMedico> HistoricoMedico { get; set; }
        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de relacionamentos e regras de banco de dados

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Agendamentos)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<Profissional>()
                .HasMany(p => p.Agendamentos)
                .WithOne(a => a.Profissional)
                .HasForeignKey(a => a.ProfissionalId);

            modelBuilder.Entity<Profissional>()
                .HasMany(p => p.Disponibilidades)
                .WithOne(d => d.Profissional)
                .HasForeignKey(d => d.ProfissionalId);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Servico)
                .WithMany(s => s.Agendamentos)
                .HasForeignKey(a => a.ServicoId);

            // Configuração da propriedade Preco na entidade Servico
            modelBuilder.Entity<Servico>()
                .Property(s => s.Preco)
                .HasColumnType("decimal(18,2)"); // Define a precisão e escala para o decimal

            base.OnModelCreating(modelBuilder);
        }
    }
}
