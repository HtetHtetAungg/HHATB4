// See https://aka.ms/new-console-template for more information
using System;

List<Product> Products = new List<Product>();
Start:

Console.WriteLine("Mini POS");
Console.WriteLine("========");
Console.WriteLine("1. Add Product");
Console.WriteLine("2. View products");
Console.WriteLine("3. Exit");

Console.Write("Select an option: ");
var option = Convert.ToInt32(Console.ReadLine());

switch (option)
{
    case 1:
        AddProduct();
        goto Start; 
        break;

    case 2:
        GetProduct();
        goto Start;
        break;

    case 3:
    default:
        break;
}

void GetProduct()
{
    Console.WriteLine("....................");
    Console.WriteLine("Products List: ");
    foreach(Product product in Products)
    {
        Console.WriteLine($"Name: {product.Name} / Price: {product.Price} / Quantity: {product.Quantity}");
        Console.WriteLine("---------------");
    }

}

void AddProduct()
{
    Console.Write("Enter product name: ");
    var name = Console.ReadLine();
    Console.Write("Enter product price: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());  
    Console.Write("Enter product quantity: ");
    int quantity = Convert.ToInt32(Console.ReadLine());

    Product product = new Product
    {
        Name = name,
        Price = price,
        Quantity = quantity
    };

    Products.Add(product);

    Console.WriteLine("....................");
    Console.WriteLine("Product added successfully!");
    Console.WriteLine("....................");
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}