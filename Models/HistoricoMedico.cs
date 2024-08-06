using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FisioCard.Models
{
    public class HistoricoMedico
    {
        [Key]
        public int HistoricoMedicoId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(1000)] // Ajuste o comprimento conforme necessário
        public string Descricao { get; set; }

        // Navegação
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
    }
}


