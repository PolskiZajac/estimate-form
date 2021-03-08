using System.Threading;
using System.Threading.Tasks;
using EFDataAccessLibrary.Features.Estimates;
using MediatR;
using Shared.Estimates;

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
            private readonly IEstimateRepository _repository;

            public GetEstimateByIdQueryHandler( IEstimateRepository repository)
            {
                _repository = repository;
            }


            public async Task<Estimate> Handle(GetEstimateByIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetEstimateById(request.Id, cancellationToken);
            }
        }
    }
}
