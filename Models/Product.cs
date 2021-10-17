using System.Collections.Generic;

namespace FluentValidationExample.Models
{
    public class Product
    {
        public Product(IEnumerable<Item> products)
        {
            this.Products = products;
        }

        public IEnumerable<Item> Products { get; set; }
    }

    public class Item
    {
        public Item(int id, string name, string seller, string catRefId, decimal quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Seller = seller;
            this.CatRefId = catRefId;
            this.Quantity = quantity;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Seller { get; set; }
        public string CatRefId { get; set; }
        public decimal Quantity { get; set; }
    }
}