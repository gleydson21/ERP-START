namespace FisioCard.Models
{
    public class Disponibilidade
    {
        public int DisponibilidadeId { get; set; }
        public int ProfissionalId { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }

        // Navegação
        public Profissional Profissional { get; set; }
    }

}
