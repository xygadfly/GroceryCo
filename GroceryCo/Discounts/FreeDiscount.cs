namespace GroceryCo.Discounts
{
    /// <summary>
    ///     This class calculates the price for promotion with free items
    /// </summary>
    public class FreeDiscount : IDiscount
    {
        private readonly int freeQuantity;
        private string id;
        private readonly decimal price;
        private readonly int promotionQuantity;

        public FreeDiscount(int quantity, int freeQty, decimal productPrice)
        {
            promotionQuantity = quantity;
            price = productPrice;
            freeQuantity = freeQty;
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