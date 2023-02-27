using AutoMapper;
using moviesDb.Models;
using tomtest.Data.DTOs;
using tomtest.Data.DTOs.CharacterDTOs;
using tomtest.Data.DTOs.CreateMovieDTOs;
using tomtest.Data.DTOs.UpdateMovieDTOs;

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

      CreateMap<MovieDto, Movie>();
      CreateMap<Movie, MovieDto>();

      CreateMap<CreateMovieDto, Movie>();
      CreateMap<Movie, CreateMovieDto>();

      CreateMap<Franchise, FranchiseDto>();
      CreateMap<FranchiseDto, Franchise>();



      CreateMap<UpdateMovieDto, Movie>();
      CreateMap<Movie, UpdateMovieDto>();



    }
  }
}