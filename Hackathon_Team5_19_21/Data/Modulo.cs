using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_Team5_19_21.Data
{
    public class Modulo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        [Required]
        public string Materia{get;set;}
        [Required]
        public Corso Corso{get;set;}
        [Required]
        public int IdCorso { get; set; }
        public PersonaFitstic Tutor {get;set;}
        public int IdTutor { get; set; }
        public PersonaFitstic Docente { get; set; }
        public int IdDocente { get; set; }
        [Required]
        public List<Esame> Esami{get;set;}
    }
}