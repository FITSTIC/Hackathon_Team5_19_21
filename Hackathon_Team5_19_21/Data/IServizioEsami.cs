using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioEsami
    {
        Task<List<RisultatoQuery>> GetEsamiByIdModulo(int Id);
        Task<bool> SalvaEsame(int idStudIscritto, int idModulo, int voto, DateTime? data);
        Task<List<Esame>> GetEsamiUltimoAnno();
        public class RisultatoQuery
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataNascita { get; set; }
            public DateTime? DataEsame { get; set; }
            public bool IsEditing { get; set; }
            public int Voto { get; set; }
        }
    }
}
