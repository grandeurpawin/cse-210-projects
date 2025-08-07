using System;

class Program
{
    static void Main(string[] args)
    {
       
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", "W123", 10.0, 2));
        order1.AddProduct(new Product("Gadget", "G456", 15.5, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}\n");

        
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Thingamajig", "T789", 7.25, 3));
        order2.AddProduct(new Product("Doohickey", "D012", 12.0, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");

    }
}