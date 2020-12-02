using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Data.Context;

namespace Dev.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MeuDbContext context) : base(context) { }
    }
}
