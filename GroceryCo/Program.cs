using System;
using GroceryCo.Models;
using GroceryCo.Parser;

namespace GroceryCo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //get the products and promotions
                var products = new Products(Environment.CurrentDirectory + @"\Data\Products.txt");
                var promotions = new Promotions(products, Environment.CurrentDirectory + @"\Data\Promotions.txt");

                //load the sample file
                var items = new TextParser(Environment.CurrentDirectory + @"\Samples\sample.txt").GetData();


                var checkout = new Checkout(products, promotions);
                foreach (var id in items)
                    checkout.Add(id[0]);

                checkout.Calculate();

                //run the printer
                new Printer.Printer(checkout).Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }
    }
}