using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace GroceryCo.Models
{
    /// <summary>
    ///     Checkout process
    /// </summary>
    public class Checkout
    {
        private readonly List<Item> cartItems;
        private readonly Products products;
        private readonly Promotions promotions;

        public decimal SubTotal { get; set; }
        public string TaxLabel { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal Total { get; set; }

        /// <summary>
        ///     Initialize the checkout process
        /// </summary>
        /// <param name="prod">list of products</param>
        /// <param name="promo">list of promotions</param>
        public Checkout(Products prod, Promotions promo)
        {
            promotions = promo;
            products = prod;
            cartItems = new List<Item>();
        }

        public List<Item> Items
        {
            get { return cartItems; }
        }

        /// <summary>
        ///     Add a product to the cart
        /// </summary>
        /// <param name="id">product id</param>
        public void Add(string id)
        {
            try
            {
                //check if the product is already in the cart
                var cartItem = cartItems.Where(c => c.Id == id).SingleOrDefault();

                if (cartItem != null)
                {
                    //if the product is already in the cart then just incremement the quanity
                    cartItem.Quantity++;
                }
                else
                {
                    //if the product is not yet in the cart then create a new item for that product in the cart

                    //get the product and promotion of the current product id
                    var product = products.GetById(id);
                    var promotion = promotions.GetById(id);

                    //create the new cart item and include the promotion if there's any
                    cartItems.Add(new Item(product.Id, product.Price, promotion));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// do the final calculation
        /// </summary>
        public void Calculate()
        {
            SubTotal = cartItems.Select(c => c.Subtotal).Sum();

            var taxPercentage = 0m;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TAX_PERCENTAGE"]))
                taxPercentage = Convert.ToDecimal(ConfigurationManager.AppSettings["TAX_PERCENTAGE"])/100;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TAX_LABEL"]))
                TaxLabel = ConfigurationManager.AppSettings["TAX_LABEL"];

            TaxTotal = SubTotal*taxPercentage;
            Total = TaxTotal + SubTotal;
        }
    }
}