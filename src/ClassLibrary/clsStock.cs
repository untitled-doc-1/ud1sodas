using System;

namespace ClassLibrary
{
    public class clsStock
    {
        
        public clsStock()
        {
        }

        public bool Active { get; set; }
        private DateTime mDateAdded;
        public DateTime DateAdded
        {
            get

            {

                return mDateAdded;
            }
            set
            {
                mDateAdded = value;
            }
        }


        private DateTime mDateArrived;
        public DateTime DateArrived
        {
            get

            {
                return mDateArrived;
            }
            set
            {
                mDateArrived = value;
            }
        }       


        private Boolean mStockAvailability;
        public Boolean StockAvailability
        {
            get

            {
                return mStockAvailability;
            }
            set
            {
                mStockAvailability = value;
            }
        }





        private string mStockDescription;
        public string StockDescription
        {
            get

            {
                return mStockDescription;
            }
            set
            {
                mStockDescription = value;
            }
        }
                
              

        public string StockSupplier { get; set; }


        private string mSupplierAddress;
        public string SupplierAddress 
        { 
             get
            {
                return mSupplierAddress;
            }
            set
            {
                mSupplierAddress = value;
            }
        }

        //data members
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
                mDateArrived = Convert.ToDateTime("16/9/2015");
                mStockDescription = ("Test Description");
                mSupplierAddress = ("Test Address");
                mStockAvailability = (true);
                return true;
            }


        
        
    }
}