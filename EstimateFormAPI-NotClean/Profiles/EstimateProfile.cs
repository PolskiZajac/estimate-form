using AutoMapper;

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
