using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {

        clsStock AStock = new clsStock
        {



            //convert stock id integer to text data type
            StockID = Convert.ToInt32(txtStockID.Text)
        };

        


        //store the StockID in the session object

        Session["AStock"] = AStock;

        //navigate to the viewer page
        Response.Redirect("StockViewer.aspx");


    }







    protected void btnFind_Click(object sender, EventArgs e)
    {

        clsStock AStock = new clsStock();

        Int32 StockID;

        Boolean Found = false;

        StockID = Convert.ToInt32(txtStockID.Text);

        Found = AStock.Find(StockID);

        if (Found == true)
        {

            txtDateArrived.Text = AStock.DateArrived.ToString();
            txtSupplierAddress.Text = AStock.SupplierAddress;
            txtStockSupplier.Text = AStock.StockSupplier;
            txtStockDescription.Text = AStock.StockDescription;
            StockAvailability.Text = AStock.StockAvailability.ToString();



        }








    }

    protected void txtStockID_TextChanged(object sender, EventArgs e)
    {

    }
}