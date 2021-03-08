using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;

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
            private readonly EstimateContext _db;

            public DeleteEstimateByIdCommandHandler(EstimateContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(DeleteEstimateByIdCommand request, CancellationToken cancellationToken)
            {
                var record = await _db.Estimates.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (record == null) throw new EstimateNotFoundException(request.Id);
                _db.Estimates.Remove(record);
                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
