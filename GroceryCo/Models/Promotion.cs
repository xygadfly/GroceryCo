using GroceryCo.Discounts;

namespace GroceryCo.Models
{
    /// <summary>
    ///     Promotion model
    /// </summary>
    public class Promotion
    {
        public string Id { get; set; }

        public IDiscount Discount { get; set; }

        public string Title { get; set; }
    }
}