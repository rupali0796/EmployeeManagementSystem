<%@ Page Title="Show Employee Record" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowEmployeeRecord.aspx.cs" Inherits="UserManagementSystem.ShowEmployeeRecord" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12 grvEmployee">
        <asp:GridView ID="grvEmployee" runat="server" AllowPaging="true" EnableModelValidation="True"
            GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
            AutoGenerateColumns="false" Width="1098px" HeaderStyle-ForeColor="blue" OnPageIndexChanging="grvEmployee_PageIndexChanging"
             OnRowDeleting="grvEmployee_RowDeleting" OnRowEditing="grvEmployee_RowEditing" Height="417px">

            <HeaderStyle CssClass="DataGridFixedHeader" />
            <RowStyle CssClass="grid_item" />
            <AlternatingRowStyle CssClass="grid_alternate" />
            <FooterStyle CssClass="DataGridFixedHeader" />
            <Columns>
                <asp:TemplateField HeaderText="EmpId">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblEmpId" Text='<%#Eval("Reg_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblName" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FatherName">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblFatherName" Text='<%#Eval("FatherName") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblAge" Text='<%#Eval("Age") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblEmail" Text='<%#Eval("Email") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblAddress" Text='<%#Eval("Address") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="PinCode">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblPinCode" Text='<%#Eval("PinCode") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Update">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" ToolTip="Click here to Edit the record" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are You Sure You want to Delete the Record?');" ToolTip="Click here to Delete the record" />
                        </span>  
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Label runat="server" ID="lblMessage" ></asp:Label>
    </div>
</asp:Content>
