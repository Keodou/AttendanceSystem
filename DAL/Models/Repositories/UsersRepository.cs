using DAL.Data;
using DAL.Models.Entities;

namespace DAL.Models.Repositories
{
    public class UsersRepository
    {
        private readonly RFIDSystemDbContext _dbContext;

        public UsersRepository(RFIDSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<User> GetUsers()
        {
            return _dbContext.Users;
        }
    }
}
