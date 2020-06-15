using Hackathon_Team5_19_21.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public class ServizioStudenti : IServizioStudenti
    {
        ApplicationDbContext _db;
        public ServizioStudenti(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task EliminaIscrizione(int id)
        {
            StudenteIscritto s = await _db.StudentiIscritti.FindAsync(id);
            _db.StudentiIscritti.Remove(s);
            await SalvaCambiamenti();
        }

        public async Task EliminaStudente(Studente s)
        {
            _db.Studenti.Remove(s);
            await SalvaCambiamenti();
        }

        public async Task<StudenteIscritto> GetIscrizioneById(int id)
        {
            return await _db.StudentiIscritti.FindAsync(id);
        }

        public async Task<Studente> GetStudenteById(int id)
        {
            return await _db.Studenti.FindAsync(id);
        }

        public async Task<List<Studente>> GetStudenti()
        {
            return await _db.Studenti.ToListAsync();
        }

        public async Task<List<dynamic>> GetStudentiDelCorso(Corso c)
        {
            List<dynamic> Studenti = new List<dynamic>();
            var studenti= await(from studente in _db.Studenti
                         join studenteIscritto in _db.StudentiIscritti on studente.Id equals studenteIscritto.IdStudente
                         where studenteIscritto.IdCorso == c.Id
                         select new { Id = studenteIscritto.Id, Nome = studente.Nome, Cognome = studente.Cognome, DataIscrizione = studenteIscritto.DataIscrizione, NonAmmesso = studenteIscritto.NonAmmesso, Ritirato = studenteIscritto.Ritirato, VotoFinale=studenteIscritto.VotoFinale }).ToListAsync();
            foreach (var s in studenti) Studenti.Add(s);
            return Studenti;
        }

        public async Task<List<dynamic>> GetStudentiDelCorso(int idCorso)
        {
            List<dynamic> Studenti = new List<dynamic>();
            var studenti = await(from studente in _db.Studenti
                                 join studenteIscritto in _db.StudentiIscritti on studente.Id equals studenteIscritto.IdStudente
                                 where studenteIscritto.IdCorso == idCorso
                                 select new { Id = studenteIscritto.Id, Nome = studente.Nome, Cognome = studente.Cognome, DataIscrizione = studenteIscritto.DataIscrizione, NonAmmesso = studenteIscritto.NonAmmesso, Ritirato = studenteIscritto.Ritirato, VotoFinale = studenteIscritto.VotoFinale }).ToListAsync();
            foreach (var s in studenti) Studenti.Add(s);
            return Studenti;
        }

        public async Task<List<Studente>> GetStudentiNonIscrittiAlCorso(int idCorso)
        {
            List<Studente> studentiIscritti = await (from studente in _db.Studenti
                                               join studenteIscritto in _db.StudentiIscritti on studente.Id equals studenteIscritto.IdStudente
                                               where studenteIscritto.IdCorso == idCorso
                                                     select studente).ToListAsync();
            return await _db.Studenti.Where(x => !studentiIscritti.Contains(x)).ToListAsync();
        }

        public async Task SalvaCambiamenti()
        {
            await _db.SaveChangesAsync();
        }

        public async Task SalvaIscrizione(StudenteIscritto s)
        {
            await _db.StudentiIscritti.AddAsync(s);
        }

        public async Task SalvaStudente(Studente s)
        {
            await _db.Studenti.AddAsync(s);
            await SalvaCambiamenti();
        }
    }
}
