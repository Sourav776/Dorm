<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> user registration </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="First_TB" runat="server"></asp:TextBox>
            </div>
            <div>
            <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="Last_TB" runat="server"></asp:TextBox>
            </div>
            <div>
            <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
            <asp:TextBox ID="Email_TB" runat="server"></asp:TextBox>
            </div>
            <div>
            <asp:Label ID="Label4" runat="server" Text="Phone Number"></asp:Label>
            <asp:TextBox ID="Cell_TB" runat="server"></asp:TextBox>
            </div>
            <div>
            <asp:Label ID="Label5" runat="server" Text="Department/Institute"></asp:Label>
                <asp:DropDownList ID="Dept_DDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="Dept" DataValueField="Dept"></asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DormitoryConnectionString %>' SelectCommand="SELECT [Dept] FROM [Department] ORDER BY [Dept]"></asp:SqlDataSource>
            </div>
           <div>
               <asp:Label ID="Label6" runat="server" Text="Session"></asp:Label>
               <asp:DropDownList ID="Session_DDL" runat="server" DataSourceID="SqlDataSource2" DataTextField="Session" DataValueField="Session"></asp:DropDownList>
               <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DormitoryConnectionString %>' SelectCommand="SELECT * FROM [Session] ORDER BY [Session]"></asp:SqlDataSource>
           </div>
            <div>
            <asp:Label ID="Label7" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Pass_TB" runat="server"></asp:TextBox>
            </div>
            <div>
            <asp:Label ID="Label8" runat="server" Text="Retype password"></asp:Label>
            <asp:TextBox ID="Repass_TB" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
