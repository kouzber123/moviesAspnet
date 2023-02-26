using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using tomtest.Data.DTOs;
using tomtest.Data.DTOs.CharacterDTOs;
using tomtest.Data.Exception;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Controllers
{

  public class CharacterController : BaseApiController
  {
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public CharacterController(ICharacterRepository characterRepository, IMapper mapper)
    {
      _mapper = mapper;


      _characterRepository = characterRepository;
    }



    // Gets all characters in the repository
    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<CharactersWithMoviesListDto>>> GetCharacters()
    {
      var characters = await _characterRepository.GetAll();

      return Ok(characters);
    }


    // Get a character by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterDto>> GetbyId(int id)
    {
      if (id < 0)
      {
        var errorResult = new Result
        {
          Success = false,
          Message = "Invalid Id"
        };
        return BadRequest(errorResult);
      }
      var character = await _characterRepository.GetById(id);
      if (character == null)
      {
        var errorResult = new Result
        {
          Success = false,
          Message = "ID not found"
        };
        return NotFound(errorResult);
      }

      return Ok(character);
    }


    // Adds a character to the character repository.
    [HttpPost("AddCharacter")]

    public async Task<ActionResult<CharacterDto>> PostCharacter(CreateCharacterDto character)
    {
      var result = await _characterRepository.Add(character);
      return Ok(result);
    }


    [HttpPatch("UpdateCharacter/{id}")]
    public async Task<ActionResult> Update(int id, UpdateCharacterDto characterDto)
    {

      try
      {
        await _characterRepository.Update(id, characterDto);
        return NoContent();
      }
      catch (ArgumentException ex)
      {

        return NotFound(ex.Message);
      }

    }

    [HttpDelete("DeleteCharacter/{id}")]
    public IActionResult Delete(int id)
    {
       _characterRepository.Delete(id);

      return NoContent();
    }

  }
}