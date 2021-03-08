using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;
using Shared.Estimates;

namespace WebAPI.Queries
{
    public class GetAllEstimatesQuery : IRequest<List<Estimate>>
    {
        public class GetAllEstimatesQueryHandler : IRequestHandler<GetAllEstimatesQuery, List<Estimate>>
        {
            private readonly IEstimateRepository _repository;

            public GetAllEstimatesQueryHandler(IEstimateRepository estimateRepository)
            {
                _repository = estimateRepository;
            }

            public async Task<List<Estimate>> Handle(GetAllEstimatesQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetAllEstimates(cancellationToken) as List<Estimate>;
            }
        }
    }
}
