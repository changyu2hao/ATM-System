<%@ Page Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Deposit.aspx.cs" Inherits="Deposit" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <h1>Deposit Fund</h1>
    <br />
    <div  class="row vertical-margin form-group">
        <div class="col-md-4 col-md-offset-1">
            <label for="txtCustomerNameDeposit" id="lblCustomerNameDeposit">Customer Name: </label>
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="drpCustomerDeposit" CssClass="form-control" OnSelectedIndexChanged="drpCustomer_selectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="select Customer ..." Value="0" />
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDropCustomerDeposit" runat="server" ControlToValidate="drpCustomerDeposit" InitialValue="0" CssClass="error" Display="Static" ErrorMessage="Required!"></asp:RequiredFieldValidator>
        </div>
     </div>
        <br />
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <label for="txtCheckingAccountBalance" id="lblCheckingAccountBalance">Checking Account Balance: </label>
            </div>
            <div class="col-md-4">
                <asp:Label ID="txtCheckingAccountBalance" runat="server" ></asp:Label>
            </div>
        </div>
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <label for="txtSavingAccountBalance" id="lblSavingAccountBalance">Checking Account Balance: </label>
            </div>
            <div class="col-md-4">
                <asp:Label ID="txtSavingAccountBalance" runat="server"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" TextAlign="Right" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Value="CheckingAccount" Selected="True">To Checking Account</asp:ListItem>
                    <asp:ListItem Value="SavingAccount">To Saving Account</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <br />
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <label for="txtDepositAmount" id="lblDepositAmount">Deposit Amount: </label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtDepositAmount" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDeposit" runat="server" CssClass="error" ControlToValidate="txtDepositAmount" ErrorMessage="Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareDeposit" runat="server" ErrorMessage="Must be greater than 0!" Operator="GreaterThan" ValueToCompare="0" ControlToValidate="txtDepositAmount" Display="Dynamic" CssClass="error" Type="Double"></asp:CompareValidator>
            </div>       
        </div>
        <br />
        <div class="col-md-4 col-md-offset-1">
            <asp:Button ID="btnDeposit" runat="server" Text="Deposit" OnClick="btnDeposit_click" CssClass="button" />
        </div> 
        <div class="col-md-4">
            <asp:Label ID="lblcomformation" runat="server" CssClass="distinct"></asp:Label>
        </div>
</asp:Content>