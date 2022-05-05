using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayCustomers();
        }
    }

    void DisplayCustomers()
    {
        var customerCollection = new clsCustomerCollection();
        lstCustomerList.DataSource = customerCollection.CustomerList;
        lstCustomerList.DataValueField = "Id";
        lstCustomerList.DataTextField = "FullName";
        lstCustomerList.DataBind();
    }
}