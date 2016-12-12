namespace GroceryCo.Discounts
{
    /// <summary>
    ///     This class calculates the price for promotion with free items
    /// </summary>
    public class FreeDiscount : IDiscount
    {
        private readonly int freeQuantity;
        private readonly decimal price;
        private readonly int promotionQuantity;

        /// <summary>
        ///     Create Free Discount Promotion
        /// </summary>
        /// <param name="promotionQuantity">quantity that will qualify for the discount</param>
        /// <param name="freeQuantity">quantity that will have the discount</param>
        /// <param name="price">product price</param>
        public FreeDiscount(int promotionQuantity, int freeQuantity, decimal price)
        {
            this.promotionQuantity = promotionQuantity;
            this.price = price;
            this.freeQuantity = freeQuantity;
        }

        /// <summary>
        ///     Calculates the promotional price
        /// </summary>
        /// <param name="quantity">Quantity of items</param>
        /// <returns>Promotional Price Amount</returns>
        public decimal Calculate(int quantity)
        {
            //we can only apply the promotion if the quantity is greater than or equal to the promotions quantity
            if (quantity >= promotionQuantity)
            {
                //quantity to apply the full price
                var quantityToApplyFullPrice = 0;

                //do this code current quantity is still greater than or equal to the promotional quantity
                while (quantity >= promotionQuantity)
                {
                    quantityToApplyFullPrice += promotionQuantity;
                    quantity -= freeQuantity + promotionQuantity;
                }

                //if the quantity is less than 0 then reset it to zero
                if (quantity < 0) quantity = 0;

                //to calculate the price add the quantity that will have full price and the remaining quantity multiply by the product price
                return (quantityToApplyFullPrice + quantity)*price;
            }

            return 0;
        }
    }
}