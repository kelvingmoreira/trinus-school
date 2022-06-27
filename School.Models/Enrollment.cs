using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Enrollment : DbObject
    {
        public Student Student { get; set; }

        public Subject Subject { get; set; }
    }
}
