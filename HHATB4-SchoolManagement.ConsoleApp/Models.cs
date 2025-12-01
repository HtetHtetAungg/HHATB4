using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHATB4_SchoolManagement.ConsoleApp
{
    internal class Models
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Grade { get; set; }
        }

        public class Teacher
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Subject { get; set; }
        }

        public class Classroom
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
