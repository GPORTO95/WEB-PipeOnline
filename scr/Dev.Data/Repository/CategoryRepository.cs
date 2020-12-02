using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Data.Context;

namespace Dev.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MeuDbContext context) : base(context) { }
    }
}
