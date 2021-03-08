using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;

namespace WebAPI.Queries
{
    public class GetEstimateByIdQuery : IRequest<Estimate>
    {
        public int Id { get; }

        public GetEstimateByIdQuery(int id)
        {
            Id = id;
        }

        public class GetEstimateByIdQueryHandler : IRequestHandler<GetEstimateByIdQuery, Estimate>
        {
            private readonly EstimateContext _db;

            public GetEstimateByIdQueryHandler(EstimateContext db)
            {
                _db = db;
            }


            public async Task<Estimate> Handle(GetEstimateByIdQuery request, CancellationToken cancellationToken)
            {
                var record = _db.Estimates.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                return await (record.Result != null ? record : throw new EstimateNotFoundException(request.Id));
            }
        }
    }
}
