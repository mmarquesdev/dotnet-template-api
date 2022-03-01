using ExemploApi.Domain.Queries.Base;

namespace ExemploApi.Domain.Queries.Examples
{
    public class GetExampleByIdQuery : QueryBase
    {
        public Guid Id { get; set; }

        public override void Validate()
        {
        }
    }

    public class GetExampleByIdQueryResult
    {

    }
}
