using AutoMapper;
using CeeStore.DAL.Entities;
using CeeStore.Shared;

namespace CeeStore.BLL.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BuyerForRegistrationDto, AppUser>();
            CreateMap<SellerForRegistrationDto, AppUser>();
            CreateMap<AppUser, SellerForRegistrationDto>();
            CreateMap<AdminForRegistrationDto, AppUser>();
        }
    }
}
