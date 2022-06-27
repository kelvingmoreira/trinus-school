using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Student : Person
    {
        public string Registration { get; set; }

        public List<Enrollment> Enrollments { get; set; }
    }
}
