using System.Threading.Tasks;
using Dev.App.Api.DataAccess.Repo;

namespace Dev.App.Api.Interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository CityRepository { get; }
         Task<bool> SaveAsync();
    }
}