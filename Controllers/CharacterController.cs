using Microsoft.AspNetCore.Mvc;
using tomtest.Data.DTOs;
using tomtest.Data.Exception;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Controllers
{

  public class CharacterController : BaseApiController
  {
    private readonly ICharacterRepository _characterRepository;
    public CharacterController(ICharacterRepository characterRepository)
    {

      _characterRepository = characterRepository;
    }
    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<GeneralCharacterDto>>> GetCharacters()
    {
      var characters = await _characterRepository.GetAll();

      return Ok(characters);
    }
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
    [HttpPost("AddCharacter")]
    public async Task<ActionResult<CharacterDto>> PostCharacter(CreateCharacterDto character)
    {
      // var users = JsonSerializer.Deserialize<List<Character>>(userData);

      var result = await _characterRepository.Add(character);
      return Ok(result);
    }
    // [HttpGet("GetId")]
    // public async Task<ActionResult<IEnumerable<GeneralCharacterDto>>> GetCharac()
    // {
    //   var characters = await _characterRepository.GetAll();

    //   return Ok(characters);
    // }
    // [HttpGet("GetAll")]
    // public async Task<ActionResult<IEnumerable<GeneralCharacterDto>>> GetCharacters()
    // {
    //   var characters = await _characterRepository.GetAll();

    //   return Ok(characters);
    // }
  }
}