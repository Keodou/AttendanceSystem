using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Specialization { get; set; }
        public string University { get; set; }
        public List<Student>? Students { get; set; }
    }
}
