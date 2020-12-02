using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Repository
{
    public class ProspectRepository : Repository<Prospect>, IProspectRepository
    {
        public ProspectRepository(MeuDbContext context) : base(context) { }

        public override async Task<Prospect> ObterPorId(Guid id)
        {
            return await Db.Prospects.AsNoTracking()
                .Include(pe => pe.ProspectEmployees)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<List<Prospect>> ObterTodos()
        {
            return await Db.Prospects.AsNoTracking()
                .Include(c => c.Customer)
                .Include(c => c.Company)
                .ToListAsync();
        }
    }
}
