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

            #region Ado
            //AdoDotNet 
            var Ado = new AdoDotNet(connStr);

            //Ado.ShowAll(); 
            //Console.ReadLine();

            //Ado.AddMedicine();
            //Console.ReadLine();

            //Ado.ShowAll();
            //Console.ReadLine();

            //Ado.EditMedicine();
            //Console.ReadLine();

            //Ado.UpdateMedicine();
            //Console.ReadLine();

            //Ado.Delete();
            //Console.ReadLine();

            //Ado.ShowAll();
            //Console.ReadLine();

            #endregion

            #region Dapper
            var dap = new Dapper(connStr);

            //dap.Read();
            //Console.ReadLine();

            //var newMed = new ProductDto
            //{
            //    Name = "DapperMed",
            //    Price = 1900,
            //    Stock = 50,
            //    Category = "DapperCategory",
            //    CreatedDate = DateTime.Now,
            //    IsActive = true 
            //};

            //dap.Create(newMed);

            //dap.Update(new ProductDto
            //{
            //    MedicineId = 15,
            //    Name = "UpdatedDapperMed2",
            //    Price = 5000,
            //    Stock = 60,
            //    Category = "UpdatedDapperCategory2",
            //    ModifiedBy = DateTime.Now,
            //    IsActive = true
            //});
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadLine();

            //dap.Edit(15);
            //Console.ReadLine();
            //dap.Delete(15);

            #endregion

            var efdf = new EfCoreDf(connStr);
            efdf.Read();
            Console.ReadLine();
            efdf.Create();
            Console.ReadLine();
            efdf.Edit();
            Console.ReadLine();
            efdf.Update();
            Console.ReadLine();
            efdf.Edit();
            Console.ReadLine();
            efdf.Delete();
            Console.ReadLine();


        }
    }
}
