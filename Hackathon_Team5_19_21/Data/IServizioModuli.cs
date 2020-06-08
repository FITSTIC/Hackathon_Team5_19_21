using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioModuli
    {
        Task SalvaModulo(ApplicationDbContext db, Modulo modulo);
        Task<List<Modulo>> GetModuli(ApplicationDbContext db);
        Task<List<Modulo>> GetModuli(ApplicationDbContext db, Corso corso);
        Task<PersonaFitstic> GetTutorDelModulo(ApplicationDbContext db, Modulo modulo);
        Task<PersonaFitstic> GetDocenteDelModulo(ApplicationDbContext db, Modulo modulo);
        
        Task EliminaModulo(ApplicationDbContext db, Modulo modulo);
    }
}
