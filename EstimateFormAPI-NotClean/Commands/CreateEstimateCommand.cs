using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;

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
            private readonly EstimateContext _db;

            public CreateEstimateCommandHandler(EstimateContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(CreateEstimateCommand request, CancellationToken cancellationToken)
            {
                await _db.Estimates.AddAsync(request.Value, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
