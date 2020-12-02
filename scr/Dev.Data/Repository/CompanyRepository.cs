using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Data.Context;

namespace Dev.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(MeuDbContext context) : base(context) { }
    }
}
