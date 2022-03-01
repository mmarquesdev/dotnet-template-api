using MediatR;
using ExemploApi.Domain.Commands.Base;
using ExemploApi.Domain.Repositories;

namespace ExemploApi.Domain.Commands.Examples
{
    public class CreateExampleCommandHandler : CommandHandler, IRequestHandler<CreateExampleCommand, CommandResult>
    {
        public CreateExampleCommandHandler(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        private readonly IExampleRepository _exampleRepository;

        public async Task<CommandResult> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (request.IsInvalid())
                return await Task.FromResult(new ErrorCommandResult("Invalid fields", request.Notifications));


            return await Task.FromResult(new SuccessCommandResult());
        }
    }
}
