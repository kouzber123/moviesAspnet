using AutoMapper;
using moviesDb.Models;
using tomtest.Data.DTOs;
using tomtest.Data.DTOs.CharacterDTOs;

namespace tomtest.Helpers
{
  public class AutoMappersProfiles : Profile
  {
    public AutoMappersProfiles()
    {

      CreateMap<UpdateCharacterDto, Character>();
      // .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
      // .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
      // .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.Alias))
      // .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.PictureUrl));

      CreateMap<Character, UpdateCharacterDto>();
      CreateMap<Character, CharacterDto>();
      CreateMap<CharacterDto, Character>();

      CreateMap<CreateCharacterDto, Character>();


      CreateMap<Character, CreateCharacterDto>();




    }
  }
}