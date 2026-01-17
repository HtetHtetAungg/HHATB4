using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHA_B4_ConsoleApp
{
    internal class EfCore
    {
        private readonly AppDbContext _db;

        public EfCore(string connectionString)
        {
            _db = new AppDbContext(connectionString);
        }

        public void Read()
        {
            var medicines = _db.Medicines.ToList();
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
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter stock: ");
            int stock = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter category: ");
            string category = Console.ReadLine()!;

            var newMed = new ProductEntity
            {
                Name = name,
                Price = price,
                Stock = stock,
                Category = category,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _db.Medicines.Add(newMed);
            int row = _db.SaveChanges();
            Console.WriteLine(row > 0 ? "Medicine added successfully." : "Error adding medicine.");
        }

        public void Edit()
        {
            Console.WriteLine("Enter medicine id to delete: ");
            int id = int.Parse(Console.ReadLine()!);
            var medicine = _db.Medicines.Find(id);
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
            Console.WriteLine("Enter medicine id to update: ");
            int id = int.Parse(Console.ReadLine()!);
            var medicine = _db.Medicines.Find(id);

            if (medicine is null) return;

            Console.WriteLine("Enter new name: ");
            string nameInput = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(nameInput))
                medicine.Name = nameInput;

            Console.WriteLine("Enter new price: ");
            string priceInput = Console.ReadLine()!;
            if (decimal.TryParse(priceInput, out decimal newPrice))
            medicine.Price = newPrice;

            int row = _db.SaveChanges();
            Console.WriteLine(row > 0 ? "Medicine updated successfully." : "Error updating medicine.");
        }

        public void Delete()
        {
            Console.WriteLine("Enter medicine id to delete: ");
            int id = int.Parse(Console.ReadLine()!);
            var medicine = _db.Medicines.Find(id);
            if (medicine is null) return;

           medicine.IsActive = false;
            //_db.Medicines.Remove(medicine);
            int row = _db.SaveChanges();
            Console.WriteLine(row > 0 ? "Medicine deleted successfully." : "Error deleting medicine.");
        }
    }
}
