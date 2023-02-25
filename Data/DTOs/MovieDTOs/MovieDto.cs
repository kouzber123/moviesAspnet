using System.Text.Json.Serialization;

namespace tomtest.Data.DTOs
{
  public class MovieDto
  {

    [JsonIgnore]
    public int Id { get; set; }

    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string PictureUrl { get; set; }
    public string TrailerUrl { get; set; }
    public CharacterDto[] Characters { get; set; }

    [JsonIgnore]
    public int FranchiseId { get; set; }
    public FranchiseDto Franchise { get; set; }
  }
}