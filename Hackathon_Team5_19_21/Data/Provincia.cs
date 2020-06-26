using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_Team5_19_21.Data
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sigla { get; set; }
        [Required]
        public List<Citta> Citta { get; set; }
    }
}