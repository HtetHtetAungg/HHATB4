using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHA_B4_ConsoleApp;

internal class Dapper
{
    private readonly IDbConnection _db;

    public Dapper(string connectionString)
    {
        _db = new SqlConnection(connectionString);
    }

    public void Read()
    {
        string query = "Select * from Tbl_Medicine";
        List<ProductDto> lst = _db.Query<ProductDto>(query).ToList();
        foreach (ProductDto item in lst)
        {
            Console.WriteLine("ID: " + item.MedicineId);
            Console.WriteLine("Name: " + item.Name);
            Console.WriteLine("Price: " + item.Price);
            Console.WriteLine("Stock: " + item.Stock);
            Console.WriteLine("Category: " + item.Category);
            Console.WriteLine("...................");
        }

    }
    public void Create(ProductDto med) {

      string query = @"INSERT INTO [dbo].[Tbl_Medicine] 
                        ([Name], [Price], [Stock], [Category], [CreatedDate], [IsActive])
                        VALUES (@Name, @Price, @Stock, @Category, @CreatedDate, @IsActive)";

       int rows = _db.Execute(query, med);
        Console.WriteLine(rows > 0 ? "Successfully added!" : "Failed to add.");
    }
    public void Update(ProductDto med)
    {
        string sql = @"
    UPDATE Tbl_Medicine
    SET Name = @Name,
        Price = @Price,
        Stock = @Stock,
        Category = @Category,
        ModifiedBy = GETDATE()
    WHERE MedicineId = @MedicineId";

        _db.Execute(sql, med);
    }

    public void Edit(int id){

        string query = "Select * from Tbl_Medicine Where MedicineId = @Id";
        var item = _db.Query<ProductDto>(query, new { Id = id }).FirstOrDefault();
        if (item is null) return; 

        Console.WriteLine("ID: " + item.MedicineId);
        Console.WriteLine("Name: " + item.Name);
        Console.WriteLine("Price: " + item.Price);
        Console.WriteLine("Stock: " + item.Stock);
        Console.WriteLine("Category: " + item.Category);
        Console.WriteLine("...................");
    }

    public void Delete(int id) {
        string query = "UPDATE Tbl_Medicine SET IsActive = 0 WHERE MedicineId = @Id";
        int rows = _db.Execute(query, new { Id = id });
        Console.WriteLine(rows > 0 ? "Successfully deleted!" : "Failed to delete.");
    }

}

