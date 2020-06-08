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
        [Required]
        public string Nome { get; set; }
        [Required]
        public int AnnoInizio { get; set; }
        [Required]
        public int AnnoFine { get; set; }
        [Required]
        public Citta Citta { get; set; }
        [Required]
        public int IdCitta { get; set; }
        public PersonaFitstic Organizzatore {get;set;}
        [Required]
        public int IdOrganizzatore { get; set; }
        public List<StudenteIscritto> StudentiIscritti{get;set;}
        public List<Modulo> Moduli{get;set;}
    }
}

