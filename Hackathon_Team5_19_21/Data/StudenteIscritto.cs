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
        [Required(ErrorMessage ="La Data di Iscrizione è obbligatoria")]
        public DateTime DataIscrizione { get; set; }
        [Required]
        [Range(0,100,ErrorMessage ="Il Voto Finale deve essere compreso tra 0 e 100")]
        public int VotoFinale { get; set; }
        [Required(ErrorMessage ="Il campo Ritirato è obbligatorio")]
        public bool Ritirato { get; set; }
        [Required(ErrorMessage = "Il campo Non Ammesso è obbligatorio")]
        public bool NonAmmesso { get; set; }
        public Studente Studente { get; set; }
        [Required(ErrorMessage = "Il campo Studente è obbligatorio")]
        public int? IdStudente { get; set; }
        public Corso Corso { get; set; }
        [Required(ErrorMessage ="Il campo Corso è obbligatorio")]
        public int? IdCorso { get; set; }
        public List<Esame> Esami { get; set; }
    }
}