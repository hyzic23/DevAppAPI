using System.Collections.Generic;
using System.Threading.Tasks;
using Dev.App.Api.Models;

namespace Dev.App.Api.DataAccess.Repo
{
    public interface ICityRepository
    {
         Task<IEnumerable<City>> GetCitiesAsync(); 
         void AddCity(City request);
         void DeleteCity(int cityId);
         //Task<bool> SaveAsync();
    }
}