using System;
using System.Collections.Generic;
using System.Linq;

namespace Foundation2
{
    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalProductPrice = products.Sum(product => product.GetTotalPrice());
            decimal shippingCost = customer.IsInUSA() ? 5 : 35;
            return totalProductPrice + shippingCost;
        }

        public string GetPackingLabel()
        {
            return string.Join("\n", products.Select(product => $"{product.Name} - {product.ProductId}"));
        }

        public string GetShippingLabel()
        {
            return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
        }
    }
}