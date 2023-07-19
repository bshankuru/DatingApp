using API.Controllers.Entities;
using API.DTOs;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {

            CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()))
             .ForMember(dest => dest.KnownAs, opt => opt.MapFrom(src => src.UserName));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto,AppUser>();
        }

    }
}