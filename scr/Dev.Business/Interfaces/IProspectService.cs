using Dev.Business.Models;
using System;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces
{
    public interface IProspectService: IDisposable
    {
        Task Adicionar(Prospect prospect);
        Task Atualizar(Prospect prospect);
        Task Remover(Guid id);
    }
}
