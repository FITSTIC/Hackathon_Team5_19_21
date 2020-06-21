using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioCorsi
    {
        Task<List<Corso>> GetCorsi();
        Task<List<Corso>> GetCorsiAttuali();
        Task<bool> EliminaCorso(Corso c);
        Task<bool> SalvaCorso(Corso c);
        Task<Corso> CorsoById(int id);
        Task SalvaCambiamenti();
    }
}
