using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        //new instance of class
        clsStock AStock = new clsStock();
        //get data from session object
        AStock = (clsStock)Session["StockID"];
        //display stockid for this entry
        Response.Write(AStock.StockID);



    }
}