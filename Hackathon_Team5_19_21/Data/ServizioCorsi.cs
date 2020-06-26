using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public class ServizioCorsi : IServizioCorsi
    {
        private ApplicationDbContext _db;
        public ServizioCorsi(ApplicationDbContext db) { this._db = db; }

        public async Task<Corso> CorsoById(int id)
        {
            return await _db.Corsi.FindAsync(id);
        }

        public async Task<bool> EliminaCorso(Corso c)
        {
            bool result = false;
            Modulo m = await _db.Moduli.FirstOrDefaultAsync(x => x.IdCorso == c.Id);
            StudenteIscritto s = await _db.StudentiIscritti.FirstOrDefaultAsync(x => x.IdCorso == c.Id);

            if (m == null && s == null)
            {
                _db.Corsi.Remove(c);
                await _db.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<List<Corso>> GetCorsi()
        {
            return await _db.Corsi.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<bool> SalvaCorso(Corso c)
        {
            bool result = false;
            Citta citta = await _db.Citta.FindAsync(c.IdCitta);
            PersonaFitstic p = await _db.PersonaleFitstic.FindAsync(c.IdOrganizzatore);
            if (citta != null && p != null)
            {
                _db.Corsi.Add(c);
                await _db.SaveChangesAsync();
                result = true;
            }
            return result;
        }
        public async Task SalvaCambiamenti()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<List<Corso>> GetCorsiAttuali()
        {
            return await _db.Corsi.Where(x => x.AnnoFine >= DateTime.Now.Year).OrderByDescending(x => x.AnnoInizio).ThenBy(x => x.Id).ToListAsync();
        }
    }
}
