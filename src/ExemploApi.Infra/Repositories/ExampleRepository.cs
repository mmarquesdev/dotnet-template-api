using ExemploApi.Domain.Entities;
using ExemploApi.Domain.Repositories;
using ExemploApi.Infra.Context;
using ExemploApi.Infra.Repositories.Base;

namespace ExemploApi.Infra.Repositories
{
    public class ExampleRepository : RepositoryBase<Example, Guid>, IExampleRepository
    {
        public ExampleRepository(ExampleDbContext context) : base(context)
        {
            _context = context;
        }

        private readonly ExampleDbContext _context;
    }
}
