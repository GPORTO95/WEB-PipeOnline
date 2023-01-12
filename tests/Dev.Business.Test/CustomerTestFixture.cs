using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using Dev.Business.Models;
using Dev.Business.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using Xunit;

namespace Dev.Business.Test
{
    [CollectionDefinition(nameof(CustomerCollection))]
    public class CustomerCollection : ICollectionFixture<CustomerTestFixture> { }

    public class CustomerTestFixture : IDisposable
    {
        public CustomerService CustomerService;
        public AutoMocker Mocker;

        public IEnumerable<Customer> GenerateCustomers(int quantity)
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var customers = new Faker<Customer>("pt_BR")
                .CustomInstantiator(f => new Customer(
                    Guid.NewGuid(),
                    $"{f.Name.FirstName(gender)} {f.Name.LastName(gender)}",
                    f.Company.Cnpj(false),
                    "",
                    Guid.NewGuid()))
                .RuleFor(c => c.Email, (f, c) =>
                    f.Internet.Email(c.Name.ToLower()));

            return customers.Generate(quantity);
        }

        public Customer GenerateInvalidCustomers()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var customers = new Faker<Customer>("pt_BR")
                .CustomInstantiator(f => new Customer(
                    Guid.NewGuid(),
                    $"{f.Name.FirstName(gender)} {f.Name.LastName(gender)}",
                    f.Company.Cnpj(false),
                    "",
                    Guid.NewGuid()));

            return customers;
        }

        public CustomerService GetCustomerService()
        {
            Mocker = new AutoMocker();
            CustomerService = Mocker.CreateInstance<CustomerService>();

            return CustomerService;
        }

        public void Dispose() { }
    }
}
