using tomtest.Data.DTOs;

namespace tomtest.Data.Repositories.InterfaceRepository
{
  public interface IMovieRepository
  {
    Task<IEnumerable<MovieDto>> GetAll();
    Task<MovieDto> GetById(int id);
    Task<MovieDto> Add(MovieDto MovieDto);
    Task<MovieDto> Deletel(int id);
    Task<MovieDto> Update(int id, MovieDto MovieDto);
  }
}