using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Entities
{
    public class AttendanceRecord
    {
        public int Id { get; set; }
        public string Attendance { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime? AttendanceTime { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
