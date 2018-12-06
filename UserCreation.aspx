<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.master" AutoEventWireup="true" CodeFile="UserCreation.aspx.cs" Inherits="UserCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title> Create new user</title>
       <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="vendor/bootstrap/css/mian.css" rel="stylesheet" />
  
   <%-- <script>
        //$(function () {
        //    $("#BirthDate_TB").datepicker();
        //});

        $(function () {
            $("#BirthDate_TB").datepicker({
                dateFormat: 'mm/dd/yy'
            });


            $("#BirthDate_TB").each(function () {
                var currentValue = $(this).val();
                if (currentValue)
                    $(this).datepicker('setDate', new Date(currentValue));

            });

            $("#BirthDate_TB").keydown(function (event) {
                if (event.keyCode != 8) {
                    event.preventDefault();
                }
            });

        });
    </script>--%>
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
     <asp:Button ID="Button4" CssClass="logout" runat="server" Text="Log Out" OnClick="logout" />
</asp:Content>

  <asp:Content ID="Content3" ContentPlaceHolderID="Control" runat="Server">  
      <div class="text-center">
            <div>
            <asp:Label ID="Label1" CssClass="FirstL" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="First_TB"  CssClass="FirstT" runat="server"></asp:TextBox>
            </div>
          <br/>
            <div>
            <asp:Label ID="Label2" CssClass="LastL" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="Last_TB" CssClass="LastT" runat="server"></asp:TextBox>
            </div>
          <br />
            <div>
            <asp:Label ID="Label3" CssClass="MailL" runat="server" Text="User Name/ Email"></asp:Label>
            <asp:TextBox ID="Name_TB" CssClass="MailT" runat="server"></asp:TextBox>
            <asp:Label ID="UserMessage" CssClass="messageL" runat="server" Text="User name taken. Try with another!" ForeColor="Red" Visible="false"></asp:Label>
            </div>
          <br/>
            <div>
            <asp:Label ID="Label4" CssClass="PassL" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Pass_TB" CssClass="PassT"  runat="server" TextMode="Password"></asp:TextBox>
            </div>
          <br/>
            <div>
             <asp:Button ID="Button1" CssClass="Button"  runat ="server" Text="Register" OnClick="Button1_Click" style="height: 26px" />
            </div>

  </div>
      </asp:Content>     
  