using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Business.Validations;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(
            ICustomerRepository customerRepository,
            INotifier notificador) : base(notificador)
        {
            _customerRepository = customerRepository;
        }

        public async Task Adicionar(Customer customer)
        {
            if (!ExecutarValidacao(new CustomerValidation(), customer))
                return;

            if(_customerRepository.Buscar(c => c.CNPJ == customer.CNPJ).Result.Any())
            {
                Notificar($"Cliente do CNPJ {customer.CNPJ} já cadastrado em nossa base de dados");
                return;
            }

            await _customerRepository.Adicionar(customer);
        }

        public async Task Atualizar(Customer customer)
        {
            if (!ExecutarValidacao(new CustomerValidation(), customer))
                return;

            if(_customerRepository.Buscar(c => c.CNPJ == customer.CNPJ && c.Id != customer.Id).Result.Any())
            {
                Notificar($"Cliente passado diverge do id encontrado na base");
                return;
            }

            await _customerRepository.Atualizar(customer);

        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
        }
    }
}
