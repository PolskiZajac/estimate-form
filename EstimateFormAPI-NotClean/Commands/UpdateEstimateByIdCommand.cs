using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;
using Shared.Estimates;

namespace WebAPI.Commands
{
    public class UpdateEstimateByIdCommand : IRequest
    {
        public int Id { get; }
        public Estimate Value { get; }

        public UpdateEstimateByIdCommand(int id, Estimate value)
        {
            Id = id;
            Value = value;
        }

        public class UpdateEstimateByIdCommandHandler : IRequestHandler<UpdateEstimateByIdCommand>
        {
            private readonly IEstimateRepository _repository;

            public UpdateEstimateByIdCommandHandler(IEstimateRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(UpdateEstimateByIdCommand request, CancellationToken cancellationToken)
            {
                await _repository.UpdateEstimate(request.Id, request.Value, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
