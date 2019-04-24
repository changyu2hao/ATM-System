using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Customer> customers = Session["customers"] as List<Customer>;
        if(customers == null)
        {
            customers = new List<Customer>();
            Session["customers"] = customers;
        }
        ShowCustomersInfo(customers);
    }

    protected void btnAddCustomer_click(object sender, EventArgs e)
    {
        List<Customer> customers = Session["customers"] as List<Customer>;
        if(customers==null)
        {
            customers = new List<Customer>();
            Session["customers"] = customers;
        }
        Customer customer = new Customer(txtCustomernName.Text);

        customer.Saving = new SavingAccount(customer, double.Parse(txtInitialDeposit.Text));
        customer.Checking = new CheckingAccount(customer);
        customers.Add(customer);
        ShowCustomersInfo(customers);       
    }
    private void ShowCustomersInfo(List<Customer> customers)
    {
        //remove existing courses displayed in the table
        for (int i = tblAdd.Rows.Count - 1; i > 0; i--)
        {
            tblAdd.Rows.RemoveAt(i);
        }
        if (customers.Count==0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "No customer in the system yet";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 4;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblAdd.Rows.Add(lastRow);
        }
        else
        {
            foreach (Customer customer in customers)
            {
                TableRow rowNew = new TableRow();

                TableCell cellNew = new TableCell();
                cellNew.Text = customer.Name;
                rowNew.Cells.Add(cellNew);

                cellNew = new TableCell();
                cellNew.Text = customer.Checking.Balance.ToString();
                rowNew.Cells.Add(cellNew);

                cellNew = new TableCell();
                cellNew.Text = customer.Saving.Balance.ToString();
                rowNew.Cells.Add(cellNew);

                cellNew = new TableCell();
                cellNew.Text = customer.Status.ToString();
                rowNew.Cells.Add(cellNew);

                tblAdd.Rows.Add(rowNew);
            }
        }      
    }

    protected void btnAbandonCustomer_click(object sender, EventArgs e)
    {
        Session.Abandon();

        ShowCustomersInfo(new List<Customer>());

    }
}