using AutoMapper;
using Shared.Estimates;


namespace EFDataAccessLibrary.Features.Estimates
{
    public class EstimateProfile : Profile
    {
        public EstimateProfile()
        {
            CreateMap<Estimate, EstimateDto>();
        }
    }
}
