using System;
using System.IO;
using System.Text;
using GroceryCo.Models;

namespace GroceryCo.Printer
{
    /// <summary>
    ///     Print the receipt to a file
    /// </summary>
    public class Printer
    {
        private readonly Checkout checkout;
        private readonly StringBuilder sb;

        /// <summary>
        ///     initialize the printer
        /// </summary>
        /// <param name="checkout"></param>
        public Printer(Checkout checkout)
        {
            this.checkout = checkout;
            sb = new StringBuilder();
        }

        /// <summary>
        ///     Print the receipt
        /// </summary>
        public void Print()
        {
            //generate the filename
            var filePath = string.Format("{0}\\Receipt-{1}.txt", Environment.CurrentDirectory, Guid.NewGuid());

            //add the header
            PrintHeader();

            //print the items
            PrintBody(checkout);

            //print the total
            PrintTotal(checkout);

            //add the footer
            PrintFooter();

            //write the receipt to the file
            var sw = new StreamWriter(filePath);
            sw.Write(sb.ToString());
            sw.Close();
        }


        /// <summary>
        ///     Print the header
        /// </summary>
        private void PrintHeader()
        {
            sb.AppendLine("*************************************************");
            //add the date of the receipt
            sb.AppendFormat("Printed Date: {0}", DateTime.Now);
            sb.AppendLine();
            sb.AppendLine("*************************************************");
        }

        /// <summary>
        ///     print the footer
        /// </summary>
        private void PrintFooter()
        {
            sb.AppendLine("*************************************************");
        }

        /// <summary>
        /// Print the items
        /// </summary>
        /// <param name="checkout"></param>
        private void PrintBody(Checkout checkout)
        {
            //addd the header of items
            sb.AppendFormat("{0} - {1} - {2} - {3} - {4} - {5}",
                "ITEM",
                "QUANTITY",
                "ORIGINAL PRICE",
                "PROMOTIONAL PRICE",
                "SUBTOTAL",
                "PROMOTION");
            sb.AppendLine();

            //add the items
            foreach (var item in checkout.Items)
            {
                sb.AppendFormat("{0} - {1} - {2} - {3} - {4} - {5}",
                    item.Id,
                    item.Quantity,
                    item.Price.ToString("C"),
                    item.PromotionalPrice.HasValue ? item.PromotionalPrice.Value.ToString("C") : "",
                    item.Subtotal.ToString("C"),
                    item.PromotionalPrice.HasValue ? item.PromotionLabel : "");
                sb.AppendLine();
            }            
        }


        /// <summary>
        /// Print the sub-total, tax, total
        /// </summary>
        /// <param name="checkout"></param>
        private void PrintTotal(Checkout checkout)
        {
            sb.AppendLine("-------------------------------------------------");
            sb.AppendFormat("Subtotal: {0}", checkout.SubTotal.ToString("C"));
            sb.AppendLine();
            sb.AppendFormat("{0}: {1}", checkout.TaxLabel, checkout.TaxTotal.ToString("C"));
            sb.AppendLine();
            sb.AppendFormat("Total: {0}", checkout.Total.ToString("C"));
            sb.AppendLine();            
        }
    }
}