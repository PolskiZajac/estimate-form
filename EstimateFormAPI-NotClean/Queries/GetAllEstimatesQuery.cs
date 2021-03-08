using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Queries
{
    public class GetAllEstimatesQuery : IRequest<List<Estimate>>
    {
        public class GetAllEstimatesQueryHandler : IRequestHandler<GetAllEstimatesQuery, List<Estimate>>
        {
            private readonly EstimateContext _db;

            public GetAllEstimatesQueryHandler(EstimateContext db)
            {
                _db = db;
            }

            public async Task<List<Estimate>> Handle(GetAllEstimatesQuery request, CancellationToken cancellationToken)
            {
                return await _db.Estimates.ToListAsync(cancellationToken);
            }
        }
    }
}
