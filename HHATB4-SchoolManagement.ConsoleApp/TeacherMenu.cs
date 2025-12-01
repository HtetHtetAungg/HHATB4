using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHATB4_SchoolManagement.ConsoleApp
{
    internal class TeacherMenu
    {
        public static void Show(Database db)
        {
        Start:
            Console.WriteLine("---- Teacher Menu ----");
            Console.WriteLine("1. View Students");
            Console.WriteLine("2. View Classes");
            Console.WriteLine("3. Logout");
            Console.Write("Choose an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ViewStudents(db);
                    goto Start;
                case 2:
                    ViewClasses(db);
                    goto Start;
                case 3:
                    Console.WriteLine("Logging out...");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    goto Start;
            }
        }

        private static void ViewStudents(Database db)
        {
            if (db.Students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("---- Students List ----");
            foreach (var student in db.Students)
            {
                Console.WriteLine($"ID: {student.Id} | Name: {student.Name} | Age: {student.Age} | Grade: {student.Grade}");
            }
        }

        private static void ViewClasses(Database db)
        {
            if (db.Classes.Count == 0)
            {
                Console.WriteLine("No classes found.");
                return;
            }

            Console.WriteLine("---- Classes List ----");
            foreach (var cls in db.Classes)
            {
                Console.WriteLine($"ID: {cls.Id} | Name: {cls.Name}");
            }
        }
    }
}
