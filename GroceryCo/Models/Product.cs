namespace GroceryCo.Models
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Create a new instance of product
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="price">price</param>
        public Product(string id, decimal price)
        {
            Id = id;
            Price = price;
        }
    }
}