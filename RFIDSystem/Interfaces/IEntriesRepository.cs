namespace RFIDSystem.Interfaces
{
    public interface IEntriesRepository
    {
        IQueryable<Student> GetEntriesDb();
        void UpdateEntryDb(string tag);
    }
}
