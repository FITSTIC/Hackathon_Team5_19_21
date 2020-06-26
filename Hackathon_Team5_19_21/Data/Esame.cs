using System;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_Team5_19_21.Data
{
    public class Esame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Il voto non può essere minore di 0 o maggiore di 100")]
        public int Voto { get; set; }
        public DateTime? Data { get; set; }
        public Modulo Modulo { get; set; }
        [Required]
        public int? IdModulo { get; set; }
        public StudenteIscritto StudenteIscritto { get; set; }
        [Required]
        public int? IdStudenteIscritto { get; set; }
    }
}