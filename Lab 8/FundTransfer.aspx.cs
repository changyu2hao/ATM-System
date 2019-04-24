using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            Page.Response.Redirect("CustomerManagement.aspx");
        }
        if (!IsPostBack)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                ListItem item = new ListItem(customers[i].Name);
                drpCustomerTransfer.Items.Add(item);
            }
        }
    }

    protected void btnTransfer_click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            List<Customer> customers = Session["customers"] as List<Customer>;
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }
            Customer customer = customers[drpCustomerTransfer.SelectedIndex - 1];
            Account account1 = null;
            Account account2 = null;
            double Transactionamount = double.Parse(txtTransferAmount.Text);
            Transaction transactionelementout = new Transaction(Transactionamount, Enums.TransactionType.TRANSFER_OUT);
            Transaction transactionelementin = new Transaction(Transactionamount, Enums.TransactionType.TRANSFER_IN);
            if (RadioButtonList1.SelectedValue == "CheckingAccount")
            {
                account1 = customer.Checking;
                account2 = customer.Saving;               
            }
            if (RadioButtonList1.SelectedValue == "SavingAccount")
            {
                account1 = customer.Saving;
                account2 = customer.Checking;                
            }
            Enums.TransactionResult resultout = account1.transact(transactionelementout);
            if(resultout== Enums.TransactionResult.SUCCESS)
            {
                Enums.TransactionResult resultin = account2.transact(transactionelementin);
                lblChecking.Text = customer.Checking.Balance.ToString();
                lblSaving.Text = customer.Saving.Balance.ToString();
                lblcomformation.Text = "The transaction completed and the accont balance has been update ";
            }                      
            else if (resultout == Enums.TransactionResult.INSUFFIVIENT_FUND)
            {
                lblcomformation.Text = "The transaction failed:"+resultout.ToString();
            }
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void drpCustomer_selectedIndexChanged(object sender, EventArgs e)
    {
        lblChecking.Text = "";
        lblSaving.Text = "";
        lblcomformation.Text = "";

        if (drpCustomerTransfer.SelectedIndex > 0)
        {
            List<Customer> customers = Session["customers"] as List<Customer>;
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }
            Customer customer = customers[drpCustomerTransfer.SelectedIndex - 1];
            lblChecking.Text = customer.Checking.Balance.ToString();
            lblSaving.Text = customer.Saving.Balance.ToString();
        }
    }
}