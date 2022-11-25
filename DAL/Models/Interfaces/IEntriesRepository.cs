using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IEntriesRepository
    {
        IQueryable<Student> GetEntries();
        Student? GetEntryByTag(string tag);
        void Save(Student student);
        void Delete(Student? entry);
    }
}
