namespace FisioCard.Models
{
    public class Relatorio
    {
        public int RelatorioId { get; set; }
        public string Tipo { get; set; }
        public DateTime DataGeracao { get; set; }
        public string Conteudo { get; set; }
    }

}
