using Dev.Business.Interfaces;
using Dev.Business.Services;
using Moq;
using Moq.AutoMock;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Dev.Business.Test.ServiceTests
{
    [Collection(nameof(CustomerCollection))]
    public class CustomerServiceTests
    {
        readonly CustomerTestFixture _customerTestsBogus;
        private readonly CustomerService _customerService;

        public CustomerServiceTests(CustomerTestFixture customerTestsBogus)
        {
            _customerTestsBogus = customerTestsBogus;
            _customerService = _customerTestsBogus.GetCustomerService();
        }

        [Fact(DisplayName = "Successfully add customer")]
        [Trait("Customer", "Customer Service Tests")]
        public async Task CustomerService_Add_ShouldBeSuccess()
        {
            // Arrange 
            var customer = _customerTestsBogus.GenerateCustomers(1).FirstOrDefault();

            // Act
            await _customerService.Adicionar(customer);

            // Assert
            _customerTestsBogus.Mocker.GetMock<ICustomerRepository>().Verify(r => r.Adicionar(customer), Times.Once);
        }

        [Fact(DisplayName = "Failed add customer")]
        [Trait("Customer", "Customer Service Tests")]
        public async Task CustomerService_Add_ShouldBeFailed()
        {
            // Arrange 
            var customer = _customerTestsBogus.GenerateInvalidCustomers();

            // Act
            await _customerService.Adicionar(customer);

            // Assert
            _customerTestsBogus.Mocker.GetMock<ICustomerRepository>().Verify(r => r.Adicionar(customer), Times.Never);
        }
    }
}
