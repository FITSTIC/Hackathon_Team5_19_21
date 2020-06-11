using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public class ServizioCitta : IServizioCitta
    {
        private ApplicationDbContext _db;
        public ServizioCitta(ApplicationDbContext db) { this._db = db; }
        public async Task<List<Citta>> GetCitta()
        {
            return await _db.Citta.ToListAsync();
        }

        public async Task<Citta> GetCittaById(int id)
        {
            return await _db.Citta.FindAsync(id);
        }

        public async Task<List<Provincia>> GetProvince()
        {
            return await _db.Province.ToListAsync();
        }

        public async Task<Provincia> GetProvinciaById(int id)
        {
            return await _db.Province.FindAsync(id);
        }

        public async Task<Provincia> GetProvinciaByIdCitta(int id)
        {
            List<Provincia> province = await (from citta in _db.Citta
                                              join provicia in _db.Province on citta.IdProvincia equals provicia.Id
                                              where citta.Id == id
                                              select provicia).ToListAsync();
            return province.Count > 0 ? province[0] : null;
        }

        public async Task<List<Citta>> GetCittaByIdProvicia(int id)
        {
            return await _db.Citta.Where(x => x.IdProvincia == id).ToListAsync();
        }
    }
}
