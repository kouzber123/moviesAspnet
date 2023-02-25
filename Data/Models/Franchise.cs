namespace moviesDb.Models
{
  public class Franchise
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }


    //one francise can contain many movies
    public ICollection<Movie> Movies { get; set; }
  }
}