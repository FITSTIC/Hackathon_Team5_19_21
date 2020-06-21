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

        public async Task<bool> EliminaIscrizione(int id)
        {
            bool result = false;
            Esame e = await _db.Esami.FirstOrDefaultAsync(x => x.IdStudenteIscritto == id);
            if (e == null)
            {
                StudenteIscritto s = await _db.StudentiIscritti.FindAsync(id);
                _db.StudentiIscritti.Remove(s);
                await _db.SaveChangesAsync();
                result = true;
            }
            return result;

        }

        public async Task<bool> EliminaStudente(Studente s)
        {
            bool result = false;
            StudenteIscritto iscrizione = await _db.StudentiIscritti.FirstOrDefaultAsync(x => x.IdStudente == s.Id);
            if (iscrizione == null)
            {
                _db.Studenti.Remove(s);
                await _db.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<StudenteIscritto> GetIscrizioneById(int id)
        {
            return await _db.StudentiIscritti.FindAsync(id);
        }

        public async Task<List<StudenteIscritto>> GetIscrizioniUlimoAnno()
        {
            return await _db.StudentiIscritti.Where(x => x.DataIscrizione >= DateTime.Now.AddYears(-1)).ToListAsync();
        }

        public async Task<Studente> GetStudenteById(int id)
        {
            return await _db.Studenti.FindAsync(id);
        }

        public async Task<List<Studente>> GetStudenti()
        {
            return await _db.Studenti.ToListAsync();
        }

        public async Task<List<IServizioStudenti.StudentiDelCorso>> GetStudentiDelCorso(Corso c)
        {
            List<IServizioStudenti.StudentiDelCorso> Studenti = new List<IServizioStudenti.StudentiDelCorso>();
            var studenti = await (from studente in _db.Studenti
                                  join studenteIscritto in _db.StudentiIscritti on studente.Id equals studenteIscritto.IdStudente
                                  where studenteIscritto.IdCorso == c.Id
                                  select new IServizioStudenti.StudentiDelCorso { Id = studenteIscritto.Id, Nome = studente.Nome, Cognome = studente.Cognome, DataIscrizione = studenteIscritto.DataIscrizione, NonAmmesso = studenteIscritto.NonAmmesso, Ritirato = studenteIscritto.Ritirato, VotoFinale = studenteIscritto.VotoFinale, IdCorso = studenteIscritto.IdCorso }).ToListAsync();
            foreach (var s in studenti) Studenti.Add(s);
            return Studenti;
        }

        public async Task<List<IServizioStudenti.StudentiDelCorso>> GetStudentiDelCorso(int idCorso)
        {
            List<IServizioStudenti.StudentiDelCorso> Studenti = new List<IServizioStudenti.StudentiDelCorso>();
            var studenti = await (from studente in _db.Studenti
                                  join studenteIscritto in _db.StudentiIscritti on studente.Id equals studenteIscritto.IdStudente
                                  where studenteIscritto.IdCorso == idCorso
                                  select new IServizioStudenti.StudentiDelCorso { Id = studenteIscritto.Id, Nome = studente.Nome, Cognome = studente.Cognome, DataIscrizione = studenteIscritto.DataIscrizione, NonAmmesso = studenteIscritto.NonAmmesso, Ritirato = studenteIscritto.Ritirato, VotoFinale = studenteIscritto.VotoFinale, IdCorso = studenteIscritto.IdCorso }).ToListAsync();
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

        public async Task<bool> SalvaIscrizione(StudenteIscritto s)
        {
            bool result = false;
            Corso c = await _db.Corsi.FindAsync(s.IdCorso);
            Studente st = await _db.Studenti.FindAsync(s.IdStudente);
            if (c != null && st != null)
            {
                _db.StudentiIscritti.Add(s);
                await _db.SaveChangesAsync();
                result = true;
            }
            return result;

        }

        public async Task<bool> SalvaStudente(Studente s)
        {
            bool result = false;
            Citta citta = await _db.Citta.FindAsync(s.IdCitta);
            if (citta != null)
            {
                _db.Studenti.Add(s);
                await _db.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public string StatoToString(IServizioStudenti.StudentiDelCorso s)
        {
            List<string> stato = new List<string>();
            if (s.NonAmmesso) stato.Add("Non Ammesso");
            if (s.Ritirato) stato.Add("Ritirato");
            return string.Join(", ", stato);
        }

        public string TipoDiplomaToString(Studente s)
        {
            string diploma="";
            switch (s.TipoDiploma)
            {
                case TipoDiploma.DiplomaMaturita:
                    diploma = "Diploma di Maturità";
                    break;
                case TipoDiploma.DottoratoDiRicerca:
                    diploma = "Dottorato di Ricerca";
                    break;
                case TipoDiploma.LaureaMagistrale:
                    diploma = "Laurea Magistrale";
                    break;
                case TipoDiploma.LaureaTriennale:
                    diploma = "Laurea Triennale";
                    break;
                case TipoDiploma.NessunDiploma:
                    diploma = "Nessun Diploma";
                    break;
            }
            return diploma;
        }
    }
}
