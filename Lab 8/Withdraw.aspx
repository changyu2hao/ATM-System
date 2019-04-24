<%@ Page Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Withdraw.aspx.cs" Inherits="Withdraw" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <h1>Withdraw Fund</h1>
    <br />
    <div  class="row vertical-margin form-group">
        <div class="col-md-4 col-md-offset-1">
            <label for="txtCustomerNameWithdraw" id="lblCustomerNameWithdraw">Customer Name: </label>
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="drpCustomerWithdraw" CssClass="form-control" OnSelectedIndexChanged="drpCustomer_selectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="select Customer ..." Value="0" />
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDropCustomerWithdraw" runat="server" ControlToValidate="drpCustomerWithdraw" InitialValue="0" CssClass="error" Display="Static" ErrorMessage="Required!"></asp:RequiredFieldValidator>
        </div>
    </div>
        <br />
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <label for="txtCheckingAccountBalance" id="lblCheckingAccountBalance">Checking Account Balance: </label>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblChecking" runat="server" ></asp:Label>
            </div>
        </div>
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <label for="txtSavingAccountBalance" id="lblSavingAccountBalance">Saving Account Balance: </label>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblSaving" runat="server"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" TextAlign="Right" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Value="CheckingAccount" Selected="True">From Checking Account</asp:ListItem>
                    <asp:ListItem Value="SavingAccount">From Saving Account</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <br />
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <label for="txtWithdrawAmount" id="lblWithdrawAmount">Withdraw Amount: </label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtWithdrawAmount" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorWithdraw" runat="server" CssClass="error" ControlToValidate="txtWithdrawAmount" ErrorMessage="Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareWithdraw" runat="server" ErrorMessage="At least one dollar and no more than the account balance!" Operator="GreaterThan" ValueToCompare="0" ControlToValidate="txtWithdrawAmount" Display="Dynamic" CssClass="error" Type="Double"></asp:CompareValidator>
            </div>       
        </div>
        <br />
        <div class="col-md-4 col-md-offset-1">
            <asp:Button ID="btnWithdraw" runat="server" Text="Withdraw" OnClick="btnWithdraw_click" CssClass="button" />
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblcomformation" runat="server" CssClass="distinct"></asp:Label>
        </div>
</asp:Content>

