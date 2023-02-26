using tomtest.Data.DTOs.FranchiseDTOs;

namespace tomtest.Data.DTOs.MovieDTOs
{
    // General Movie DTO.
  public class GeneralMovieDto
  {

    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string PictureUrl { get; set; }
    public string TrailerUrl { get; set; }
    public GeneralFranchiseDto Franchise { get; set; }

  }
}