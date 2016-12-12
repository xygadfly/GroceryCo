using GroceryCo.Discounts;

namespace GroceryCo.Models
{
    /// <summary>
    /// Promotion model
    /// </summary>
    public class Promotion
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Percentage { get; set; }
        public int? Get { get; set; }
        public IDiscount Discount { get; set; }


        /// <summary>
        /// returns the title of the discount
        /// </summary>
        public string Title
        {
            get
            {
                if (Percentage.HasValue)
                    return string.Format("Buy {0} get {1} for {2}", Quantity, Get, Percentage.Value.ToString("P"));
                if (Price.HasValue)
                    if (Quantity == 1) return string.Format("{0} Sale Price", Price.Value.ToString("C"));
                    else return string.Format("Buy {0} for {1}", Quantity, Price.Value.ToString("C"));
                return string.Format("Buy {0} get {1} for free", Quantity, Get);
            }
        }
    }
}