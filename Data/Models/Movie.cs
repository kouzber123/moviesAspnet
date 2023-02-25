using tomtest.Data.Models;

namespace moviesDb.Models
{
  public class Movie
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string PictureUrl { get; set; }
    public string TrailerUrl { get; set; }

    public ICollection<Character> Characters { get; set; }

    //one movie belongs to one francise
    public int FranchiseId { get; set; }
    public Franchise Franchise { get; set; }
  }
}