using AutoMapper;
using CeeStore.DAL.Entities;
using CeeStore.Shared;

namespace CeeStore.BLL.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //
            CreateMap<BuyerForRegistrationDto, AppUser>();
            CreateMap<SellerForRegistrationDto, AppUser>();
            CreateMap<AppUser, SellerForRegistrationDto>();
            CreateMap<AdminForRegistrationDto, AppUser>();

            //
            CreateMap<CreatePrductRequestDto, Product>();            
            CreateMap<Product, ProductDto>();
            CreateMap<Product, CreatePrductRequestDto>();
            CreateMap<Product, ProductResponseDto>();
            //var result = _mapper.Map<List<CreatePrductRequestDto>>(allProducts);
            //
            CreateMap<PaymentRequestDto, Payment>();
        }
    }
}

