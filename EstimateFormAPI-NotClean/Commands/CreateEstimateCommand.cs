using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EFDataAccessLibrary.Features.Estimates;
using Shared.Estimates;
using Shared.Exceptions;

namespace WebAPI.Commands
{
    public class CreateEstimateCommand : IRequest
    {
        public Estimate Value { get; }
        public CreateEstimateCommand(Estimate value)
        {
            this.Value = value;
        }

        public class CreateEstimateCommandHandler : IRequestHandler<CreateEstimateCommand>
        {
            private readonly IEstimateRepository _repository;

            public CreateEstimateCommandHandler(IEstimateRepository estimateRepository)
            {
                _repository = estimateRepository;
            }

            public async Task<Unit> Handle(CreateEstimateCommand request, CancellationToken cancellationToken)
            {
                await _repository.AddEstimate(request.Value, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
