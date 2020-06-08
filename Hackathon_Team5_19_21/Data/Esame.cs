using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_Team5_19_21.Data
{
    public class Esame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0,100,ErrorMessage ="Il voto non può essere minore di 0 o maggiore di 100")]
        public int? Voto { get; set; }
        [Required]
        public Modulo Modulo{get;set;}
        [Required]
        public int IdModulo { get; set; }
        public StudenteIscritto StudenteIscritto { get; set; }
        [Required]
        public int IdStudenteIscritto { get; set; }
    }
}