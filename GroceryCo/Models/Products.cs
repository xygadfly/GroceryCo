﻿using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCo.Parser;

namespace GroceryCo.Models
{
    /// <summary>
    ///     Contains the list of products
    /// </summary>
    public class Products
    {
        private readonly List<Product> products;

        /// <summary>
        ///     Load the products
        /// </summary>
        /// <param name="path">File path of the file</param>
        public Products(string path)
        {
            try
            {
                //load the lines from the text file
                var lines = new TextParser(path).GetData();

                products = new List<Product>();

                //process each of the lines
                foreach (var item in lines)
                    products.Add(new Product(item[0], Convert.ToDecimal(item[1])));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in Products:Constructor:{0}", ex.Message));
            }
        }

        /// <summary>
        ///     Get the current promotion by id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns></returns>
        public Product GetById(string id)
        {
            var product = products.Where(c => c.Id == id).SingleOrDefault();
            if (product != null) return product;
            throw new Exception(string.Format("{0} not found in the list of products", id));
        }

        public decimal GetPrice(string id)
        {
            var product = GetById(id);
            return product.Price;
        }
    }
}