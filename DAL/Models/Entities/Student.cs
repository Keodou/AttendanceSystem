namespace DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RFIDTag { get; set; }

        public string Attendance { get; set; }

        public string AttendanceTime { get; set; }
    }
}
