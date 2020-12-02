using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MeuDbContext context ) : base(context)
        { }

    }
}
