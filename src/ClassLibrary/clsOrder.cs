using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsOrder
    {
#warning implement with class def for stock & inventory (Product Class)
        public clsOrder(int id, string desc, clsOrder[] prods)
        {
            Id = id;
            Description = desc;
            Products = prods;
        }

#warning implement with class def for stock & inventory (Product Class)
        private clsOrder[] Products;

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal TotalCost 
        {
            get
            {
                decimal itemTotals = 0M;
                try
                {
                    foreach (var item in this.Products)
                    {
                        itemTotals += item.TotalCost;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Setting default arbitrary value");
                    decimal num = 234.23M;
                    itemTotals = num;
                }
                

                return itemTotals;
            }
        }
    }
}