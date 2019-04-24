<%@ Page Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="CustomerManagement.aspx.cs" Inherits="CustomerManagement" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <h1>Customer Management</h1>
 <div class="row vertical-margin form-group">
    <div class="col-md-3 col-md-offset-1">
        <label for="txtCustomerName" id="lblCustomerName">Customer Name: </label>
    </div>
    <div class="col-md-5">
        <asp:TextBox ID="txtCustomernName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="col-md-3">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomernName" CssClass="error" Display="Static" ErrorMessage="Required!"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="row vertical-margin form-group">
    <div class="col-md-3 col-md-offset-1">
        <label id="lblInitialDeposit" for="txtInitialDeposit">Initial Deposit: </label>
    </div>
    <div class="col-md-5">
        <asp:TextBox ID="txtInitialDeposit" runat="server" CssClass="form-control" ></asp:TextBox>
    </div>
    <div class="col-md-3">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtInitialDeposit" CssClass="error" Display="Dynamic" ErrorMessage="Required!"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Must be greater than 0!" Operator="GreaterThan" ValueToCompare="0" ControlToValidate="txtInitialDeposit" CssClass="error" Display="Dynamic" Type="Double"></asp:CompareValidator>
    </div>
    </div>
    <div class="col-md-4 col-md-offset-1">
        <asp:Button ID="btnAdd" runat="server" Text="Add Customer" OnClick="btnAddCustomer_click" CssClass="button"/>
    </div>
    <div class="col-md-4 col-md-offset-1">
        <asp:Button ID="Abandonsession" runat="server" Text="Clear all" OnClick="btnAbandonCustomer_click" CssClass="button" CausesValidation="false"/>
    </div>
    <br />
    <br />
    <p>The following customer are currently in the system:</p>
    <asp:Table ID="tblAdd" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Checking Account Balance</asp:TableHeaderCell>
                <asp:TableHeaderCell>Saving Account Balance</asp:TableHeaderCell>
                <asp:TableHeaderCell>Status</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
</asp:Content>

