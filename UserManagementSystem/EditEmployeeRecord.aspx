<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployeeRecord.aspx.cs" Inherits="UserManagementSystem.EditEmployeeRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <div class="col-md-4 col-md-offset-4" style="padding: 25px 0">

            <asp:HiddenField ID="hdnfldEmployeeID" runat="server" />  
            
             <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            ForeColor="Blue" HeaderText="Page Errors"
            ShowSummary="true" DisplayMode="List" />

            <div class="form-group">
                <label for="email">Name:</label>
                <asp:TextBox class="form-control" ID="txtName" runat="Server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server"
                    ErrorMessage="Name is required" ForeColor="Red"
                    ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="email">Father's Name:</label>
                <asp:TextBox class="form-control" ID="txtFatherName" runat="Server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFatherName" runat="server"
                    ErrorMessage="FatherName is required" ForeColor="Red"
                    ControlToValidate="txtFatherName" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="email">Email address:</label>
                <asp:TextBox class="form-control" ID="txtEmail" runat="Server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                    ErrorMessage="Email is required" ForeColor="Red"
                    ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ErrorMessage="Invalid Email" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="email">Age</label>
                <asp:TextBox class="form-control" ID="txtAge" runat="Server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server"
                    ErrorMessage="Age is required" ForeColor="Red"
                    ControlToValidate="txtAge" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:RangeValidator ID="RangeValidator1" runat="server" ForeColor="Red"
                    ErrorMessage="Age must be in digits" MinimumValue="1" MaximumValue="100"
                    ControlToValidate="txtAge" Type="Integer"></asp:RangeValidator>
            </div>
            <div class="form-group">
                <label for="email">Address:</label>
                <asp:TextBox class="form-control" ID="txtAddress" runat="Server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server"
                    ErrorMessage="Address is required" ForeColor="Red"
                    ControlToValidate="txtAddress" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="pwd">Pincode:</label>
                <asp:TextBox class="form-control" ID="txtPinCode" runat="Server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPinCode" runat="server"
                    ErrorMessage="PinCode is required" ForeColor="Red"
                    ControlToValidate="txtPinCode" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <asp:Button runat="server" ID="btnSubmit" Text="Submit" type="Submit" class="btn btn-default" OnClick="btnSubmit_Click"></asp:Button>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
         </div>
        </div>
</asp:Content>
