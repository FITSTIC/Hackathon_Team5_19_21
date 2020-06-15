using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_Team5_19_21.Data
{
    public enum TipoDiploma { NessunDiploma, DiplomaMaturita, LaureaTriennale, LaureaMagistrale, DottoratoDiRicerca }
    public class Studente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string Indirizzo { get; set; }
        [Required]
        public string Civico { get; set; }
        [Required]
        [Range(1,4,ErrorMessage ="Seleziona un diploma")]
        public TipoDiploma TipoDiploma { get; set; }
        [Required]
        public int AnnoDiploma { get; set; }
        [Required(ErrorMessage ="Il campo email è obbligatorio")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Inserire un indirizzo email valido")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public DateTime DataNascita { get; set; }
        public Citta Citta{get;set;}
        [Required]
        public int IdCitta { get; set; }
        public List<StudenteIscritto> StudentiIscritti{get;set;}

    }
}