using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Subject : DbObject
    {
        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public List<Enrollment> Enrollments { get; set; }
    }
}
