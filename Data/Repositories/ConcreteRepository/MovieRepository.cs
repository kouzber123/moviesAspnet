using tomtest.Data.DTOs;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Data.Repositories.ConcreteRepository
{
  public class MovieRepository : IMovieRepository
  {
    public Task<MovieDto> Add(MovieDto MovieDto)
    {
      throw new NotImplementedException();
    }

    public Task<MovieDto> Deletel(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<MovieDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<MovieDto> Update(int id, MovieDto MovieDto)
    {
      throw new NotImplementedException();
    }
  }
}