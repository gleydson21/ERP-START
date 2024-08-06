namespace FisioCard.Models
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public int ClienteId { get; set; }
        public int ProfissionalId { get; set; }
        public int ServicoId { get; set; }
        public DateTime DataHora { get; set; }
        public string TipoServico { get; set; }
        public string Observacoes { get; set; }
        public string Status { get; set; }

        // Navegação
        public Cliente Cliente { get; set; }
        public Profissional Profissional { get; set; }
        public Servico Servico { get; set; }
    }

}
