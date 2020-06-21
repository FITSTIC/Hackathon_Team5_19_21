using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public enum Color { Danger, Warning, Success, Primary, Secondary, Info, Light, Dark }
namespace Hackathon_Team5_19_21.Data
{
    public class Citta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public Provincia Provincia{get;set;}
        [Required]
        public int? IdProvincia { get; set; }
        [Required]
        public List<Corso> Corsi{get;set;}
        [Required]
        public List<Studente> Studenti{get;set;}
    }
}