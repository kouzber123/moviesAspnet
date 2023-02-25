using tomtest.Data.DTOs.FranchiseDTOs;
using tomtest.Data.DTOs.MovieDTOs;

namespace tomtest.Data.DTOs
{
  public class CreateCharacterDto
  {

    public string FullName { get; set; }
    public string Alias { get; set; }
    public string Gender { get; set; }
    public string PictureUrl { get; set; }

    //maybe change ti class
    public ICollection<AddMoviesTocharacterDto> Movies { get; set; }
    public AddFranchiseTocharacterDto Franchise { get; set; }
  }
}