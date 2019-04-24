<%@ Page Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="FundTransfer.aspx.cs" Inherits="FundTransfer" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <h1>Transfer Fund</h1>
    <br />
    <div  class="row vertical-margin form-group">
        <div class="col-md-4 col-md-offset-1">
            <label for="txtCustomerNameTransfer" id="lblCustomerNameTransfer">Customer Name: </label>
        </div>
        <div class="col-md-4">
            <asp:DropDownList runat="server" ID="drpCustomerTransfer" CssClass="form-control" OnSelectedIndexChanged="drpCustomer_selectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="select Customer ..." Value="0" />
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDropCustomerTransfer" runat="server" ControlToValidate="drpCustomerTransfer" InitialValue="0" CssClass="error" Display="Static" ErrorMessage="Required!"></asp:RequiredFieldValidator>
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
                <label for="txtTransferAmount" id="lblTransferAmount">Transfer Amount: </label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtTransferAmount" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDeposit" runat="server" CssClass="error" ControlToValidate="txtTransferAmount" ErrorMessage="Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareTransfer" runat="server" ErrorMessage="Must be greater than 0!" Operator="GreaterThan" ValueToCompare="0" ControlToValidate="txtTransferAmount" Display="Dynamic" CssClass="error" Type="Double"></asp:CompareValidator>
            </div>       
        </div>
        <br />
        <div class="col-md-4 col-md-offset-1">
            <asp:Button ID="btnWTransfer" runat="server" Text="Transfer" OnClick="btnTransfer_click" CssClass="button" />
        </div> 
        <div class="col-md-4">
            <asp:Label ID="lblcomformation" runat="server" CssClass="distinct"></asp:Label>
        </div>
</asp:Content>
