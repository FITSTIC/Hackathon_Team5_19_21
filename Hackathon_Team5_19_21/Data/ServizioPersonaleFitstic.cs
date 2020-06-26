using Hackathon_Team5_19_21.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<bool> SalvaPersona(PersonaFitstic p)
        {
            bool result = false;
            Amministratore admin = await _db.Amministratori.FindAsync(p.IdAmministratore);
            if (admin != null)
            {
                p.Password = p.Password.Sha256();
                _db.PersonaleFitstic.Add(p);
                await _db.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<bool> EliminaPersona(PersonaFitstic p)
        {
            bool result = false;
            Modulo m1 = await _db.Moduli.FirstOrDefaultAsync(x => x.IdDocente == p.Id);
            Modulo m2 = await _db.Moduli.FirstOrDefaultAsync(x => x.IdTutor == p.Id);
            Corso c = await _db.Corsi.FirstOrDefaultAsync(x => x.IdOrganizzatore == p.Id);
            if (m1 == null && m2 == null && c == null)
            {
                _db.PersonaleFitstic.Remove(p);
                await _db.SaveChangesAsync();
                result = true;
            }
            return result;
        }
        private async Task<List<Modulo>> GetModuliDocente(PersonaFitstic p)
        {
            return await (from persona in _db.PersonaleFitstic
                          join modulo in _db.Moduli on persona.Id equals modulo.IdDocente
                          where persona.Id == p.Id
                          select modulo).ToListAsync();
        }
        private async Task<List<Modulo>> GetModuliTutor(PersonaFitstic p)
        {
            return await (from persona in _db.PersonaleFitstic
                          join modulo in _db.Moduli on persona.Id equals modulo.IdTutor
                          where persona.Id == p.Id
                          select modulo).ToListAsync();
        }
        private async Task<List<Corso>> GetModuliOrganizzatore(PersonaFitstic p)
        {
            return await (from persona in _db.PersonaleFitstic
                          join corso in _db.Corsi on persona.Id equals corso.IdOrganizzatore
                          where persona.Id == p.Id
                          select corso).ToListAsync();
        }

        public async Task<bool> ControllaRuoli(PersonaFitstic p)
        {
            List<Modulo> moduliDocente = await GetModuliDocente(p);
            List<Modulo> moduliTutor = await GetModuliTutor(p);
            List<Corso> corsiOrganizzatore = await GetModuliOrganizzatore(p);
            return !((moduliDocente.Count > 0 && p.Docente == false) || (moduliTutor.Count > 0 && p.Tutor == false) || (corsiOrganizzatore.Count > 0 && p.Organizzatore == false));

        }

        public async Task<PersonaFitstic> GetPersonaById(int id)
        {
            return await _db.PersonaleFitstic.FindAsync(id);
        }

        public async Task<Amministratore> GetAdminByEmail(string email)
        {
            return await _db.Amministratori.FirstAsync(x => x.Email == email);
        }

        public async Task SalvaCambiamenti()
        {
            await _db.SaveChangesAsync();
        }

        public async Task ReimpostaRuoli(PersonaFitstic p)
        {
            List<Modulo> moduliDocente = await GetModuliDocente(p);
            List<Modulo> moduliTutor = await GetModuliTutor(p);
            List<Corso> corsiOrganizzatore = await GetModuliOrganizzatore(p);

            p.Docente = moduliDocente.Count > 0;
            p.Tutor = moduliTutor.Count > 0;
            p.Organizzatore = corsiOrganizzatore.Count > 0;
            await _db.SaveChangesAsync();
        }

        public string Ruoli(PersonaFitstic p)
        {
            List<string> ruoli = new List<string>();
            if (p.Docente) ruoli.Add("Docente");
            if (p.Tutor) ruoli.Add("Tutor");
            if (p.Organizzatore) ruoli.Add("Organizzatore");
            return ruoli.Count > 0 ? string.Join(", ", ruoli) : "Nessun Ruolo";
        }
    }
}
