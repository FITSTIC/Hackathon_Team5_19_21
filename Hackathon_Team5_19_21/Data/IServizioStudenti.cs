using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioStudenti
    {
        Task<List<Studente>> GetStudenti();
        Task<List<Studente>> GetStudentiNonIscrittiAlCorso(int idCorso);
        Task<Studente> GetStudenteById(int id);
        Task<StudenteIscritto> GetIscrizioneById(int id);
        Task EliminaStudente(Studente s);
        Task EliminaIscrizione(int id);
        Task SalvaStudente(Studente s);
        Task SalvaIscrizione(StudenteIscritto s);
        Task SalvaCambiamenti();
        Task<List<dynamic>> GetStudentiDelCorso(Corso c);
        Task<List<dynamic>> GetStudentiDelCorso(int idCorso);
    }
}
