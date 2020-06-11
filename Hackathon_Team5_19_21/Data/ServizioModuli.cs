using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Hackathon_Team5_19_21.Data
{
    public class ServizioModuli : IServizioModuli
    {
        private ApplicationDbContext _db;
        public ServizioModuli(ApplicationDbContext db) { this._db = db; }
        public async Task<List<Modulo>> GetModuli()
        {
            return await _db.Moduli.ToListAsync();
        }

        public async Task SalvaModulo(Modulo modulo)
        {
            await _db.Moduli.AddAsync(modulo);
            await SalvaCambiamenti();
        }
        public async Task<PersonaFitstic> GetTutorDelModulo(Modulo modulo)
        {
            var tutor = await (from p in _db.PersonaleFitstic
                               join m in _db.Moduli on p.Id equals m.IdTutor
                               where m.Id == modulo.Id && p.Tutor == true
                               select p).ToListAsync();
            return tutor.Count > 0 ? tutor[0] : null;
        }

        public async Task<PersonaFitstic> GetDocenteDelModulo(Modulo modulo)
        {
            var docenti = await (from p in _db.PersonaleFitstic
                                 join m in _db.Moduli on p.Id equals m.IdDocente
                                 where m.Id == modulo.Id && p.Docente == true
                                 select p).ToListAsync();
            return docenti.Count > 0 ? docenti[0] : null;
        }

        public async Task EliminaModulo(Modulo modulo)
        {
            _db.Moduli.Remove(_db.Moduli.First(x => x.Id == modulo.Id));
            await SalvaCambiamenti();
        }

        public async Task<List<Modulo>> GetModuli(Corso corso)
        {
            return await _db.Moduli.Where(x => x.IdCorso == corso.Id).ToListAsync();
        }

        public async Task<List<Modulo>> GetModuliDelCorso(Corso corso)
        {
            return await _db.Moduli.Where(x => x.IdCorso == corso.Id).ToListAsync();
        }

        public async Task<Modulo> GetModuloById(int id)
        {
            return await _db.Moduli.FindAsync(id);
        }

        public async Task SalvaCambiamenti()
        {
            await _db.SaveChangesAsync();
        }
    }
}
