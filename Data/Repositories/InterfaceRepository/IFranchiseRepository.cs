using moviesDb.Models;
using tomtest.Data.DTOs;

namespace tomtest.Data.Repositories.InterfaceRepository
{
  public interface IFranchiseRepository
  {
    Task<IEnumerable<FranchiseDto>> GetAll();
    Task<FranchiseDto> GetById(int id);
    Task<FranchiseDto> Add(FranchiseDto franchiseDto);
    Task<FranchiseDto> Deletel(int id);
    Task<FranchiseDto> Update(int id, FranchiseDto franchiseDto);

  }
}