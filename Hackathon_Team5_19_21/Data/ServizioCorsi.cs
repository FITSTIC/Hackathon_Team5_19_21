using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon_Team5_19_21.Data
{
    public class ServizioCorsi : IServizioCorsi
    {
        public async Task<List<Corso>> GetCorsi(ApplicationDbContext db)
        {
            return await db.Corsi.ToListAsync();
        }
    }
}
