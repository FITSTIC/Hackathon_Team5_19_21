using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public interface IServizioCitta
    {
        Task<Citta> GetCittaById(int id);
        Task<List<Citta>> GetCitta();
        Task<Provincia> GetProvinciaById(int id);
        Task<Provincia> GetProvinciaByIdCitta(int id);
        Task<List<Citta>> GetCittaByIdProvicia(int id);
        Task<List<Provincia>> GetProvince();
    }
}
