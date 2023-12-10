using System;
using System.Collections.Generic;

// Address class to store information about an address
class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    // Method to return the address as a formatted string
    public string GetFormattedAddress()
    {
        return $"{StreetAddress}\n{City}, {StateProvince}\n{Country}";
    }
}

// Customer class to store information about a customer
class Customer
{
    public string Name { get; set; }
    public Address CustomerAddress { get; set; }

    // Method to check if the customer is in the USA
    public bool IsInUSA()
    {
        return CustomerAddress.IsInUSA();
    }
}

// Product class to store information about a product
class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // Method to calculate the total price of the product
    public decimal CalculateTotalPrice()
    {
        return Price * Quantity;
    }
}

// Order class to store information about an order
class Order
{
    private List<Product> Products { get; set; } = new List<Product>();
    public Customer Customer { get; set; }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    // Method to calculate the total cost of the order
    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;

        foreach (var product in Products)
        {
            totalCost += product.CalculateTotalPrice();
        }

        // Add one-time shipping cost based on customer location
        totalCost += Customer.IsInUSA() ? 5 : 35;

        return totalCost;
    }

    // Method to return a packing label
    public string GetPackingLabel()
    {
        var packingLabel = "Packing Label:\n";

        foreach (var product in Products)
        {
            packingLabel += $"{product.Name} (ID: {product.ProductId})\n";
        }

        return packingLabel;
    }

    // Method to return a shipping label
    public string GetShippingLabel()
    {
        var shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Customer: {Customer.Name}\n";
        shippingLabel += $"Address:\n{Customer.CustomerAddress.GetFormattedAddress()}";

        return shippingLabel;
    }
}

class Program
{
    static void Main()
    {
        // Create products
        var product1 = new Product { Name = "Product 1", ProductId = 101, Price = 10.99m, Quantity = 2 };
        var product2 = new Product { Name = "Product 2", ProductId = 102, Price = 24.99m, Quantity = 1 };
        var product3 = new Product { Name = "Product 3", ProductId = 103, Price = 15.49m, Quantity = 3 };

        // Create customer and address
        var customer = new Customer
        {
            Name = "John Doe",
            CustomerAddress = new Address
            {
                StreetAddress = "123 Main St",
                City = "Anytown",
                StateProvince = "CA",
                Country = "USA"
            }
        };

        // Create orders and add products
        var order1 = new Order { Customer = customer };
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order { Customer = customer };
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display results
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}
