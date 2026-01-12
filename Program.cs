using Microsoft.Extensions.Configuration;

namespace HHA_B4_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string connStr = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetConnectionString("PharmacyDb")!;

            //AdoDotNet 
            var Ado = new AdoDotNet(connStr);

            Ado.ShowAll(); 
            Console.ReadLine();

            //Ado.AddMedicine();
            //Console.ReadLine();

            //Ado.ShowAll();
            //Console.ReadLine();

            //Ado.EditMedicine();
            //Console.ReadLine();

            Ado.UpdateMedicine();
            Console.ReadLine();

            Ado.Delete();
            Console.ReadLine();

            Ado.ShowAll();
            Console.ReadLine();

            

        }
    }
}
