using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shared.Estimates;


namespace EFDataAccessLibrary.Features.Estimates
{
    public interface IEstimateRepository
    {
        Task<IList<Estimate>> GetAllEstimates(CancellationToken cancellationToken);
        Task<Estimate> GetEstimateById(int id, CancellationToken cancellationToken);
        Task AddEstimate(Estimate estimate, CancellationToken cancellationToken);
        Task UpdateEstimate(int id, Estimate estimate, CancellationToken cancellationToken);
        Task DeleteEstimate(int id, CancellationToken cancellationToken);
    }
}
