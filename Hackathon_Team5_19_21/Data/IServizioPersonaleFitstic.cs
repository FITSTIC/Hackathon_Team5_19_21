﻿using System.Collections.Generic;
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
        Task<bool> SalvaPersona(PersonaFitstic p);
        Task<bool> EliminaPersona(PersonaFitstic p);
        Task<bool> ControllaRuoli(PersonaFitstic p);
        Task<Amministratore> GetAdminByEmail(string email);
        Task SalvaCambiamenti();
        Task ReimpostaRuoli(PersonaFitstic p);
        string Ruoli(PersonaFitstic p);
    }
}
