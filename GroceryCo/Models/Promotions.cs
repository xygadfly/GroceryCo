using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCo.Discounts;
using GroceryCo.Parser;

namespace GroceryCo.Models
{
    /// <summary>
    /// Contains the list of promotions
    /// </summary>
    public class Promotions
    {
        private readonly List<Promotion> promotions;

        /// <summary>
        /// Load the currnet promotions
        /// </summary>
        /// <param name="path">location of the file</param>
        public Promotions(Products products, string path)
        {
            //load the lines from the text file
            var lines = new TextParser(path).GetData();

            promotions = new List<Promotion>();

            //process each of the lines 
            foreach (var item in lines)

                if (item[2] == "free")
                    //if the price set in the price column is 'free' then this is a free promotion
                    promotions.Add(new Promotion
                    {
                        Id = item[0],
                        Quantity = Convert.ToInt32(item[1]),
                        Get = Convert.ToInt32(item[3]),
                        Discount = new FreeDiscount(Convert.ToInt32(item[1]), Convert.ToInt32(item[3]), products.GetPrice(item[0]))
                    });
                else if (item[2] == "%")
                    //if the price set in the price column is '%' then this is a percentage promotion
                    promotions.Add(new Promotion
                    {
                        Id = item[0],
                        Quantity = Convert.ToInt32(item[1]),
                        Get = Convert.ToInt32(item[3]),
                        Percentage = Convert.ToDecimal(item[4])/100,
                        Discount = new PercentageDiscount(Convert.ToInt32(item[1]), Convert.ToInt32(item[3]), products.GetPrice(item[0]), Convert.ToDecimal(item[4]) / 100)
                    });
                else
                    //all other discount will fall in sale price promotion
                    promotions.Add(new Promotion
                    {
                        Id = item[0],
                        Quantity = Convert.ToInt32(item[1]),
                        Price = Convert.ToDecimal(item[2]),
                        Discount = new SalePrice(Convert.ToInt32(item[1]), Convert.ToDecimal(item[2]), products.GetPrice(item[0]))
                    });
        }

        /// <summary>
        /// Get the current promotion by product id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>current promotion</returns>
        public Promotion GetById(string id)
        {
            return promotions.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}