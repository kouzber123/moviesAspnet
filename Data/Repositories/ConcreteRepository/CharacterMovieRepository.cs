using tomtest.Data.DTOs;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Data.Repositories.ConcreteRepository
{
  public class MovieCharacterRepository : IMovieCharacterRepository
  {
    public Task<CharacterMovieDto> Add(CharacterMovieDto CharacterMovieDto)
    {
      throw new NotImplementedException();
    }

    public Task<CharacterMovieDto> Deletel(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CharacterMovieDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<CharacterMovieDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<CharacterMovieDto> Update(int id, CharacterMovieDto CharacterMovieDto)
    {
      throw new NotImplementedException();
    }
  }
}