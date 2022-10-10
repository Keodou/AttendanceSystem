namespace DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RfidTag { get; set; }

        public string Attendance { get; set; }

        public string AttendanceTime { get; set; }
    }
}
