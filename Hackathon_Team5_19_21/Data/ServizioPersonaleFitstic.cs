using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon_Team5_19_21.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Team5_19_21.Data
{
    public class ServizioPersonaleFitstic : IServizioPersonaleFitstic
    {
        public async Task<List<PersonaFitstic>> GetDocenti(ApplicationDbContext db)
        {
            return await db.PersonaleFitstic.Where(x => x.Docente).ToListAsync();
        }
        public async Task<List<PersonaFitstic>> GetTutor(ApplicationDbContext db)
        {
            return await db.PersonaleFitstic.Where(x => x.Tutor).ToListAsync();
        }
        public async Task<List<PersonaFitstic>> GetOrganizzatori(ApplicationDbContext db)
        {
            return await db.PersonaleFitstic.Where(x => x.Organizzatore).ToListAsync();
        }

        public async Task<List<PersonaFitstic>> GetPersonale(ApplicationDbContext db)
        {
            return await db.PersonaleFitstic.ToListAsync();
        }

        public async Task SalvaPersona(ApplicationDbContext db, PersonaFitstic p)
        {
            p.Password = p.Password.Sha256();
            await db.PersonaleFitstic.AddAsync(p);
            await db.SaveChangesAsync();
        }

        public async Task EliminaPersona(ApplicationDbContext db, PersonaFitstic p)
        {
            db.PersonaleFitstic.Remove(p);
            await db.SaveChangesAsync();
        }
    }
}
