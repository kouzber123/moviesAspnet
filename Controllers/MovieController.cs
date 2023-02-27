using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tomtest.Data.DTOs;
using tomtest.Data.DTOs.CreateMovieDTOs;
using tomtest.Data.DTOs.MovieDTOs;
using tomtest.Data.DTOs.UpdateMovieDTOs;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Controllers
{
  public class MovieController : BaseApiController
  {
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;
    public MovieController(IMovieRepository movieRepository, IMapper mapper)
    {
      _mapper = mapper;
      _movieRepository = movieRepository;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<MovieListDto>>> GetAll()
    {
      var movies = await _movieRepository.GetAll();

      return Ok(movies);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetbyId(int id)
    {
      var movies = await _movieRepository.GetById(id);

      return Ok(movies);
    }

    [HttpPost("AddMovie")]

    public async Task<ActionResult<CreateMovieDto>> AddMovie(CreateMovieDto movieDto)
    {
      var movie = await _movieRepository.Add(movieDto);
      var id = movie.Id;
      return CreatedAtAction(nameof(AddMovie), id, movie);
    }

    [HttpDelete("DeleteMovie/{id}")]

    public IActionResult Delete(int id)
    {
      _movieRepository.Delete(id);

      return NoContent();
    }

    [HttpPatch("UpdateMovie/{id}")]

    public async Task<ActionResult> Update(int id, UpdateMovieDto movieDto)
    {

      try
      {
        await _movieRepository.Update(id, movieDto);
        return NoContent();
      }
      catch (ArgumentException ex)
      {

        return NotFound(ex.Message);
      }


    }
  }
}