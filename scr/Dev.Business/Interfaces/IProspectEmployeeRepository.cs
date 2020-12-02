using Dev.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces
{
    public interface IProspectEmployeeRepository : IDisposable
    {
        Task<List<ProspectEmployee>> ObterTodosPorId(Guid id);
        Task Remover(List<ProspectEmployee> prospectEmployees);
    }
}
