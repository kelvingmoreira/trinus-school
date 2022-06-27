using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public abstract class Person : DbObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
