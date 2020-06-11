using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task EliminaCorso(Corso c)
        {
            _db.Corsi.Remove(c);
            await SalvaCambiamenti();
        }

        public async Task<List<Corso>> GetCorsi()
        {
            return await _db.Corsi.OrderByDescending(x => x.AnnoInizio).ThenBy(x=>x.Id).ToListAsync();
        }

        public async Task SalvaCorso(Corso c)
        {
            await _db.Corsi.AddAsync(c);
            await SalvaCambiamenti();
        }
        public async Task SalvaCambiamenti()
        {
            await _db.SaveChangesAsync();
        }
    }
}
