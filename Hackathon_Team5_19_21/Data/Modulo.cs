using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_Team5_19_21.Data
{
    public class Modulo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il Nome � obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "La Data di Inizio del modulo � obbligatoria")]
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        [Required(ErrorMessage = "La Materia � obbligatoria")]
        public string Materia { get; set; }
        public Corso Corso { get; set; }
        [Required(ErrorMessage = "Selezionare un corso")]
        public int? IdCorso { get; set; }
        public PersonaFitstic Tutor { get; set; }
        [Required(ErrorMessage = "Selezionare un tutor")]
        public int? IdTutor { get; set; }
        public PersonaFitstic Docente { get; set; }
        [Required(ErrorMessage = "Selezionare un docente")]
        public int? IdDocente { get; set; }
        public List<Esame> Esami { get; set; }
    }
}