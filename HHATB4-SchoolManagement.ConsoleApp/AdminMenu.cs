using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HHATB4_SchoolManagement.ConsoleApp.Models;

namespace HHATB4_SchoolManagement.ConsoleApp
{
    internal class AdminMenu
    {

        public static void Show(Database db)
        {
        Start:
            Console.WriteLine("---- Admin Menu ----");
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. Manage Teachers");
            Console.WriteLine("3. Manage Classes");
            Console.WriteLine("4. Logout");
            Console.Write("Choose an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ManageStudents(db);
                    goto Start;
                case 2:
                    ManageTeachers(db);
                    goto Start;
                case 3:
                    ManageClasses(db);
                    goto Start;
                case 4:
                    Console.WriteLine("Logging out...");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    goto Start;
            }
        }

        // ---------------- Students CRUD ----------------
        private static void ManageStudents(Database db)
        {
        StudentMenu:
            Console.WriteLine("---- Student Management ----");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Update Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. View Students");
            Console.WriteLine("5. Back");
            Console.Write("Choose an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: AddStudent(db); goto StudentMenu;
                case 2: UpdateStudent(db); goto StudentMenu;
                case 3: DeleteStudent(db); goto StudentMenu;
                case 4: ViewStudents(db); goto StudentMenu;
                case 5: break;
                default: Console.WriteLine("Invalid choice."); goto StudentMenu;
            }
        }

        private static void AddStudent(Database db)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter grade: ");
            string grade = Console.ReadLine();

            int id = db.Students.Count + 1;
            db.Students.Add(new Student { Id = id, Name = name, Age = age, Grade = grade });
            Console.WriteLine("Student added successfully!");
        }

        private static void UpdateStudent(Database db)
        {
            Console.Write("Enter student ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var student = db.Students.Find(s => s.Id == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"ID: {student.Id} | Name: {student.Name} | Age: {student.Age} | Grade: {student.Grade}");
            Console.WriteLine("------------------------");

            Console.Write("Enter new name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) student.Name = name;

            Console.Write("Enter new age: ");
            string ageInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(ageInput)) student.Age = Convert.ToInt32(ageInput);

            Console.Write("Enter new grade: ");
            string grade = Console.ReadLine();
            if (!string.IsNullOrEmpty(grade)) student.Grade = grade;

            Console.WriteLine("Student updated successfully!");
        }

        private static void DeleteStudent(Database db)
        {
            Console.Write("Enter student ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var student = db.Students.Find(s => s.Id == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"Are you sure you want to delete {student.Name}? (Y/N): ");
            string confirm = Console.ReadLine();
            if (confirm.ToUpper() != "Y")
            {
                Console.WriteLine("Deletion cancelled.");
                return;
            }

            for (int i = 0; i < db.Students.Count; i++)
                db.Students[i].Id = i + 1;

            db.Students.Remove(student);
            Console.WriteLine("Student deleted successfully!");
        }


        private static void ViewStudents(Database db)
        {
            if (db.Students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("---- Students List ----");
            foreach (var s in db.Students)
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} | Age: {s.Age} | Grade: {s.Grade}");
        }

        // ---------------- Teachers CRUD ----------------
        private static void ManageTeachers(Database db)
        {
        TeacherMenu:
            Console.WriteLine("---- Teacher Management ----");
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Update Teacher");
            Console.WriteLine("3. Delete Teacher");
            Console.WriteLine("4. View Teachers");
            Console.WriteLine("5. Back");
            Console.Write("Choose an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: AddTeacher(db); goto TeacherMenu;
                case 2: UpdateTeacher(db); goto TeacherMenu;
                case 3: DeleteTeacher(db); goto TeacherMenu;
                case 4: ViewTeachers(db); goto TeacherMenu;
                case 5: break;
                default: Console.WriteLine("Invalid choice."); goto TeacherMenu;
            }
        }

        private static void AddTeacher(Database db)
        {
            Console.Write("Enter teacher name: ");
            string name = Console.ReadLine();
            Console.Write("Enter subject: ");
            string subject = Console.ReadLine();

            int id = db.Teachers.Count + 1;
            db.Teachers.Add(new Teacher { Id = id, Name = name, Subject = subject });
            Console.WriteLine("Teacher added successfully!");
        }

        private static void UpdateTeacher(Database db)
        {
            Console.Write("Enter teacher ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var teacher = db.Teachers.Find(t => t.Id == id);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }


            Console.WriteLine($"ID: {teacher.Id} | Name: {teacher.Name} | Subject: {teacher.Subject}");
            Console.WriteLine("------------------------");

            Console.Write("Enter new name (leave blank to keep current): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) teacher.Name = name;

            Console.Write("Enter new subject (leave blank to keep current): ");
            string subject = Console.ReadLine();
            if (!string.IsNullOrEmpty(subject)) teacher.Subject = subject;

            Console.WriteLine("Teacher updated successfully!");
        }

        private static void DeleteTeacher(Database db)
        {
            Console.Write("Enter teacher ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var teacher = db.Teachers.Find(t => t.Id == id);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            Console.WriteLine($"Are you sure you want to delete {teacher.Name}? (Y/N): ");
            string confirm = Console.ReadLine();
            if (confirm.ToUpper() != "Y")
            {
                Console.WriteLine("Deletion cancelled.");
                return;
            }

            for (int i = 0; i < db.Teachers.Count; i++)
                db.Teachers[i].Id = i + 1;

            db.Teachers.Remove(teacher);
            Console.WriteLine("Teacher deleted successfully!");
        }


        private static void ViewTeachers(Database db)
        {
            if (db.Teachers.Count == 0)
            {
                Console.WriteLine("No teachers found.");
                return;
            }

            Console.WriteLine("---- Teachers List ----");
            foreach (var t in db.Teachers)
                Console.WriteLine($"ID: {t.Id} | Name: {t.Name} | Subject: {t.Subject}");
        }

        // ---------------- Classes CRUD ----------------
        private static void ManageClasses(Database db)
        {
        ClassMenu:
            Console.WriteLine("---- Class Management ----");
            Console.WriteLine("1. Add Class");
            Console.WriteLine("2. Update Class");
            Console.WriteLine("3. Delete Class");
            Console.WriteLine("4. View Classes");
            Console.WriteLine("5. Back");
            Console.Write("Choose an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: AddClass(db); goto ClassMenu;
                case 2: UpdateClass(db); goto ClassMenu;
                case 3: DeleteClass(db); goto ClassMenu;
                case 4: ViewClasses(db); goto ClassMenu;
                case 5: break;
                default: Console.WriteLine("Invalid choice."); goto ClassMenu;
            }
        }

        private static void AddClass(Database db)
        {
            Console.Write("Enter class name: ");
            string name = Console.ReadLine();

            int id = db.Classes.Count + 1;
            db.Classes.Add(new Classroom { Id = id, Name = name });
            Console.WriteLine("Class added successfully!");
        }

        private static void UpdateClass(Database db)
        {
            Console.Write("Enter class ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var cls = db.Classes.Find(c => c.Id == id);
            if (cls == null)
            {
                Console.WriteLine("Class not found.");
                return;
            }

            Console.WriteLine($"ID: {cls.Id} | Name: {cls.Name}");
            Console.WriteLine("------------------------");

            Console.Write("Enter new class name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) cls.Name = name;

            Console.WriteLine("Class updated successfully!");
        }

        private static void DeleteClass(Database db)
        {
            Console.Write("Enter class ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var cls = db.Classes.Find(c => c.Id == id);
            if (cls == null)
            {
                Console.WriteLine("Class not found.");
                return;
            }

            Console.WriteLine($"Are you sure you want to delete {cls.Name}? (Y/N): ");
            string confirm = Console.ReadLine();
            if (confirm.ToUpper() != "Y")
            {
                Console.WriteLine("Deletion cancelled.");
                return;
            }

            for (int i = 0; i < db.Classes.Count; i++)
                db.Classes[i].Id = i + 1;

            db.Classes.Remove(cls);
            Console.WriteLine("Class deleted successfully!");
        }


        private static void ViewClasses(Database db)
        {
            if (db.Classes.Count == 0)
            {
                Console.WriteLine("No classes found.");
                return;
            }

            Console.WriteLine("---- Classes List ----");
            foreach (var c in db.Classes)
                Console.WriteLine($"ID: {c.Id} | Name: {c.Name}");
        }
    }

}

