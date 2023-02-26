using AutoMapper;
using Microsoft.EntityFrameworkCore;
using moviesDb;
using moviesDb.Models;
using tomtest.Data.DTOs;
using tomtest.Data.DTOs.CharacterDTOs;
using tomtest.Data.DTOs.FranchiseDTOs;
using tomtest.Data.DTOs.MovieDTOs;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Data.Repositories.ConcreteRepository
{
  public class CharacterRepository : ICharacterRepository
  {
    private readonly DataContext _context;

    private readonly IMapper _mapper;

    public CharacterRepository(DataContext context, IMapper mapper)
    {
      _mapper = mapper;

      _context = context;
    }

    public async Task<bool> Update(int id, UpdateCharacterDto characterDto)
    {

      var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);

      if (character == null)
      {
        throw new ArgumentNullException("ID was not found");
      }

      _mapper.Map(characterDto, character);
      _context.Entry(character).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return true;

    }

    // Creates a character.
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

    public void Delete(int id)
    {
      var character = _context.Characters.FirstOrDefault(x => x.Id == id);

      if (character != null)
      {
        _context.Characters.Remove(character);
        _context.SaveChanges();
      }
    }

    // Get all franchises.
    public async Task<List<CharactersWithMoviesListDto>> GetAll()
    {

      var characters = await _context.Characters
      .Include(c => c.Movies)
      .ThenInclude(m => m.Franchise)
      .ToListAsync();

      return characters.Select(c => new CharactersWithMoviesListDto
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

    // Gets a franchise by id.
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
  }
}


