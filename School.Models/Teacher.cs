﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Teacher : Person
    {
        public string GraduationField { get; set; }

        public Subject Subject { get; set; }
    }
}
