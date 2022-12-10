using DAL.Data;
using DAL.Models.Entities;

namespace DAL.Models.Repositories
{
    public class UsersRepository
    {
        private readonly RFIDSystemDbContext _dbConext;

        public UsersRepository(RFIDSystemDbContext dbContext)
        {
            _dbConext = dbContext;
        }

        public IQueryable<User> GetStudents()
        {
            return _dbConext.Users.OrderBy(u => u.Id);
        }
    }
}
