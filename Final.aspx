<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.master" AutoEventWireup="true" CodeFile="Final.aspx.cs" Inherits="Final" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title> Print Form</title>
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
    <li class="nav-item active">
        <a class="nav-link" href="AddInformation.aspx">Fill out Form</a>
    </li>
    <li>
      <a id="user" href="#" runat="server"></a>
    </li>
     <asp:Button ID="Button4" CssClass="logout" runat="server" Text="Log Out" OnClick="logout" />
</asp:Content>

     

<asp:Content ID="Content3" ContentPlaceHolderID="Control" Runat="Server">
     <div>
           
            <div style="padding-left: 16px">
                <CR:CrystalReportViewer ID="crv" runat="server" AutoDataBind="true" ToolPanelView="None" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"></CR:CrystalReportViewer>
            </div>
            <div>
                <asp:Button ID="Button2" runat="server" Text="Report" OnClick="Button1_Click" />
             </div>
        </div>

    </asp:Content>