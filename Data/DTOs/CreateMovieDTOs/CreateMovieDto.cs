using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tomtest.Data.DTOs.CharacterDTOs;

namespace tomtest.Data.DTOs.CreateMovieDTOs
{
  public class CreateMovieDto
  {
    [JsonIgnore]
    public int Id { get; set; }

    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string PictureUrl { get; set; }
    public string TrailerUrl { get; set; }
    public List<UpdateCharacterDto> Characters { get; set; }

    [JsonIgnore]
    public int FranchiseId { get; set; }
    public FranchiseDto Franchise
    {
      get; set;
    }
  }
}