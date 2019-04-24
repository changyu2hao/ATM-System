<%@ Page Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Activity.aspx.cs" Inherits="main" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <h1>Account Activities</h1>
    <br />
    <div  class="row vertical-margin form-group">
        <div class="col-md-4 col-md-offset-1">
            <label for="txtCustomerNameActivities" id="lblCustomerNameActivities">Customer Name: </label>
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="drpCustomerActivities" CssClass="form-control" OnSelectedIndexChanged="drpCustomer_selectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="select Customer ..." Value="0" />
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDropCustomerActivities" runat="server" ControlToValidate="drpCustomerActivities" InitialValue="0" CssClass="error" Display="Static" ErrorMessage="Required!"></asp:RequiredFieldValidator>
        </div>
     </div>
    <p>Checking Account Activities:</p>
    <asp:Table ID="tblActivitiesChecking" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                <asp:TableHeaderCell>Transaction Type</asp:TableHeaderCell>
            </asp:TableRow>
    </asp:Table>
    <p>Saving Account Activities:</p>
    <asp:Table ID="tblActivitiesSaving" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                <asp:TableHeaderCell>Transaction Type</asp:TableHeaderCell>
            </asp:TableRow>
    </asp:Table>
</asp:Content>
