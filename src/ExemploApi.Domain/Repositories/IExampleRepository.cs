using ExemploApi.Domain.Entities;
using ExemploApi.Domain.Repositories.Base;

namespace ExemploApi.Domain.Repositories
{
    public interface  IExampleRepository :  IRepositoryBase<Example, Guid>
    {
    }
}
