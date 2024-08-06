namespace FisioCard.Models
{
    public class Notificacao
    {
        public int NotificacaoId { get; set; }
        public int ClienteId { get; set; }
        public int ProfissionalId { get; set; }
        public string Tipo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }

        // Navegação
        public Cliente Cliente { get; set; }
        public Profissional Profissional { get; set; }
    }

}
