using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioPersonaleFitstic
    {
        Task<List<PersonaFitstic>> GetDocenti();
        Task<List<PersonaFitstic>> GetTutor();
        Task<List<PersonaFitstic>> GetOrganizzatori();
        Task<PersonaFitstic> GetPersonaById(int id);
        Task<List<PersonaFitstic>> GetPersonale();
        Task SalvaPersona(PersonaFitstic p);
        Task EliminaPersona(PersonaFitstic p);
        Task<bool> ControllaRuoli(PersonaFitstic p);
        Task<Amministratore> GetAdminByEmail(string email);
        Task SalvaCambiamenti();
        Task ReimpostaRuoli(PersonaFitstic p);
    }
}
