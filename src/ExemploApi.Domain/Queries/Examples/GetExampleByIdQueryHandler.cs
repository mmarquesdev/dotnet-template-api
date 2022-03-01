using MediatR;
using ExemploApi.Domain.Queries.Base;
using ExemploApi.Domain.Repositories;

namespace ExemploApi.Domain.Queries.Examples
{
    public class GetExampleByIdQueryHandler : QueryHandler, IRequestHandler<GetExampleByIdQuery, QueryBaseResult>
    {
        public GetExampleByIdQueryHandler(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        private readonly IExampleRepository _exampleRepository;

        public async Task<QueryBaseResult> Handle(GetExampleByIdQuery request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorQueryBaseResult(
                    "Invalid fields", request.Notifications));


            return await Task.FromResult(new QueryBaseSingleResult<GetExampleByIdQueryResult>(new GetExampleByIdQueryResult()));
        }
    }
}
