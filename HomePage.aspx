
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title> Home page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="List" runat="Server">
    <li class="nav-item active">
        <a class="nav-link" href="HomePage.aspx">Home Page<span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="UserCreation.aspx">Register New User <span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="#">About <span class="sr-only"></span></a>
    </li>
    
    <li>
        <a id="user" href="#" runat="server"></a>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Control" Runat="Server">
    <div class="content-center">
        <div class="container">
            <div class="row">
                <div class="wrapper">
                    <div class="form-signin fixlogin headerlogin">
                        <h2 class="form-signin-heading">Sign In</h2>
                    </div>
                    <div class="form-signin fixlogin">
                        <asp:Label ID="Label1" class="form-control" runat="server" required="" autofocus="" Text="User Name/ Email" BackColor="#00CC00" ForeColor="Yellow"></asp:Label>
                        <asp:TextBox ID="Name_TB" class="form-control" runat="server" required="" autofocus=""></asp:TextBox>

                        <br />

                        <asp:Label ID="Label2" class="form-control" runat="server" Text="Password" required="" autofocus="" BackColor="#00CC00" ForeColor="Yellow"></asp:Label>
                        <asp:TextBox ID="Pass_TB" class="form-control" runat="server" TextMode="Password" required="" autofocus=""></asp:TextBox>
                        <br />

                        <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-primary btn-block" Text="Log in" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

