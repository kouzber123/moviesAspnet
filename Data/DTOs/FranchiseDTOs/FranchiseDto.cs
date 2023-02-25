using System.Text.Json.Serialization;

namespace tomtest.Data.DTOs
{
  public class FranchiseDto
  {

    [JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

  }
}