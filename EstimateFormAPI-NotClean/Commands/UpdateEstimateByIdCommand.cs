using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;

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
            private readonly EstimateContext _db;

            public UpdateEstimateByIdCommandHandler(EstimateContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(UpdateEstimateByIdCommand request, CancellationToken cancellationToken)
            {
                if (request.Value == null) throw new EstimateNotComplete();
                var record = await _db.Estimates.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (record == null) throw new EstimateNotFoundException(request.Id);
                record.Name = request.Value.Name;
                record.Type = request.Value.Type;
                record.Value = request.Value.Value;
                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
