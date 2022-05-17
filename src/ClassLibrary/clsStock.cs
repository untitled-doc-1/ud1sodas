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


        private string mStockSupplier;
        public string StockSupplier
        {
            get
            {

                return mStockSupplier;

            }

            set

            {
                mStockSupplier = value;

            }
        }

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

            clsDataConnection DB = new clsDataConnection();
            
            DB.AddParameter("@StockID"), StockID);

            DB.Execute("sproc_StockTable_FilterByStockID");

            if (DB.Count == 1)
            {
                mStockID = Convert.ToInt32(DB.DataTable.Rows[0]["StockID"]);
                mSupplierAddress = Convert.ToString(DB.DataTable.Rows[0]["SupplierAddress"]);
                mStockSupplier = Convert.ToString(DB.DataTable.Rows[0]["StockSupplier"]);
                mDateArrived = Convert.ToDateTime(DB.DataTable.Rows[0]["DateArrived"]);
                mStockAvailability = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]);
                mStockDescription = Convert.ToString(DB.DataTable.Rows[0]["StockDescription"]);

                return true;

            }

            else
            {
                return false;
            }    


                
         
            }


        
        
    }
}