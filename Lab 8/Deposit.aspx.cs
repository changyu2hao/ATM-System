using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Deposit : System.Web.UI.Page
{
    private object course;
    private string customer;

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            Page.Response.Redirect("CustomerManagement.aspx");
        }
        if(!IsPostBack)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                ListItem item = new ListItem(customers[i].Name);
                drpCustomerDeposit.Items.Add(item);
            }
        }        
    }
    protected void drpCustomer_selectedIndexChanged(object sender, EventArgs e)
    {
        txtCheckingAccountBalance.Text = "";
        txtSavingAccountBalance.Text = "";
        lblcomformation.Text = "";


        if (drpCustomerDeposit.SelectedIndex>0)
        {
            List<Customer> customers = Session["customers"] as List<Customer>;
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }
            Customer customer = customers[drpCustomerDeposit.SelectedIndex-1];
            txtCheckingAccountBalance.Text = customer.Checking.Balance.ToString();
            txtSavingAccountBalance.Text = customer.Saving.Balance.ToString();
        }       
    }

    protected void btnDeposit_click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            List<Customer> customers = Session["customers"] as List<Customer>;
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }
            Customer customer = customers[drpCustomerDeposit.SelectedIndex-1];
            Account account = null;
            double Transactionamount = double.Parse(txtDepositAmount.Text);
            Transaction transactionelement = new Transaction(Transactionamount, Enums.TransactionType.DEPOSIT);
            if (RadioButtonList1.SelectedValue == "CheckingAccount")
            {
                account = customer.Checking;
            }
            if (RadioButtonList1.SelectedValue == "SavingAccount")
            {
                account = customer.Saving;
            }
            Enums.TransactionResult result = account.transact(transactionelement);
            txtCheckingAccountBalance.Text = customer.Checking.Balance.ToString();
            txtSavingAccountBalance.Text = customer.Saving.Balance.ToString();
            lblcomformation.Text = "The transaction completed and the accont balance has been update ";
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}