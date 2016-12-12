﻿using System;

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

        public SalePrice(int quantity, decimal promotionPrice, decimal productPrice)
        {
            promotionQuantity = quantity;
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