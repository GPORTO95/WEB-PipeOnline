using Dev.Business.Models;
using System;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces
{
    public interface ICustomerService: IDisposable
    {
        Task Adicionar(Customer customer);
        Task Atualizar(Customer customer);
    }
}
