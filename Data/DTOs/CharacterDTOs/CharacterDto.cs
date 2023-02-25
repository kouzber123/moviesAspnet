using System.Text.Json.Serialization;

namespace tomtest.Data.DTOs
{
  public class CharacterDto
  {
    [JsonIgnore]
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Alias { get; set; }
    public string Gender { get; set; }
    public string PictureUrl { get; set; }

    public ICollection<MovieDto> Movies { get; set; }
  }
}