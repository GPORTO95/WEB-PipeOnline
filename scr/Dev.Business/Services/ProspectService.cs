using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Business.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public class ProspectService : BaseService, IProspectService
    {
        private readonly IProspectRepository _prospectRepository;
        private readonly ITotvsRepository _totvsRepository;
        private readonly IProspectEmployeeRepository _prospectEmployeeRepository;

        public ProspectService(
            IProspectRepository prospectRepositor,
            IProspectEmployeeRepository prospectEmployeeRepository,
            ITotvsRepository totvsRepository,
            INotifier notificador) : base(notificador)
        {
            _prospectRepository = prospectRepositor;
            _totvsRepository = totvsRepository;
            _prospectEmployeeRepository = prospectEmployeeRepository;
        }
        public async Task Adicionar(Prospect prospect)
        {
            //Validar o estado da entidade!
            if (!ExecutarValidacao(new ProspectValidation(), prospect))
                return;

            prospect.AddIdPsp(_totvsRepository.ObterIdPSP("02", "09"));
            prospect.AddOpening();
            prospect.AddValueSold();

            await _prospectRepository.Adicionar(prospect);
        }

        public async Task Atualizar(Prospect prospect)
        {
            //Validar o estado da entidade!
            if (!ExecutarValidacao(new ProspectValidation(), prospect))
                return;

            var listaPE = await _prospectEmployeeRepository.ObterTodosPorId(prospect.Id);
            
            if(listaPE.Any())
                await _prospectEmployeeRepository.Remover(listaPE);

            await _prospectRepository.Atualizar(prospect);
        }

        public async Task Remover(Guid id)
        {
            var listaPE = await _prospectEmployeeRepository.ObterTodosPorId(id);

            if (listaPE.Any())
                await _prospectEmployeeRepository.Remover(listaPE);

            await _prospectRepository.Remover(id);
        }

        public void Dispose()
        {
            _prospectRepository?.Dispose();
        }
    }
}
