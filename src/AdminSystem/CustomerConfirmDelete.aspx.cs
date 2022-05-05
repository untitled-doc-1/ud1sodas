using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    private int _customerId;
    protected void Page_Load(object sender, EventArgs e)
    {
        var customerIdString = Session["customerId"];
        _customerId = Convert.ToInt32(Session["customerId"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        var customerCollection = new clsCustomerCollection();
        customerCollection.ThisCustomer.Find(_customerId);
        var deleted = customerCollection.Delete();
        if (!deleted)
        {
            throw new ApplicationException("Delete failed.");
        }
        Response.Redirect("CustomerList.aspx");
    }


    protected void btnNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerList.aspx");
    }
}