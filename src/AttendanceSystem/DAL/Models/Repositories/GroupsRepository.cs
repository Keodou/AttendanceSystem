using DAL.Data;
using DAL.Models.Entities;

namespace DAL.Models.Repositories
{
    public class GroupsRepository
    {
        private readonly RFIDSystemDbContext _context;

        public GroupsRepository(RFIDSystemDbContext context)
        {
            _context = context;
        }

        public IQueryable<Group> GetGroups() => _context.Groups;
    }
}
