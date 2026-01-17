using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppDatabase.MedicineDbContext;
namespace HHA_B4_ConsoleApp
{
    internal class EfCoreDf
    {
        private readonly MedDbContext _db;

        public EfCoreDf(string connectionString)
        {
            _db = new MedDbContext(connectionString);
        }

        public void Read()
        {
            var medicines = _db.TblMedicines.ToList();
            Console.WriteLine("_______Medicines_______");
            foreach (var med in medicines)
            {
                Console.WriteLine("ID: " + med.MedicineId);
                Console.WriteLine("Name: " + med.Name);
                Console.WriteLine("Price: " + med.Price);
                Console.WriteLine("Stock: " + med.Stock);
                Console.WriteLine("Category: " + med.Category);
                Console.WriteLine("...................");
            }
        }

        public void Create()
        {
            Console.WriteLine("_______Add New Medicine_______");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter stock: ");
            int stock = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter category: ");
            string category = Console.ReadLine()!;

            var newMed = new TblMedicine
            {
                Name = name,
                Price = price,
                Stock = stock,
                Category = category,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _db.TblMedicines.Add(newMed);
            int row = _db.SaveChanges();
            Console.WriteLine(row > 0 ? "Medicine added successfully." : "Error adding medicine.");
        }

        public void Edit()
        {
            Console.WriteLine("----------Edit Medicine--------");
            Console.WriteLine("Enter medicine id to edit: ");
            int id = int.Parse(Console.ReadLine()!);
            var medicine = _db.TblMedicines.Find(id);
            if (medicine is null) return;

            Console.WriteLine("Name: " + medicine.Name);
            Console.WriteLine("Price: " + medicine.Price);
            Console.WriteLine("Stock: " + medicine.Stock);
            Console.WriteLine("Category: " + medicine.Category);
            Console.WriteLine("Is Active: " + medicine.IsActive);
            Console.WriteLine("Created Date: " + medicine.CreatedDate);
            Console.WriteLine("Modified By: " + medicine.ModifiedBy);
            Console.WriteLine("...................");
        }

        public void Update()
        {
            Console.WriteLine("----------Update Medicine--------");
            Console.WriteLine("Enter medicine id to update: ");
            int id = int.Parse(Console.ReadLine()!);
            var medicine = _db.TblMedicines.Find(id);

            if (medicine is null) return;

            Console.WriteLine("Enter new name: ");
            string nameInput = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(nameInput))
                medicine.Name = nameInput;

            Console.WriteLine("Enter new price: ");
            string priceInput = Console.ReadLine()!;
            if (decimal.TryParse(priceInput, out decimal newPrice))
            medicine.Price = newPrice;

            Console.WriteLine("Enter new stock: ");
            string stockInput = Console.ReadLine()!;
            if (int.TryParse(stockInput, out int newStock))
                medicine.Stock = newStock;

            Console.WriteLine("Enter new category: ");
            string categoryInput = Console.ReadLine()!;

            if (!string.IsNullOrEmpty(categoryInput)) medicine.Category = categoryInput;

            Console.WriteLine("Enter new IsActive (true/false): ");
            string isActiveInput = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(isActiveInput))
                            {
                if (bool.TryParse(isActiveInput, out bool isActive))
                    medicine.IsActive = isActive;
            }

            medicine.ModifiedBy = DateTime.Now;

            int row = _db.SaveChanges();
            Console.WriteLine(row > 0 ? "Medicine updated successfully." : "Error updating medicine.");
        }

        public void Delete()
        {
            Console.WriteLine("--------Delete medicine-----"); 
            Console.WriteLine("Enter medicine id to delete: ");
            int id = int.Parse(Console.ReadLine()!);
            var medicine = _db.TblMedicines.Find(id);
            if (medicine is null) return;

           medicine.IsActive = false;
            //_db.Medicines.Remove(medicine);
            int row = _db.SaveChanges();
            Console.WriteLine(row > 0 ? "Medicine deleted successfully." : "Error deleting medicine.");
        }
    }
}
