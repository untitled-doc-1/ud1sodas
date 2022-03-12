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
        public static int IDCounter;

        public readonly int ID;

#warning implement with class def for stock & inventory (Product Class)
        private clsOrder[] Products;
        
        public readonly string Description;

        private readonly int _totalItems;

        private bool _fulfillment_status = false;

        private readonly DateTime _datePlaced;



#warning implement with class def for stock & inventory (Product Class)
        public clsOrder(string desc, clsOrder[] prods)
        {
            ID = IDCounter;
            Description = desc;
            Products = prods;
            _totalItems = prods.Length;
            _datePlaced = DateTime.Now;
            IDCounter++;
        }

        public int GetID()
        {
            return ID;
        }

        public string GetDescription()
        {
            return Description;
        }

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



        public int GetTotalItems()
        {
            return _totalItems;
        }

        

        public DateTime GetDatePlaced()
        {
            return _datePlaced;
        }


        public bool GetFulfillment_status()
        {
            return _fulfillment_status;
        }

        public void CompleteOrder()
        {
            /*
            foreach (Product prod in this.Products)
            {
                if (prod.IsInStock == true)
                {
                    if (prod.Quantity <= Stock[prod.ProductID])
                    {
                        Stock[prod.ProductID] = -prod.Quantity;
                        _fulfillment_status = true;
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    _fulfillment_status = false;
                }
            }

            */

            _fulfillment_status = true;

        }

        public void DeleteOrder(int ID)
        {
            var server = "v00egd00001l.lec-admin.dmu.ac.uk";
            string db = "p2612742";
            string user = "p2612742";
            string pass = "Untitled5";

            string connectionString = "Data Source=" + server + "; Initial Catalog = " + db + "; User ID = " + user + "; Password = " + pass;


            System.Data.SqlClient.SqlConnection SQLC = new System.Data.SqlClient.SqlConnection(connectionString);
        }
    }
}