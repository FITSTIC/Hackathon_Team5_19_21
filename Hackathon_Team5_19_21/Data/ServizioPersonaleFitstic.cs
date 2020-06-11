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
        private ApplicationDbContext _db;
        public ServizioPersonaleFitstic(ApplicationDbContext db) { this._db = db; }
        public async Task<List<PersonaFitstic>> GetDocenti()
        {
            return await _db.PersonaleFitstic.Where(x => x.Docente).ToListAsync();
        }
        public async Task<List<PersonaFitstic>> GetTutor()
        {
            return await _db.PersonaleFitstic.Where(x => x.Tutor).ToListAsync();
        }
        public async Task<List<PersonaFitstic>> GetOrganizzatori()
        {
            return await _db.PersonaleFitstic.Where(x => x.Organizzatore).ToListAsync();
        }

        public async Task<List<PersonaFitstic>> GetPersonale()
        {
            return await _db.PersonaleFitstic.ToListAsync();
        }

        public async Task SalvaPersona(PersonaFitstic p)
        {
            p.Password = p.Password.Sha256();
            await _db.PersonaleFitstic.AddAsync(p);
            await SalvaCambiamenti();
        }

        public async Task EliminaPersona(PersonaFitstic p)
        {
            _db.PersonaleFitstic.Remove(p);
            await SalvaCambiamenti();
        }

        public async Task<bool> ControllaRuoli(PersonaFitstic p)
        {
            List<Modulo> moduliDocente = await (from persona in _db.PersonaleFitstic
                                          join modulo in _db.Moduli on persona.Id equals modulo.IdDocente
                                          where persona.Id==p.Id
                                          select modulo).ToListAsync();
            List<Modulo> moduliTutor = await (from persona in _db.PersonaleFitstic
                                                      join modulo in _db.Moduli on persona.Id equals modulo.IdTutor
                                                      where persona.Id == p.Id
                                                      select modulo).ToListAsync();
            List<Corso> corsiOrganizzatore = await (from persona in _db.PersonaleFitstic
                                                     join corso in _db.Corsi on persona.Id equals corso.IdOrganizzatore
                                                     where persona.Id == p.Id
                                                     select corso).ToListAsync();
            return !((moduliDocente.Count > 0 && p.Docente == false) || (moduliTutor.Count > 0 && p.Tutor == false) || (corsiOrganizzatore.Count > 0 && p.Organizzatore == false));

        }

        public async Task<PersonaFitstic> GetPersonaById(int id)
        {
            return await _db.PersonaleFitstic.FindAsync(id);
        }

        public async Task<Amministratore> GetAdminByEmail(string email)
        {
            return await _db.Amministratori.FirstAsync(x=>x.Email==email);
        }

        public async Task SalvaCambiamenti()
        {
            await _db.SaveChangesAsync();
        }
    }
}
