namespace GroceryCo.Discounts
{
    /// <summary>
    ///     This class calculates the price for promotion with percentage discount
    /// </summary>
    public class PercentageDiscount : IDiscount
    {
        private readonly int discountedQuantity;
        private readonly decimal productPrice;
        private readonly decimal promotionPercentage;
        private readonly int promotionQuantity;

        public PercentageDiscount(int quantity, int discountedQuantity, decimal productPrice,
            decimal promotionPercentage)
        {
            promotionQuantity = quantity;
            this.productPrice = productPrice;
            this.promotionPercentage = promotionPercentage;
            this.discountedQuantity = discountedQuantity;
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

                //quantity to apply the discount
                var quantityToApplyDiscount = 0;

                while (quantity >= promotionQuantity)
                {
                    quantityToApplyFullPrice += promotionQuantity;
                    quantity -= promotionQuantity;

                    if (quantity >= discountedQuantity)
                    {
                        quantityToApplyDiscount += discountedQuantity;
                        quantity -= discountedQuantity;
                    }
                    else
                    {
                        quantityToApplyDiscount += quantity;
                        quantity -= quantity;
                    }
                }

                //if the quantity is less than 0 then reset it to zero
                if (quantity < 0) quantity = 0;


                return (quantityToApplyFullPrice + quantity)*productPrice +
                       quantityToApplyDiscount*promotionPercentage*productPrice;
            }

            return 0;
        }
    }
}