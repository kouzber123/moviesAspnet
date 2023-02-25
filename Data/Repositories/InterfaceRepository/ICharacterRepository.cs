using tomtest.Data.DTOs;

namespace tomtest.Data.Repositories.InterfaceRepository
{
  public interface ICharacterRepository
  {
    //crud

    //gets all characters
    Task<List<GeneralCharacterDto>> GetAll();

    //by id
    Task<CharacterDto> GetById(int id);

    //add
    Task<CharacterDto> Add(CreateCharacterDto characterDto);

    //delete
    Task<CharacterDto> Delete(int id);
    //update
    Task<CharacterDto> Update(int id, CharacterDto characterDto);




  }
}