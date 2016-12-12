namespace GroceryCo.Models
{
    /// <summary>
    /// Cart Item Model
    /// </summary>
    public class Item : Product
    {
        private readonly Promotion promotion;

        /// <summary>
        /// Create a new cart item
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="price">price</param>
        /// <param name="promo">current promotion</param>
        public Item(string id, decimal price, Promotion promo) : base(id, price)
        {            
            promotion = promo;

            //set the quantity to 1 when newly created
            Quantity = 1;
        }

        public int Quantity { get; set; }
        public decimal? PromotionalPrice { get; set; }
        public string PromotionLabel { get; set; }

        /// <summary>
        /// Calculate the Sub-total
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                //check if there's any promotion
                if (promotion != null)
                {
                    //calculated the promotional price
                    var discountedPrice = promotion.Discount.Calculate(Quantity);

                    //if the calculated price is 0 then promotion wasn't applicable 
                    if (discountedPrice > 0)
                    {
                        PromotionalPrice = discountedPrice/Quantity;
                        PromotionLabel = promotion.Title;

                        return discountedPrice;
                    }
                }
                    
                return Quantity*Price;
            }
        }

    }
}