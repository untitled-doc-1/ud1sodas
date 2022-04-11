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
        public int mID;
        private string mDescription;
        private int mTotalItems;
        private decimal mTotalCost;
        private bool mFulfillment_status = false;
        private DateTime mDatePlaced;

        public clsOrder()
        {

        }

        public int ID
        {
            get
            {
                return mID;
            }
            set
            {
                mID = value;
            }
        }

        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
            }
        }

        public decimal TotalCost
        {
            get
            {
                return mTotalCost;
            }
            set
            {
                mTotalCost = value;
            }
        }



        public int TotalItems
        {
            get
            {
                return mTotalItems;
            }
            set
            {
                mTotalItems = value;
            }
        }



        public DateTime DatePlaced
        {
            get
            {
                return mDatePlaced;
            }
            set
            {
                mDatePlaced = value;
            }
        }


        public bool Fulfillment_status
        {
            get
            {
                return mFulfillment_status;
            }
            set
            {
                mFulfillment_status = value;
            }

        }

        /*
        var server = "v00egd00001l.lec-admin.dmu.ac.uk";
        string db = "p2612742";
        string user = "p2612742";
        string pass = "Untitled5";
        */

    }
}