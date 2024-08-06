namespace FisioCard.Models
{
    public class Servico
    {
        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Duracao { get; set; }
        public decimal Preco { get; set; }

        // Navegação
        public ICollection<Agendamento> Agendamentos { get; set; }
    }

}
