using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HHATB4_SchoolManagement.ConsoleApp.Models;

namespace HHATB4_SchoolManagement.ConsoleApp
{
    internal class Database
    {
       
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Classroom> Classes { get; set; } = new List<Classroom>();
    }
}
