using FisioCard.Models;

namespace FisioCard.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Navegação
        public ICollection<Agendamento> Agendamentos { get; set; }
        public ICollection<HistoricoMedico> HistoricoMedico { get; set; }
    }

}
