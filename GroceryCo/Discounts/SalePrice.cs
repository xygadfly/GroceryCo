using System;

namespace GroceryCo.Discounts
{
    /// <summary>
    ///     This class calculates the price for sale prices
    /// </summary>
    public class SalePrice : IDiscount
    {
        private readonly decimal productPrice;
        private readonly decimal promotionPrice;
        private readonly int promotionQuantity;

        /// <summary>
        ///     Create Sale Price Discount
        /// </summary>
        /// <param name="promotionQuantity">quantity that will qualify for the discount</param>
        /// <param name="promotionPrice">the discounted price of the product</param>
        /// <param name="productPrice">original product price</param>
        public SalePrice(int promotionQuantity, decimal promotionPrice, decimal productPrice)
        {
            this.promotionQuantity = promotionQuantity;
            this.promotionPrice = promotionPrice;
            this.productPrice = productPrice;
        }

        /// <summary>
        ///     Calculates the promotional price
        /// </summary>
        /// <param name="quantity">Quantity of items</param>
        /// <returns>Promotional Price Amount</returns>
        public decimal Calculate(int quantity)
        {
            return Convert.ToInt32(quantity/promotionQuantity)*promotionPrice +
                   quantity%promotionQuantity*productPrice;
        }
    }
}