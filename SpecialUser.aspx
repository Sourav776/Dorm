<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.master" AutoEventWireup="true" CodeFile="SpecialUser.aspx.cs" Inherits="SpecialUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Special User</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="List" runat="Server">
    <li class="nav-item active">
        <a class="nav-link" href="HomePage.aspx">Home Page<span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="UserCreation.aspx">Register New User <span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="#">Special A/C<span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="#">About <span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="AddInformation.aspx">Fill out Form</a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="Hall_Review.aspx">Hall Approval</a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="Department_Review.aspx">Department Approval</a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="Final.aspx">Completion</a>
    </li>
    <li>
        <a id="user" href="#" runat="server"></a>
    </li>
     <asp:Button ID="Button4" CssClass="logout" runat="server" Text="Log Out" OnClick="logout" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Control" Runat="Server">

    <div class="text-center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                      </asp:ScriptManager>
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                          <ContentTemplate>

        <div>


            <asp:RadioButton ID="Director" CssClass="DirectorR" runat="server" AutoPostBack="true" GroupName="Ty" OnCheckedChanged="Director_CheckedChanged" Text="Director" />
            <asp:RadioButton ID="Provost" CssClass="ProvostR" runat="server" AutoPostBack="true" GroupName="Ty" OnCheckedChanged="Provost_CheckedChanged" Text="Provost" />
            <asp:RadioButton ID="Admin" CssClass="AdminR" runat="server" AutoPostBack="true" GroupName="Ty" OnCheckedChanged="Admin_CheckedChanged" Text="Admin Personnel" />

        </div>
        <div>
            <asp:DropDownList ID="Entity_DDL" CssClass="Entity" runat="server" AppendDataBoundItems="true">
            </asp:DropDownList>
        </div>
                              <br/>
        <div>
            <asp:Label ID="Label1" CssClass="FirstL" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="First_TB" CssClass="FirstT" runat="server"></asp:TextBox>
        </div>
        <br />
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
        <br />
        <div>
            <asp:Label ID="Label4" CssClass="PassL" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Pass_TB" CssClass="PassT" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <br />
                              
                          </ContentTemplate>
              </asp:UpdatePanel>
              
        <div>
            <asp:Label ID="Label8" CssClass="SignL" runat="server" Text="Upload Signature"></asp:Label>
            <asp:FileUpload ID="FileUpload1" CssClass="Upload" runat="server" />
            <div>
                <asp:Label ID="Label9" CssClass="MesL" runat="server" Text="" Visible="false"></asp:Label>
            </div>

        </div>
        <br />
        <div>
            <asp:Button ID="Button1" CssClass="Button" runat="server" Text="Register" OnClick="Button1_Click" Style="height: 26px" />
        </div>

    </div>
</asp:Content>

