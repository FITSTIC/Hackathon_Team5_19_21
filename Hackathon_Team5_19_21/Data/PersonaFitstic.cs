using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_Team5_19_21.Data
{
    public class PersonaFitstic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool PrimaPassword { get; set; }
        [Required]
        public DateTime DataAssunzione { get; set; }
        [Required]
        public DateTime DataNascita { get; set; }
        [Required]
        public bool Docente { get; set; }
        [Required]
        public bool Tutor { get; set; }
        [Required]
        public bool Organizzatore { get; set; }
        [Required]
        public string Telefono { get; set; }
        public Amministratore Amministratore { get; set; }
        [Required]
        public int IdAmministratore { get; set; }
        public List<Modulo> ModuliDocente{get;set;}
        public List<Modulo> ModuliTutor { get; set; }
        public List<Corso> CorsiOrganizzatore { get; set; }
    }
}