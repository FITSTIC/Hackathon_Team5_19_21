using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioPersonaleFitstic
    {
        Task<List<PersonaFitstic>> GetDocenti(ApplicationDbContext db);
        Task<List<PersonaFitstic>> GetTutor(ApplicationDbContext db);
        Task<List<PersonaFitstic>> GetOrganizzatori(ApplicationDbContext db);
        Task<List<PersonaFitstic>> GetPersonale(ApplicationDbContext db);
        Task SalvaPersona(ApplicationDbContext db, PersonaFitstic p);
        Task EliminaPersona(ApplicationDbContext db, PersonaFitstic p);
    }
}
