namespace HHATB4_SchoolManagement.ConsoleApp
{
    internal class Program
    {
        public enum UserType
        {
            Admin = 1,
            Teacher = 2
        }

        static void Main(string[] args)
        {
            Database db = new Database(); // single database instance

        Start:
            Console.WriteLine("---- School Management ----");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. Teacher Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose your role: ");

            string input = Console.ReadLine();
            int choice = Convert.ToInt32(input);

            if (choice == (int)UserType.Admin)
            {
                AdminMenu.Show(db);   // send database instance
                goto Start;
            }
            else if (choice == (int)UserType.Teacher)
            {
                TeacherMenu.Show(db); // send database instance
                goto Start;
            }
            else if (choice == 3)
            {
                Console.WriteLine("Exiting...");
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
                goto Start;
            }

        }
    }
}
