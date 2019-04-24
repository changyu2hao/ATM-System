using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class main : System.Web.UI.Page
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
                drpCustomerActivities.Items.Add(item);
            }
        }
    }
    protected void drpCustomer_selectedIndexChanged(object sender, EventArgs e)
    {
        if (drpCustomerActivities.SelectedIndex > 0)
        {
            List<Customer> customers = Session["customers"] as List<Customer>;
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }
            Customer customer = customers[drpCustomerActivities.SelectedIndex - 1];
            foreach (Transaction transelement1 in customer.Checking.TransactionHistory)
            {
                TableRow rowNew = new TableRow();

                TableCell cellNew = new TableCell();
                cellNew.Text = transelement1.TransactionDate.ToString();
                rowNew.Cells.Add(cellNew);

                cellNew = new TableCell();
                cellNew.Text = transelement1.Amount.ToString();
                rowNew.Cells.Add(cellNew);

                cellNew = new TableCell();
                cellNew.Text = transelement1.Type.ToString();
                rowNew.Cells.Add(cellNew);

                tblActivitiesChecking.Rows.Add(rowNew);
            }
            foreach (Transaction transelement2 in customer.Saving.TransactionHistory)
            {
                TableRow rowNew = new TableRow();

                TableCell cellNew = new TableCell();
                cellNew.Text = transelement2.TransactionDate.ToString();
                rowNew.Cells.Add(cellNew);

                cellNew = new TableCell();
                cellNew.Text = transelement2.Amount.ToString();
                rowNew.Cells.Add(cellNew);

                cellNew = new TableCell();
                cellNew.Text = transelement2.Type.ToString();
                rowNew.Cells.Add(cellNew);

                tblActivitiesSaving.Rows.Add(rowNew);
            }
        }
    }
}