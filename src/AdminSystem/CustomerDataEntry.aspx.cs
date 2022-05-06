using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    private int _customerId;

    protected void Page_Load(object sender, EventArgs e)
    {
        _customerId = Convert.ToInt32(Session["customerId"]);
        if (!IsPostBack)
        {
            if (_customerId != -1)
            {
                DisplayCustomer();
            }
        }
    }

    private void DisplayCustomer()
    {
        var customerCollection = new clsCustomerCollection();

        customerCollection.ThisCustomer.Find(_customerId);
        textCustomerName.Text = customerCollection.ThisCustomer.FullName;
        textEmail.Text = customerCollection.ThisCustomer.Email;
        textAddressLine1.Text = customerCollection.ThisCustomer.AddressLine1;
        textPassword.Text = customerCollection.ThisCustomer.PasswordHash;
        textPhoneNumer.Text = customerCollection.ThisCustomer.PhoneNumber;
        chkActive.Checked = customerCollection.ThisCustomer.Disabled;
        Calendar1.SelectedDate = customerCollection.ThisCustomer.SignedUpDate;
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
            var customerCollection = new clsCustomerCollection();
            customer.Id = _customerId;
            customer.AddressLine1 = addressLine1;
            customer.Disabled = disabled;
            customer.Email = customerEmail;
            customer.FullName = customerName;
            customer.PasswordHash = password;
            customer.PhoneNumber = phoneNumber;
            customer.SignedUpDate = selectedDate;

            if (_customerId == -1 || _customerId == 0)
            {
                customerCollection.ThisCustomer = customer;
                customerCollection.Add();
            }
            else
            {
                customerCollection.ThisCustomer.Find(_customerId);
                customerCollection.ThisCustomer = customer;
                customerCollection.Update();
            }
            // navigate to list page
            Response.Redirect("CustomerList.aspx");
        }
        else
        {
            lblError.Text = errorMessage;
        }
    }
}