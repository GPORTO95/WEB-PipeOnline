using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Data.Repository
{
    public class ProspectEmployeeRepository : IProspectEmployeeRepository
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<ProspectEmployee> DbSet;

        public ProspectEmployeeRepository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<ProspectEmployee>();
        }

        public async Task<List<ProspectEmployee>> ObterTodosPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(x => x.ProspectId == id).ToListAsync();
        }

        public async Task Remover(List<ProspectEmployee> prospectEmployees)
        {
            DbSet.RemoveRange(prospectEmployees);
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
