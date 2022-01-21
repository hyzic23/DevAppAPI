using System.Threading.Tasks;
using Dev.App.Api.DataAccess.Repo;
using Dev.App.Api.Interfaces;

namespace Dev.App.Api.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public ICityRepository CityRepository => 
            new CityRepository(dataContext);

        public async Task<bool> SaveAsync()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}