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
            
            DB.AddParameter("@StockID", StockID);

            DB.Execute("sproc_tblStockTable_FilterByStockID");

            if (DB.Count == 1)
            {
                mStockID = Convert.ToInt32(DB.DataTable.Rows[0]["StockID"]);
                mStockAvailability = Convert.ToBoolean(DB.DataTable.Rows[0]["StockAvailability"]);
                mDateArrived = Convert.ToDateTime(DB.DataTable.Rows[0]["DateArrived"]);
                mStockDescription = Convert.ToString(DB.DataTable.Rows[0]["StockDescription"]);
                mStockSupplier = Convert.ToString(DB.DataTable.Rows[0]["StockSupplier"]);
                mSupplierAddress = Convert.ToString(DB.DataTable.Rows[0]["SupplierAddress"]);
                
                
                

                return true;

            }

            else
            {
                return false;
            }    


                
         
            }

        public string Valid(string supplierAddress, string stockDescription, string stockSupplier, string dateArrived)
        {


            string Error = "";

            DateTime DateTemp;

            //if address left blank
            if (supplierAddress.Length == 0)
            {

                Error = Error + "The address may not be blank : ";


            } 
                
            //address greateer than 6 char
            if (supplierAddress.Length > 50)
            {

                Error = Error + "The address must be less than 50 characters : ";


            }

            //copy dateadded value to DateTemp variable


            try
            {

                DateTemp = Convert.ToDateTime(DateArrived);

                if (DateTemp < DateTime.Now.Date)
                {

                    Error = Error + "The date cannot be in the past : ";

                }

                if (DateTemp > DateTime.Now.Date)
                {

                    Error = Error + "The date cannot be in the future : ";

                }
            }

            catch
            {
                Error = Error + "The date was not a valid date : ";
            }

            if (stockSupplier.Length == 0)
            {

                Error = Error + "The supplier may not be blank : ";

            }

            if (stockSupplier.Length > 50)
            {

                Error = Error + "The supplier must be less than 50 characters : ";

            }    


            return Error;
        

        }
    }








}