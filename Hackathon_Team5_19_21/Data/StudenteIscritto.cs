using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_Team5_19_21.Data
{
    public class StudenteIscritto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DataIscrizione { get; set; }
        [Required]
        public int VotoFinale { get; set; }
        [Required]
        public bool Ritirato { get; set; }
        [Required]
        public bool NonAmmesso { get; set; }
        public Studente Studente { get; set; }
        [Required]
        public int IdStudente { get; set; }
        public Corso Corso { get; set; }
        [Required]
        public int IdCorso { get; set; }
        public List<Esame> Esami { get; set; }
    }
}