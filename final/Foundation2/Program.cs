using System;

namespace Foundation2
{
    class Program
    {
        static void Main(string[] args)
        {
            // order 1

            Address usaAddress1 = new Address("563 Idaho Rd", "Rexburg", "ID", "USA");
            Customer customerInUSA = new Customer("Ashlynn Hall", usaAddress1);
            Order orderInUSA = new Order(customerInUSA);

            Product product1 = new Product("Nike Dunks", "6658478", 109.99m, 1);
            Product product2 = new Product("Nike Socks", "2456434", 30.99m, 3);

            orderInUSA.AddProduct(product1);
            orderInUSA.AddProduct(product2);

            Console.WriteLine("Order in USA 1:");
            Console.WriteLine($"Packing Label:\n{orderInUSA.GetPackingLabel()}");
            Console.WriteLine($"Shipping Label:\n{orderInUSA.GetShippingLabel()}");
            Console.WriteLine($"Total Price: ${orderInUSA.CalculateTotalCost()}");

            // order 2

            Address usaAddress2 = new Address("64 Spring St", "Spring", "TX", "USA");
            Customer customerInUSA2 = new Customer("Mom Hall", usaAddress2);
            Order orderInUSA2 = new Order(customerInUSA2);

            Product product3 = new Product("Nike Slides", "7512985", 24.99m, 1);
            Product product4 = new Product("Nike Sweatshirt", "8420428", 50.99m, 2);

            orderInUSA2.AddProduct(product3);
            orderInUSA2.AddProduct(product4);

            Console.WriteLine("Order in USA 2:");
            Console.WriteLine($"Packing Label:\n{orderInUSA2.GetPackingLabel()}");
            Console.WriteLine($"Shipping Label:\n{orderInUSA2.GetShippingLabel()}");
            Console.WriteLine($"Total Price: ${orderInUSA2.CalculateTotalCost()}");

            // order 3

            Address nonUsaAddress = new Address("8293 Lyon St", "Toronto", "Ontario", "Canada");
            Customer customerOutsideUSA = new Customer("Francis Campos", nonUsaAddress);
            Order orderOutsideUSA = new Order(customerOutsideUSA);

            Product product5 = new Product("Nike Air Force 1's", "5874985", 100.99m, 1);
            Product product6 = new Product("Nike Sweatband", "5214639", 12.99m, 6);

            orderOutsideUSA.AddProduct(product5);
            orderOutsideUSA.AddProduct(product6);

            Console.WriteLine("\nOrder outside USA:");
            Console.WriteLine($"Packing Label:\n{orderOutsideUSA.GetPackingLabel()}");
            Console.WriteLine($"Shipping Label:\n{orderOutsideUSA.GetShippingLabel()}");
            Console.WriteLine($"Total Price: ${orderOutsideUSA.CalculateTotalCost()}");

            
            Console.ReadLine();
        }
    }
}