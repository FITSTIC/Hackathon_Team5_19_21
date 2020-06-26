using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public class ServizioEsami : IServizioEsami
    {
        ApplicationDbContext _db;
        public ServizioEsami(ApplicationDbContext db)
        {
            this._db = db;
        }
        public async Task<List<IServizioEsami.RisultatoQuery>> GetEsamiByIdModulo(int Id)
        {
            List<IServizioEsami.RisultatoQuery> voti = new List<IServizioEsami.RisultatoQuery>();

            var votiStudenti = await (from studente in _db.Studenti
                                      join studenteIscritto in _db.StudentiIscritti on studente.Id equals studenteIscritto.IdStudente
                                      join esame in _db.Esami on studenteIscritto.Id equals esame.IdStudenteIscritto
                                      where studenteIscritto.Ritirato == false && studenteIscritto.NonAmmesso == false && esame.IdModulo == Id
                                      select new IServizioEsami.RisultatoQuery { Id = studenteIscritto.Id, Nome = studente.Nome, Cognome = studente.Cognome, DataNascita = studente.DataNascita, Voto = esame.Voto, DataEsame = esame.Data, IsEditing = false }).ToListAsync();

            var studentiCorso = await (from studente in _db.Studenti
                                       join studenteIscritto in _db.StudentiIscritti on studente.Id equals studenteIscritto.IdStudente
                                       join corso in _db.Corsi on studenteIscritto.IdCorso equals corso.Id
                                       where studenteIscritto.Ritirato == false && studenteIscritto.NonAmmesso == false
                                       select new IServizioEsami.RisultatoQuery { Id = studenteIscritto.Id, Nome = studente.Nome, Cognome = studente.Cognome, DataNascita = studente.DataNascita, Voto = 0, DataEsame = null, IsEditing = false }).ToListAsync();

            foreach (var studente in studentiCorso)
            {
                if (votiStudenti.Find(x => x.Id == studente.Id) == null) voti.Add(studente);
                else voti.Add(votiStudenti.Find(x => x.Id == studente.Id));
            }

            return voti;
        }

        public async Task<List<Esame>> GetEsamiUltimoAnno()
        {
            return await _db.Esami.Where(x => x.Data >= DateTime.Now.AddYears(-1)).ToListAsync();
        }

        public async Task<bool> SalvaEsame(int idStudIscritto, int idModulo, int voto, DateTime? data)
        {
            bool result = false;
            Modulo m = await _db.Moduli.FindAsync(idModulo);
            StudenteIscritto studIscr = await _db.StudentiIscritti.FindAsync(idStudIscritto);
            if (m != null && studIscr != null && voto >= 0 && voto <= 100)
            {
                var q1 = await (from studente in _db.Studenti
                                join studenteIscritto in _db.StudentiIscritti on studente.Id equals studenteIscritto.IdStudente
                                join esame in _db.Esami on studenteIscritto.Id equals esame.IdStudenteIscritto
                                where studenteIscritto.Id == idStudIscritto && esame.IdModulo == idModulo
                                select esame).ToListAsync();
                if (q1.Count == 0) _db.Esami.Add(new Esame { IdModulo = idModulo, Voto = voto, IdStudenteIscritto = idStudIscritto, Data = data });
                else { q1[0].Voto = voto; q1[0].Data = data; }

                await _db.SaveChangesAsync();
                result = true;
            }
            return result;
        }
    }
}
