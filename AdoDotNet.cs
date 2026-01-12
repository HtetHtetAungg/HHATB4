using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHA_B4_ConsoleApp;

internal class AdoDotNet
{
    private readonly SqlConnection _db;

    public AdoDotNet(string connectionString)
    {
        _db = new SqlConnection(connectionString);
    }
    public void ShowAll()
    {

        _db.Open();
        string query = "Select * from Tbl_Medicine";
        SqlCommand cmd = new SqlCommand(query, _db);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        _db.Close();

        Console.WriteLine("_______Medicines_______");

        foreach (DataRow dr in dt.Rows)
        {

            Console.WriteLine("ID: " + dr["MedicineId"].ToString());
            Console.WriteLine("Name: " + dr["Name"].ToString());
            Console.WriteLine("Price: " + dr["Price"].ToString());
            Console.WriteLine("Stock: " + dr["Stock"].ToString());
            Console.WriteLine("Category: " + dr["Category"].ToString());
            Console.WriteLine("...................");

        }
    }

    public void AddMedicine()
    {
        Console.WriteLine("____Medine to add_____");

        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        if (name is null) return;

        Console.Write("Price: ");
        decimal price = decimal.Parse(Console.ReadLine()!);
        if (price == 0) return;

        Console.Write("Category: ");
        string category = Console.ReadLine()!;
        if (category is null) return;

        Console.Write("Stock: ");
        int stock = int.Parse(Console.ReadLine()!);
        if (stock == 0) return;

        string query = @"INSERT INTO [dbo].[Tbl_Medicine] 
                        ([Name], [Price], [Stock], [Category], [CreatedDate], [IsActive])
                        VALUES (@Name, @Price, @Stock, @Category, @CreatedDate, @IsActive)";

        _db.Open();
        var command = new SqlCommand(query, _db);

        // Use parameters to prevent SQL Injection
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Price", price);
        command.Parameters.AddWithValue("@Stock", stock);
        command.Parameters.AddWithValue("@Category", category);
        command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
        command.Parameters.AddWithValue("@IsActive", true);


        int rowsAffected = command.ExecuteNonQuery();


        Console.WriteLine(rowsAffected > 0 ? "Successfully added!" : "Failed to add.");
        _db.Close();

    }

    public void EditMedicine()
    {
        Console.WriteLine("____Medicine to edit____");

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine()!);
        _db.Open();
        string query = $"Select * from Tbl_Medicine where MedicineId = {id}";
        SqlCommand cmd = new SqlCommand(query, _db);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        _db.Close();

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("Medicine not found!");
            return;
        }

        DataRow dr = dt.Rows[0];

        Console.WriteLine("_______Medicine_______");
        Console.WriteLine("Name: " + dr["Name"].ToString());
        Console.WriteLine("Price: " + dr["Price"].ToString());
        Console.WriteLine("Stock: " + dr["Stock"].ToString());
        Console.WriteLine("Category: " + dr["Category"].ToString());
        Console.WriteLine("Created at: " + dr["CreatedDate"].ToString());
        Console.WriteLine("Modified at: " + dr["ModifiedBy"].ToString());
        Console.WriteLine("Is Active: " + dr["IsActive"].ToString());

        Console.WriteLine("...................");

    }
    public void UpdateMedicine()
    {
        Console.WriteLine("____Medicine to update____");

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine()!);

        // ===== FETCH =====
        _db.Open();
        string query = $"SELECT * FROM Tbl_Medicine WHERE MedicineId = {id}";
        SqlCommand cmd = new SqlCommand(query, _db);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        _db.Close();

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("Medicine not found!");
            return;
        }

        DataRow dr = dt.Rows[0];

        // ===== INPUT =====
        Console.Write("Enter new name (leave empty to keep same): ");
        string name = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(name))
            dr["Name"] = name;

        Console.Write("Enter new price (leave empty to keep same): ");
        string priceInput = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(priceInput))
            dr["Price"] = decimal.Parse(priceInput);

        Console.Write("Category (leave empty to keep same): ");
        string category = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(category))
            dr["Category"] = category;

        Console.Write("Stock (leave empty to keep same): ");
        string stockInput = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(stockInput))
            dr["Stock"] = int.Parse(stockInput);

        // ===== UPDATE =====
        query = $@"
UPDATE Tbl_Medicine
SET Name = '{dr["Name"]}',
    Price = {dr["Price"]},
    Stock = {dr["Stock"]},
    Category = '{dr["Category"]}',
    ModifiedBy = GETDATE()
WHERE MedicineId = {id}";

        _db.Open();
        new SqlCommand(query, _db).ExecuteNonQuery();
        _db.Close();

        Console.WriteLine("Successfully updated!");

    }
    public void Delete()
    {
        Console.WriteLine("____Medicine to Delete____");

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine()!);
        _db.Open();
        string query = $"Select * from Tbl_Medicine where MedicineId = {id}";
        SqlCommand cmd = new SqlCommand(query, _db);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("Medicine not found!");
            return;
        }

        DataRow dr = dt.Rows[0];

        Console.WriteLine("_____Review Medicine to delete_______");
        Console.WriteLine("Name: " + dr["Name"].ToString());
        Console.WriteLine("Price: " + dr["Price"].ToString());
        Console.WriteLine("Stock: " + dr["Stock"].ToString());
        Console.WriteLine("Category: " + dr["Category"].ToString());
        Console.WriteLine("Created at: " + dr["CreatedDate"].ToString());
        Console.WriteLine("Modified at: " + dr["ModifiedBy"].ToString());
        Console.WriteLine("Is Active: " + dr["IsActive"].ToString());

        Console.WriteLine("...................");
        Console.Write("Are you sure you wanna delete? y/n: ");
        string confirmation = Console.ReadLine()!;
        if (confirmation != null && confirmation.ToLower() == "y")
        {
            query = $"DELETE FROM Tbl_Medicine WHERE MedicineId = {id}";
            SqlCommand deleteCmd = new SqlCommand(query, _db);
            int rowsAffected = deleteCmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected > 0 ? "Successfully deleted!" : "Failed to delete.");
        }

        _db.Close();
    }
}
