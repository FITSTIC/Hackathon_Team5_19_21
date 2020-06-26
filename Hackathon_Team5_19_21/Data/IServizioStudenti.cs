using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioStudenti
    {
        Task<List<Studente>> GetStudenti();
        Task<List<StudenteIscritto>> GetIscrizioniUlimoAnno();
        Task<List<Studente>> GetStudentiNonIscrittiAlCorso(int idCorso);
        Task<Studente> GetStudenteById(int id);
        Task<StudenteIscritto> GetIscrizioneById(int id);
        Task<bool> EliminaStudente(Studente s);
        Task<bool> EliminaIscrizione(int id);
        Task<bool> SalvaStudente(Studente s);
        Task<bool> SalvaIscrizione(StudenteIscritto s);
        Task SalvaCambiamenti();
        Task<List<StudentiDelCorso>> GetStudentiDelCorso(Corso c);
        Task<List<StudentiDelCorso>> GetStudentiDelCorso(int idCorso);
        string TipoDiplomaToString(Studente s);
        string StatoToString(StudentiDelCorso s);

        public class StudentiDelCorso
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataIscrizione { get; set; }
            public bool NonAmmesso { get; set; }
            public bool Ritirato { get; set; }
            public int VotoFinale { get; set; }
            public int? IdCorso { get; set; }
        }
    }
}
