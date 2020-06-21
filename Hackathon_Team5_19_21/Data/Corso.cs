using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_Team5_19_21.Data
{
    public class Corso
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Il Nome è obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "L\'Anno di Inizio è obbligatorio")]
        public int AnnoInizio { get; set; }
        [Required(ErrorMessage = "L\'Anno di Fine è obbligatorio")]
        public int AnnoFine { get; set; }
        public Citta Citta { get; set; }
        [Required(ErrorMessage = "Selezionare una citta")]
        public int? IdCitta { get; set; }
        public PersonaFitstic Organizzatore {get;set;}
        [Required(ErrorMessage = "Selezionare un organizzatore")]
        public int? IdOrganizzatore { get; set; }
        public List<StudenteIscritto> StudentiIscritti{get;set;}
        public List<Modulo> Moduli{get;set;}
    }
}

