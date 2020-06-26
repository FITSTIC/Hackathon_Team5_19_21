using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_Team5_19_21.Data
{
    public enum TipoDiploma { NessunDiploma, DiplomaMaturita, LaureaTriennale, LaureaMagistrale, DottoratoDiRicerca }
    public class Studente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il Nome è obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il Cognome è obbligatorio")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "L'Indirizzo è obbligatorio")]
        public string Indirizzo { get; set; }
        [Required(ErrorMessage = "Il Civico è obbligatorio")]
        public string Civico { get; set; }
        [Required(ErrorMessage = "Seleziona un diploma")]
        public TipoDiploma TipoDiploma { get; set; }
        [Required(ErrorMessage = "L\'Anno diploma è obbligatorio")]
        public int AnnoDiploma { get; set; }
        [Required(ErrorMessage = "L\'email è obbligatoria")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Inserire un indirizzo email valido")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Il Telefono è obbligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La Data di Nascita è obbligatoria")]
        public DateTime DataNascita { get; set; }
        public Citta Citta { get; set; }
        [Required(ErrorMessage = "Seleziona una citta")]
        public int? IdCitta { get; set; }
        public List<StudenteIscritto> StudentiIscritti { get; set; }

    }
}