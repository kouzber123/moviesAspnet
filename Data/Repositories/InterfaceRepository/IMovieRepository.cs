using tomtest.Data.DTOs;
using tomtest.Data.DTOs.CreateMovieDTOs;
using tomtest.Data.DTOs.MovieDTOs;
using tomtest.Data.DTOs.UpdateMovieDTOs;

namespace tomtest.Data.Repositories.InterfaceRepository
{
  public interface IMovieRepository
  {
    Task<List<MovieListDto>> GetAll();
    Task<MovieDto> GetById(int id);
    Task<CreateMovieDto> Add(CreateMovieDto MovieDto);
    void Delete(int id);
    Task<bool> Update(int id,  UpdateMovieDto MovieDto);

  }
}