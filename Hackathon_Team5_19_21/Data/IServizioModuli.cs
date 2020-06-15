using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioModuli
    {
        Task SalvaModulo(Modulo modulo);
        Task<List<Modulo>> GetModuli();
        Task<List<Modulo>> GetModuli(Corso corso);
        Task<PersonaFitstic> GetTutorDelModulo(Modulo modulo);
        Task<PersonaFitstic> GetDocenteDelModulo(Modulo modulo);
        Task<List<Modulo>> GetModuliDelCorso(Corso corso);
        Task<List<Modulo>> GetModuliDelCorso(int idCorso);
        Task EliminaModulo(Modulo modulo);
        Task<Modulo> GetModuloById(int id);
        Task SalvaCambiamenti();
    }
}
