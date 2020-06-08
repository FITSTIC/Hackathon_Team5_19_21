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
        //ApplicationDbContext db = new ApplicationDbContext();
        public async Task<List<Modulo>> GetModuli(ApplicationDbContext db)
        {
            return await db.Moduli.ToListAsync();
        }

        public async Task SalvaModulo(ApplicationDbContext db, Modulo modulo)
        {
            await db.Moduli.AddAsync(modulo);
            await db.SaveChangesAsync();
        }
        public async Task<PersonaFitstic> GetTutorDelModulo(ApplicationDbContext db, Modulo modulo)
        {
            var tutor = await (from p in db.PersonaleFitstic
                               join m in db.Moduli on p.Id equals m.IdTutor
                               where m.Id == modulo.Id && p.Tutor == true
                               select p).ToListAsync();
            return tutor.Count > 0 ? tutor[0] : null;
        }

        public async Task<PersonaFitstic> GetDocenteDelModulo(ApplicationDbContext db, Modulo modulo)
        {
            var docenti = await (from p in db.PersonaleFitstic
                                 join m in db.Moduli on p.Id equals m.IdDocente
                                 where m.Id == modulo.Id && p.Docente == true
                                 select p).ToListAsync();
            return docenti.Count > 0 ? docenti[0] : null;
        }

        public async Task EliminaModulo(ApplicationDbContext db, Modulo modulo)
        {
            db.Moduli.Remove(db.Moduli.First(x => x.Id == modulo.Id));
            await db.SaveChangesAsync();
        }

        public async Task<List<Modulo>> GetModuli(ApplicationDbContext db, Corso corso)
        {
            return await db.Moduli.Where(x => x.IdCorso == corso.Id).ToListAsync();
        }
    }
}
