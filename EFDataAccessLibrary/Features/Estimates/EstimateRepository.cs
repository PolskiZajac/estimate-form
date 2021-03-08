using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Estimates;
using Shared.Exceptions;


namespace EFDataAccessLibrary.Features.Estimates
{
    public class EstimateRepository : IEstimateRepository
    {
        private readonly EstimateContext _db;

        public EstimateRepository(EstimateContext db)
        {
            _db = db;
        }

        public async Task<IList<Estimate>> GetAllEstimates(CancellationToken cancellationToken)
        {
            return await _db.Estimates.ToListAsync(cancellationToken);
        }

        public async Task<Estimate> GetEstimateById(int id, CancellationToken cancellationToken)
        {
            var record = await _db.Estimates.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            return record ?? throw new EstimateNotFoundException(id);
        }

        public async Task AddEstimate(Estimate estimate, CancellationToken cancellationToken)
        {
            if (estimate == null) throw new EstimateNotComplete();
            try
            {
                await _db.Estimates.AddAsync(estimate, cancellationToken);
            }
            catch
            {
                throw new EstimateNotComplete();
            }
            await Save(cancellationToken);
        }

        public async Task UpdateEstimate(int id, Estimate estimate, CancellationToken cancellationToken)
        {
            if (estimate == null) throw new EstimateNotComplete();
            var record = await GetEstimateById(id, cancellationToken);
            record.Name = estimate.Name;
            record.Type = estimate.Type;
            record.Value = estimate.Value;
            await Save(cancellationToken);
        }

        public async Task DeleteEstimate(int id, CancellationToken cancellationToken)
        {
            var record = await GetEstimateById(id, cancellationToken);
            try
            {
                _db.Remove(record);
            }
            catch
            {
                throw new Exception($"Something went wrong when removing estimate with id={id}");
            }
            await Save(cancellationToken);
        }

        private async Task Save(CancellationToken cancellationToken)
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
