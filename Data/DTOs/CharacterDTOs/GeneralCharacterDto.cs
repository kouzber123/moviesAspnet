using tomtest.Data.DTOs.MovieDTOs;

namespace tomtest.Data.DTOs
{
  public class GeneralCharacterDto
  {

    public int Id { get; set; }
    public string FullName { get; set; }

    public ICollection<GeneralMovieDto> Movies { get; set; }
  }
}