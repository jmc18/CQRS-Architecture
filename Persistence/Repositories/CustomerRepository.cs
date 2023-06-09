using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CustomerRepository<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;

        public CustomerRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
