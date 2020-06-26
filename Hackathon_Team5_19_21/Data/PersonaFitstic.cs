using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_Team5_19_21.Data
{
    public class PersonaFitstic
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il Nome � obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il Cognome � obbligatorio")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "L\'Email � obbligatoria")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "La Password � obbligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Il campo Prima Password � obbligatorio")]
        public bool PrimaPassword { get; set; }
        [Required(ErrorMessage = "La Data di Assunzione � obbligatoria")]
        public DateTime DataAssunzione { get; set; }
        [Required(ErrorMessage = "La Data di Nascita � obbligatoria")]
        public DateTime DataNascita { get; set; }
        [Required]
        public bool Docente { get; set; }
        [Required]
        public bool Tutor { get; set; }
        [Required]
        public bool Organizzatore { get; set; }
        [Required(ErrorMessage = "Il Telefono � obbligatorio")]
        [MaxLength(10, ErrorMessage = "Il campo Telefono non pu� contenere pi� di 10 caratteri")]
        public string Telefono { get; set; }
        public Amministratore Amministratore { get; set; }
        [Required]
        public int? IdAmministratore { get; set; }
        public List<Modulo> ModuliDocente { get; set; }
        public List<Modulo> ModuliTutor { get; set; }
        public List<Corso> CorsiOrganizzatore { get; set; }
    }
}