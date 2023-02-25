using Microsoft.EntityFrameworkCore;
using moviesDb;
using moviesDb.Models;
using tomtest.Data.DTOs;
using tomtest.Data.DTOs.FranchiseDTOs;
using tomtest.Data.DTOs.MovieDTOs;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Data.Repositories.ConcreteRepository
{
  public class CharacterRepository : ICharacterRepository
  {
    private readonly DataContext _context;

    public CharacterRepository(DataContext context)
    {

      _context = context;
    }

    public async Task<CharacterDto> Add(CreateCharacterDto characterDto)
    {


      var character = new Character
      {
        Id = 0,
        FullName = characterDto.FullName,
        Alias = characterDto.Alias,
        Gender = characterDto.Gender,
        PictureUrl = characterDto.PictureUrl,
        Movies = characterDto.Movies.Select(x => new Movie
        {

          Id = 0,
          Title = x.Title,
          Genre = x.Genre,
          ReleaseYear = x.ReleaseYear,
          Director = x.Director,
          TrailerUrl = x.TrailerUrl,
          PictureUrl = x.PictureUrl,

          Franchise = new Franchise
          {
            Id = 0,
            Name = characterDto.Franchise.Name,
            Description = characterDto.Franchise.Description
          }
        }).ToList(),
      };

      await _context.AddAsync<Character>(character);
      await _context.SaveChangesAsync();

      //return 

      var savedCharacter = new CharacterDto
      {
        FullName = character.FullName,
        Movies = characterDto.Movies.Select(x => new MovieDto
        {
          Title = x.Title,
          Franchise = new FranchiseDto
          {
            Name = characterDto.Franchise.Name,
          }
        }).ToArray()
      };
      return savedCharacter;
    }

    public Task<CharacterDto> Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<GeneralCharacterDto>> GetAll()
    {

      var characters = await _context.Characters
      .Include(c => c.Movies)
      .ThenInclude(m => m.Franchise)
      .ToListAsync();

      return characters.Select(c => new GeneralCharacterDto
      {
        Id = c.Id,
        FullName = c.FullName,

        Movies = c.Movies.Select(m => new GeneralMovieDto
        {
          Title = m.Title,
          ReleaseYear = m.ReleaseYear,
          Genre = m.Genre,
          Director = m.Director,
          Franchise = new GeneralFranchiseDto
          {
            Name = m.Franchise.Name
          }
        }).ToList()

      }).ToList();


    }
    public async Task<CharacterDto> GetById(int id)
    {

      var character = await _context.Characters
      .Include(c => c.Movies)
      .ThenInclude(m => m.Franchise)
      .SingleOrDefaultAsync(c => c.Id == id);


      if (character == null)
      {
        return null;
      }
      var characterDto = new CharacterDto
      {
        Id = character.Id,
        FullName = character.FullName,
        Alias = character.Alias,
        Gender = character.Gender,
        Movies = character.Movies.Select(x => new MovieDto
        {
          Id = x.Id,
          Title = x.Title,
          Genre = x.Genre,
          Director = x.Director,
          ReleaseYear = x.ReleaseYear,
          PictureUrl = x.PictureUrl,
          TrailerUrl = x.TrailerUrl,
          Franchise = new FranchiseDto
          {
            Id = x.Franchise.Id,
            Name = x.Franchise.Name,
            Description = x.Franchise.Description
          }
        }
        ).ToList()
      };
      return characterDto;
    }

    public Task<CharacterDto> Update(int id, CharacterDto characterDto)
    {
      throw new NotImplementedException();
    }
  }
}


/*
    var newCharacter = character.Select(c => new CharacterDto
      {
        FullName = characterDto.FullName,
        Alias = characterDto.Alias,
        Gender = characterDto.Gender,
        Movies = c.Movies.Select(x => new MovieDto
        {
          Title = characterDto.Movies.Title,
          Director = characterDto.Movies.Director,
          ReleaseYear = characterDto.Movies.ReleaseYear,
          TrailerUrl = characterDto.Movies.TrailerUrl,
          PictureUrl = characterDto.Movies.PictureUrl

        }).ToList()

      }).ToList();
      var movies = new MovieDto
      {
        Title = characterDto.Movies.Title,
        Director = characterDto.Movies.Director,
        ReleaseYear = characterDto.Movies.ReleaseYear,
        TrailerUrl = characterDto.Movies.TrailerUrl,
        PictureUrl = characterDto.Movies.PictureUrl



        var characters = await _context.Characters.Include(c => c.Movies).ThenInclude(m => m.Franchise).ToListAsync();
      var addUser = characters.Select(c => new CharacterDto
      {
        Id = 0,
        FullName = characterDto.FullName,
        Alias = characterDto.Alias,
        Gender = characterDto.Gender,
        PictureUrl = characterDto.PictureUrl,
        Movies = characterDto.Movies.Select(x => new MovieDto
        {
          Id = 0,
          Title = x.Title,
          Genre = x.Genre,
          ReleaseYear = x.ReleaseYear,
          Director = x.Director,
          TrailerUrl = x.TrailerUrl,
          PictureUrl = x.PictureUrl,

          Franchise = new FranchiseDto
          {
            Id = 0,
            Name = characterDto.Franchise.Name,
            Description = characterDto.Franchise.Description
          }
        }).ToList(),

     
      }
           _context.Add(addUser);
      );


      _context.Add.Character(addUser)

      };



      //-----------------------------------

      

*/
