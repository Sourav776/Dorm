<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.master" AutoEventWireup="true" CodeFile="Hall_Review.aspx.cs" Inherits="Hall_Review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title> Form Review</title>
     <style>
        tr, th {
            text-align: center;
        }
        .auto-style1 {
            width: 392px;
            height:35px;
        }
    </style>
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
    <div>
        <center>

      <div class="container fullbody">
		<div class="row">

			<div class="col-xs-12 table-responsive">
			  <table border="2" class="table">
			    <tr class="success table-tr">
			    	<th>Name</th>
			    	<th id="Name1" runat="server"></th>
			    </tr>
                 <tr class="table-tr">
			    	<td>Hall</td>
                    <td id="Hall1" runat="server"></td>
			    </tr>
			    <tr  class="table-tr">
			    	<td>Exam Name</td>
                    <td id="ExamName1" runat="server"></td>
			    </tr>
                <tr class="table-tr">
                    <td>Department/Institute</td>
                    <td id="Dept1" runat="server"></td>
                </tr>
                <tr>
                    <td>Class Roll</td>
                    <td id="ClassRoll1" runat="server"></td>
                </tr>
                <tr>
                    <td>Registration Number</td>
                    <td id="RegisNum1" runat="server"></td>
                </tr>
                <tr>
                    <td>Session</td>
                    <td id="Sessi1" runat="server"></td>
                </tr>
                <tr>
                    <td>Father Name</td>
                    <td id="FatherName1" runat="server"></td>
                </tr>
                <tr>
                    <td>Mother Name</td>
                    <td id="MotherName1" runat="server"></td>
                </tr>
                
			  </table>
                <asp:Button ID="Button1" runat="server" Text="Previous" OnClick="Button1_Click1"></asp:Button>
                 <asp:Button ID="Button2" runat="server" Text="Next" OnClick="Button1_Click"></asp:Button>
                 <asp:Button ID="Button3" runat="server" Text="Approve" OnClick="Button3_Click"></asp:Button>
                <div>
                  <asp:Label ID="message" runat="server" Text="" Visible="false"></asp:Label>
                 </div>
			</div>
		</div>
	</div>

        </center>
</asp:Content>