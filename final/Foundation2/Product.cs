using System;

namespace Foundation2
{
    public class Product
    {
        public string Name { get; }
        public string ProductId { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public Product(string name, string productId, decimal price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return Price * Quantity;
        }
    }
}
