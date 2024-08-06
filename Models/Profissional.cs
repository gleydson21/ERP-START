namespace FisioCard.Models
{
    public class Profissional
    {
        public int ProfissionalId { get; set; }
        public string Nome { get; set; }
        public string NumeroRegistro { get; set; }
        public string Especialidades { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Navegação
        public ICollection<Agendamento> Agendamentos { get; set; }
        public ICollection<Disponibilidade> Disponibilidades { get; set; }
    }

}
