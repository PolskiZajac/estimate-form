using AutoMapper;
using Shared.Estimates;

namespace WebAPI.Profiles
{
    public class EstimateProfile : Profile
    {
        public EstimateProfile()
        {
            CreateMap<Estimate, EstimateDto>();
        }
    }
}
