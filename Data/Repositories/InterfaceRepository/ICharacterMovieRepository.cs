using tomtest.Data.DTOs;

namespace tomtest.Data.Repositories.InterfaceRepository
{
  public interface IMovieCharacterRepository
  {
    Task<IEnumerable<CharacterMovieDto>> GetAll();
    Task<CharacterMovieDto> GetById(int id);
    Task<CharacterMovieDto> Add(CharacterMovieDto CharacterMovieDto);
    Task<CharacterMovieDto> Deletel(int id);
    Task<CharacterMovieDto> Update(int id, CharacterMovieDto CharacterMovieDto);
  }
}