using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon_Team5_19_21.Pages;
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

        public async Task<bool> ControllaRuoli(ApplicationDbContext db, PersonaFitstic p)
        {
            List<Modulo> moduliDocente = await (from persona in db.PersonaleFitstic
                                          join modulo in db.Moduli on persona.Id equals modulo.IdDocente
                                          where persona.Id==p.Id
                                          select modulo).ToListAsync();
            List<Modulo> moduliTutor = await (from persona in db.PersonaleFitstic
                                                      join modulo in db.Moduli on persona.Id equals modulo.IdTutor
                                                      where persona.Id == p.Id
                                                      select modulo).ToListAsync();
            List<Corso> corsiOrganizzatore = await (from persona in db.PersonaleFitstic
                                                     join corso in db.Corsi on persona.Id equals corso.IdOrganizzatore
                                                     where persona.Id == p.Id
                                                     select corso).ToListAsync();
            return !((moduliDocente.Count > 0 && p.Docente == false) || (moduliTutor.Count > 0 && p.Tutor == false) || (corsiOrganizzatore.Count > 0 && p.Organizzatore == false));

        }
    }
}
