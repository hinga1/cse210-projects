using System;
using System.Collections.Generic;

// Product class
class Product
{
    public string Name { get; set; }
    public int ProductID { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

// Address class
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }
}

// Customer class
class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool IsInUSA()
    {
        return Address.Country == "USA";
    }
}

// Order class
class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (Product product in Products)
        {
            totalPrice += product.Price * product.Quantity;
        }
        return totalPrice;
    }

    public string GeneratePackingLabel()
    {
        string packingLabel = "";
        packingLabel += "Customer: " + Customer.Name + Environment.NewLine;
        packingLabel += "Shipping Address: " + Customer.Address.Street + ", " + Customer.Address.City + ", " + Customer.Address.StateProvince + ", " + Customer.Address.Country + Environment.NewLine;
        packingLabel += "Products:" + Environment.NewLine;
        foreach (Product product in Products)
        {
            packingLabel += "- " + product.Name + " (ID: " + product.ProductID + ")" + Environment.NewLine;
        }
        return packingLabel;
    }

    public string GenerateShippingLabel()
    {
        string shippingLabel = "";
        shippingLabel += "Shipping Address: " + Customer.Address.Street + ", " + Customer.Address.City + ", " + Customer.Address.StateProvince + ", " + Customer.Address.Country;
        return shippingLabel;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating products
        Product product1 = new Product
        {
            Name = "Product 1",
            ProductID = 1,
            Price = 10,
            Quantity = 2
        };

        Product product2 = new Product
        {
            Name = "Product 2",
            ProductID = 2,
            Price = 5,
            Quantity = 3
        };

        // Creating address
        Address address = new Address
        {
            Street = "123 Main Street",
            City = "New York",
            StateProvince = "NY",
            Country = "USA"
        };

        // Creating customer
        Customer customer = new Customer
        {
            Name = "John Doe",
            Address = address
        };

        // Creating order
        Order order = new Order
        {
            Products = new List<Product> { product1, product2 },
            Customer = customer
        };

        // Generating packing label
        string packingLabel = order.GeneratePackingLabel();
        Console.WriteLine("Packing Label:");
        Console.WriteLine(packingLabel);

        // Generating shipping label
        string shippingLabel = order.GenerateShippingLabel();
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(shippingLabel);

        // Calculating total price
        decimal totalPrice = order.CalculateTotalPrice();
        Console.WriteLine("Total Price: $" + totalPrice);

        Console.ReadLine();
    }
}
