using System;

namespace ClassLibrary
{
    public class clsStock
    {
        
        public clsStock()
        {
        }

        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }

        public DateTime DateArrived { get; set; }

        public Boolean StockAvailability { get; set; }

        public string StockDescription { get; set; }

        public string StockSupplier { get; set; }

        

        public string SupplierAddress { get; set; }


        private Int32 mStockID;

        public Int32 StockID
        {
            get
            {
                //sends data out of property
                return mStockID;
            }
            set
            {
                //allows data into property
                mStockID = value;
            }
        }


        public bool Find(int StockID)
            {
                mStockID = 21;

                return true;
            }


        
        
    }
}