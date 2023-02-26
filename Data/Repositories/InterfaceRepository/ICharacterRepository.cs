using Microsoft.AspNetCore.Mvc;
using moviesDb.Models;
using tomtest.Data.DTOs;
using tomtest.Data.DTOs.CharacterDTOs;

namespace tomtest.Data.Repositories.InterfaceRepository
{
  public interface ICharacterRepository
  {
    //crud

    //gets all characters
    Task<List<CharactersWithMoviesListDto>> GetAll();

    //by id
    Task<CharacterDto> GetById(int id);

    //add
    Task<CharacterDto> Add(CreateCharacterDto characterDto);

    //delete
    void Delete(int id);
    //update
    Task<bool> Update(int id, UpdateCharacterDto characterDto);




  }
}