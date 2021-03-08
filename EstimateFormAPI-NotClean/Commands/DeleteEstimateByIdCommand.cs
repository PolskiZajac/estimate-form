using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;

namespace WebAPI.Commands
{
    public class DeleteEstimateByIdCommand : IRequest
    {
        public int Id { get; }

        public DeleteEstimateByIdCommand(int id)
        {
            Id = id;
        }

        public class DeleteEstimateByIdCommandHandler : IRequestHandler<DeleteEstimateByIdCommand>
        {
            private readonly IEstimateRepository _repository;

            public DeleteEstimateByIdCommandHandler(IEstimateRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(DeleteEstimateByIdCommand request, CancellationToken cancellationToken)
            {
                await _repository.DeleteEstimate(request.Id, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
