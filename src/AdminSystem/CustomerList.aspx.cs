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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["Id"] = -1;
        Response.Redirect("CustomerDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (lstCustomerList.SelectedIndex != -1)
        {
            var customerId = Convert.ToInt32(lstCustomerList.SelectedValue);
            Session["customerId"] = customerId;
            Response.Redirect("CustomerDataEntry.aspx");
        }
        else
        {
            lblError.Text = "Please select a record to edit from the list";
        }
    }
}