using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Withdraw : System.Web.UI.Page
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
            for (int i = 0; i < customers.Count ; i++)
            {
                ListItem item = new ListItem(customers[i].Name);
                drpCustomerWithdraw.Items.Add(item);
            }
        }
    }
    protected void drpCustomer_selectedIndexChanged(object sender, EventArgs e)
    {
        lblChecking.Text = "";
        lblSaving.Text = "";
        lblcomformation.Text = "";

        if (drpCustomerWithdraw.SelectedIndex > 0)
        {
            List<Customer> customers = Session["customers"] as List<Customer>;
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }
            Customer customer = customers[drpCustomerWithdraw.SelectedIndex-1];
            lblChecking.Text = customer.Checking.Balance.ToString();
            lblSaving.Text = customer.Saving.Balance.ToString();
        }
    }
    protected void btnWithdraw_click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            List<Customer> customers = Session["customers"] as List<Customer>;
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }
            Customer customer = customers[drpCustomerWithdraw.SelectedIndex-1];
            Account account = null;
            double Transactionamount = double.Parse(txtWithdrawAmount.Text);
            Transaction transactionelement = new Transaction(Transactionamount, Enums.TransactionType.WITHDRAW);
            Transaction transactionelementdeduct = new Transaction(Transactionamount,10, Enums.TransactionType.PENALTY);
            if (RadioButtonList1.SelectedValue == "CheckingAccount")
            {
                account = customer.Checking;
            }
            if (RadioButtonList1.SelectedValue == "SavingAccount")
            {
                account = customer.Saving;               
            }                      
            Enums.TransactionResult result = account.transact(transactionelement);
            if(result== Enums.TransactionResult.SUCCESS)
            {
                if(RadioButtonList1.SelectedValue == "SavingAccount")
                {
                    account.transact(transactionelementdeduct);
                }
                lblChecking.Text = customer.Checking.Balance.ToString();
                lblSaving.Text = customer.Saving.Balance.ToString();
                lblcomformation.Text = "The transaction completed and the accont balance has been update ";
            }
            else
            {
                lblcomformation.Text = "The transaction failed:" + result.ToString();
            }
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}