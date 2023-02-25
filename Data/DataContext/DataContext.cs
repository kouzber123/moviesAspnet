using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using moviesDb.Models;
using tomtest.Data.DTOs;
using tomtest.Data.Models;

namespace moviesDb
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<CharacterMovie> CharacterMovies { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Franchise> Franchises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Character>()
      .HasMany(c => c.Movies)
      .WithMany(m => m.Characters)
      .UsingEntity<CharacterMovie>();
    }

  }

}