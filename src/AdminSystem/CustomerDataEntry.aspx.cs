using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnFindCustomer_Click(object sender, EventArgs e)
    {
        var customer = new clsCustomer();
        var customerId = Convert.ToInt32(textCustomerId.Text);
        var customerFound = customer.Find(customerId);
        if (customerFound)
        {
            textCustomerName.Text = customer.FullName;
            textEmail.Text = customer.Email;
            textAddressLine1.Text = customer.AddressLine1;
            textPassword.Text = customer.PasswordHash;
            textPhoneNumer.Text = customer.PhoneNumber;
            chkActive.Checked = customer.Disabled;
            Calendar1.SelectedDate = customer.SignedUpDate;
        }

    }


    protected void btnOK_Click(object sender, EventArgs e)
    {
        var customer = new clsCustomer();
        var customerName = textCustomerName.Text;
        var customerEmail = textEmail.Text;
        var password = textPassword.Text;
        var addressLine1 = textAddressLine1.Text;
        var phoneNumber = textPhoneNumer.Text;
        var disabled = chkActive.Checked;
        var selectedDate = Calendar1.SelectedDate;


        var errorMessage = customer.Validate(customerName, customerEmail, password, addressLine1, phoneNumber, disabled, selectedDate);
        if (errorMessage == String.Empty)
        {
            customer.AddressLine1 = addressLine1;
            customer.Disabled = disabled;
            customer.Email = customerEmail;
            customer.FullName = customerName;
            customer.PasswordHash = password;
            customer.PhoneNumber = phoneNumber;
            customer.SignedUpDate = selectedDate;

            // set customer in session
            Session["ACustomer"] = customer;

            // navigate to viewer page
            Response.Redirect("CustomerViewer.aspx");
        }
        else
        {
            lblError.Text = errorMessage;
        }
    }
}