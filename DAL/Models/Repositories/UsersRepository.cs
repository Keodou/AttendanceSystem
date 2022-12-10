using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Repositories
{
    public class UsersRepository
    {
        private readonly RFIDSystemDbContext _dbConext;

        public UsersRepository(RFIDSystemDbContext dbContext)
        {
            _dbConext = dbContext;
        }
    }
}
