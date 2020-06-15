using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioEsami
    {
        Task<List<RisultatoQuery>> GetEsamiByIdModulo(int Id);
        Task SalvaEsame(int idStudIscritto, int idModulo, int voto);
        public class RisultatoQuery
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataNascita { get; set; }
            public bool IsEditing { get; set; }
            public int Voto { get; set; }
        }
    }
}
