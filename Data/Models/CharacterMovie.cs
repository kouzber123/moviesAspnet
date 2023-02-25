using moviesDb.Models;

namespace tomtest.Data.Models
{
  public class CharacterMovie
  {

    public int MovieId { get; set; }
    public Movie Movie { get; set; }


    public int CharacterId { get; set; }
    public Character Character { get; set; }

  }
}