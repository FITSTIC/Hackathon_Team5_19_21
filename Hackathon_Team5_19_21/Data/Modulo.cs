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
        [Required(ErrorMessage ="Il Nome è obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "La Data di Inizio del modulo è obbligatoria")]
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        [Required(ErrorMessage = "La Materia è obbligatoria")]
        public string Materia{get;set;}
        public Corso Corso{get;set;}
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Selezionare un corso")]
        public int IdCorso { get; set; }
        public PersonaFitstic Tutor {get;set;}
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Selezionare un tutor")]
        public int IdTutor { get; set; }
        public PersonaFitstic Docente { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Selezionare un docente")]
        public int IdDocente { get; set; }
        public List<Esame> Esami{get;set;}
    }
}