using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IEntriesRepository
    {
        IQueryable<Student> GetEntriesDb();
        void UpdateAttendance(string tag);
        void SaveChanges(Student student);
    }
}
