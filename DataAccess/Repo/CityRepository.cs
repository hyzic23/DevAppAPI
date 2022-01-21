using System.Collections.Generic;
using System.Threading.Tasks;
using Dev.App.Api.DataAccess;
using Dev.App.Api.Models;
using Microsoft.EntityFrameworkCore;
using Dev.App.Api.Interfaces;


namespace Dev.App.Api.DataAccess.Repo
{
    public class CityRepository : ICityRepository
    {

        private DataContext dataContext { get; }
        public CityRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        

        public void AddCity(City request)
        {
            dataContext.Cities.Add(request);
        }

        public void DeleteCity(int cityId)
        {
            var city = dataContext.Cities.Find(cityId);
            dataContext.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dataContext.Cities.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}