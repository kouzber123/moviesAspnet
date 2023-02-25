using tomtest.Data.DTOs;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Data.Repositories.ConcreteRepository
{
  public class FranchiseRepository : IFranchiseRepository
  {
    public Task<FranchiseDto> Add(FranchiseDto franchiseDto)
    {
      throw new NotImplementedException();
    }

    public Task<FranchiseDto> Deletel(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<FranchiseDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<FranchiseDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<FranchiseDto> Update(int id, FranchiseDto franchiseDto)
    {
      throw new NotImplementedException();
    }
  }
}