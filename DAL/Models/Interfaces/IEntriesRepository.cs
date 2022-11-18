using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IEntriesRepository
    {
        IQueryable<Student> GetEntries();
        // Student AddEntry();
        //int GetEntriesById(int number);
        Student? GetEntryByTag(string tag);
        void SaveChanges(Student student);
    }
}
